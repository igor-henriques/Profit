using Microsoft.EntityFrameworkCore;
using Profit.Data;
using Profit.Models.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class IngredienteForm : Form
    {
        int id = -1, ableToEdit = 0;

        public IngredienteForm()
        {
            InitializeComponent();
        }
        #region FormMovement
        private bool mouseDown;
        private System.Drawing.Point lastLocation;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private async void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new System.Drawing.Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

               this.Update();
            }
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion       
        private void BtnBack_Click(object sender, EventArgs e)
        {
            animGone.Start();
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != string.Empty && tbQnt.Text.Trim() != string.Empty && tbPrice.Text.Trim() != string.Empty)
            {
                await Insert();
                await Refresh();
            }
            else
                AutoClosingMessageBox.Show("Há campos vazios!", "ERRO", 1000);
        }
        private async void IngredienteForm_Load(object sender, EventArgs e)
        {
            animOpen.Start();
            await Refresh();            
        }
        private async Task<List<Receita>> UpdateRecipes()
        {
            //Atualiza na tabela INGREDIENTE_RECEITA todos os registros de preço unitário afetados pela alteração do registro na tabela INGREDIENTE
            using (var db = new ApplicationDbContext())
            {
                //Requisita para a tabela Ingrediente_Receita todos os registros do ingrediente alterado
                List<Ingrediente_Receita> ingReceita = await db.Ingrediente_Receita.Where(x => x.Id_Ingrediente == id).ToListAsync();

                //Atualiza na tabela Ingrediente_Receita o preço unitário do Ingrediente alterado
                ingReceita.ForEach(async x => x.Preco_Unitario = await UnitPrice(x.Ingrediente.Price, x.Quantia_Usada));

                //Seleciona cada receita que foi afetada pela modificação
                List<Receita> affectedRecipes = ingReceita.Select(x => x.Receita).ToList();                

                foreach (var recipe in affectedRecipes)
                {
                    //Seleciona cada ingrediente da receita atual e soma seu custo
                    recipe.Cost = ingReceita.Where(x => x.Id_Receita == recipe.Id).Select(x => x.Preco_Unitario).Sum();
                }

                await db.SaveChangesAsync();

                return affectedRecipes;
            }                        
        }
        private async Task<List<Produto>> UpdateProducts(List<Receita> affectedRecipes)
        {
            using (var db = new ApplicationDbContext())
            {
                List<Produto> affectedProducts = new List<Produto>();

                affectedRecipes.ForEach(async x => affectedProducts.AddRange(await db.Produto.Where(y => y.Id_Receita == x.Id).ToListAsync()));

                affectedProducts.ForEach(x => x.Profit = x.Price - affectedRecipes.Where(z => z.Id == x.Id_Receita).Select(y => y.Cost).FirstOrDefault());          

                await db.SaveChangesAsync();

                return affectedProducts;
            }            
        }
        private async new Task _Update()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var modifiedIngredient = db.Ingrediente.Where(x => x.Id == id).FirstOrDefault();

                    if (modifiedIngredient != null)
                    {
                        modifiedIngredient.Name = tbName.Text;
                        modifiedIngredient.Price = Convert.ToDecimal(tbPrice.Text.Replace("R$ ", "").Trim());
                        modifiedIngredient.Quantia_Total = Convert.ToInt32(tbQnt.Text.Trim());

                        await db.SaveChangesAsync();
                    }
                }

                List<Receita> affectedRecipes = await UpdateRecipes();
                List<Produto> affectedProducts = await UpdateProducts(affectedRecipes);

                await Refresh();
                AutoClosingMessageBox.Show("Dados atualizados com sucesso!\nForam afetadas " + affectedRecipes.Count + " receitas e " + affectedProducts.Count + " produtos.", "Sucesso", 2000);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Update -> Ingrediente\n" + e.Message, "ERRO");
            }
        }
        private async Task<decimal> UnitPrice(decimal updatedPrice, decimal quantia_utilizada) => (updatedPrice * quantia_utilizada) / Convert.ToDecimal(tbQnt.Text.Trim());            
        
        public bool NameExists(string name)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    return db.Ingrediente.Where(x => x.Name == name).FirstOrDefault() != null ? true : false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função NameExists -> Ingrediente\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;                               
            }
        }
        public async Task Insert()
        {
            try
            {
                if (!NameExists(tbName.Text))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        db.Ingrediente.Add(new Ingrediente
                        {
                            Name = tbName.Text.ToUpper(),
                            Price = Convert.ToDecimal(tbPrice.Text.Replace("R$ ", "").Trim()),
                            Quantia_Total = Convert.ToInt32(tbQnt.Text.Trim())
                        });

                        await db.SaveChangesAsync();
                    }

                    await Refresh();

                    AutoClosingMessageBox.Show("Dados inseridos com sucesso!", "Sucesso");
                }
                else
                {
                    MessageBox.Show("Nome já cadastrado!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                    
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Insert -> Ingrediente\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task Delete()
        {
            try
            {
                if (dgvIngredientes.SelectedRows.Count > 0)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var ingredientToDelete = db.Ingrediente_Receita.Include(z => z.Ingrediente).Include(c => c.Receita).Where(x => x.Id_Ingrediente == id).ToList();

                        if (ingredientToDelete != null)
                        {
                            var affectedRecipes = ingredientToDelete.Select(x => x.Receita).ToList();
                            affectedRecipes = affectedRecipes.Where(x => x != null).ToList();

                            if (MessageBox.Show($"{affectedRecipes.Count} receita(s) serão excluídas ao remover este ingrediente. Tem certeza que deseja prosseguir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.Ingrediente_Receita.RemoveRange(ingredientToDelete);
                                db.Receita.RemoveRange(affectedRecipes);
                                ingredientToDelete.ForEach(x => db.Ingrediente.Remove(x.Ingrediente));
                            }
                        }

                        await db.SaveChangesAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Delete -> Ingrediente\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                         
        }
        public async new Task Refresh()
        {
            try
            {
                tbName.Text = "";
                tbPrice.Text = "";
                tbQnt.Text = "";   
                
                tbName.Focus();

                using (var db = new ApplicationDbContext())
                {
                    dgvIngredientes.DataSource = null;
                    dgvIngredientes.Refresh();
                    dgvIngredientes.DataSource = await db.Ingrediente.ToListAsync();
                    FormatColumns();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Refresh -> Ingrediente\n" + e.Message, "ERRO");
            }
        }
        public void FormatColumns()
        {            
            dgvIngredientes.Columns[0].Visible = false;
            dgvIngredientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredientes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvIngredientes.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;            

            dgvIngredientes.Columns[2].DefaultCellStyle.Format = "c";

            dgvIngredientes.Columns[1].HeaderText = "Nome";
            dgvIngredientes.Columns[2].HeaderText = "Preço";
            dgvIngredientes.Columns[3].HeaderText = "Quantidade";            

            for (int i = 0; i < dgvIngredientes.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvIngredientes.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }                    
                else
                {
                    dgvIngredientes.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }                    
            }                      

            dgvIngredientes.ClearSelection();
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvIngredientes.SelectedRows.Count > 0)
            {
                if (ableToEdit <= 0)
                {
                    btnSave.Enabled = false;                    
                    btnExcluir.Enabled = false;                  
                    btnEdit.Text = "Salvar!";                    
                    tbName.Text = dgvIngredientes.SelectedRows[0].Cells[1].Value.ToString();
                    tbPrice.Text = Convert.ToDouble(dgvIngredientes.SelectedRows[0].Cells[2].Value).ToString("c");
                    tbQnt.Text = Convert.ToDouble(dgvIngredientes.SelectedRows[0].Cells[3].Value).ToString("0.00");
                    tbName.Focus();
                }                

                ableToEdit++;

                if (ableToEdit > 1)
                {
                    await _Update();

                    btnSave.Enabled = true;                    
                    btnExcluir.Enabled = true;                    
                    btnEdit.Text = "Editar";
                    tbName.Text = "";
                    tbPrice.Text = "";
                    tbQnt.Text = "";
                    tbName.Focus();
                    ableToEdit = 0;
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para editar!", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }                
        }
        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir esse registro?\nTODAS AS RECEITAS QUE UTILIZAM ESSE INGREDIENTE SERÃO APAGADAS!", "IMPORTANTE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                await Delete();
                await Refresh();
            }
        }
        private void DgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvIngredientes.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Não há item cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TbPrice_Leave(object sender, EventArgs e)
        {
            if (tbPrice.Text.Trim() != string.Empty)
                tbPrice.Text = Convert.ToDouble(tbPrice.Text.Replace("R$ ", "").Trim()).ToString("c");
        }
        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
                Opacity += 0.1;
            else            
                animOpen.Stop();            
        }
        private void AnimGone_Tick(object sender, EventArgs e)
        {
            if (animOpen.Enabled)
                animOpen.Stop();

            if (Opacity > 0)
                Opacity -= 0.125;
            else
            {
                animGone.Stop();
                Hide();
            }                
        }
        private void TbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbPrice.Focus();
            else if (e.KeyCode == Keys.Escape)
                animGone.Start();
        }
        private void TbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbQnt.Focus();
            else if (e.KeyCode == Keys.Escape)
                animGone.Start();
        }
        private void TbQnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                animGone.Start();
        }
        private void IngredienteForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                animGone.Start();
        }
        private void TbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != ',' || !Decimal.TryParse(tbPrice.Text + ch, out x))
            {
                e.Handled = true;
            }
        }
        private async void TbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var foundIngredients = from i in db.Ingrediente where EF.Functions.Like(i.Name, $"%{tbSearch.Text.Trim()}%") select i;
                        dgvIngredientes.DataSource = foundIngredients.ToList();
                        dgvIngredientes.Rows[dgvIngredientes.Rows.Count - 1].Selected = true;
                        FormatColumns();
                    }                   
                }
                else
                {
                    await Refresh();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void TbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.ForeColor = Color.Black;
            tbSearch.Clear();
            tbSearch.Focus();
        }
        private void TbSearch_Leave(object sender, EventArgs e)
        {
            tbSearch.ForeColor = Color.Gray;
            if (tbSearch.Text.Trim() == string.Empty)            
                tbSearch.Text = "ex: ''PRESUNTO''";                            
        }
        private void TbQnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != ',' || !Decimal.TryParse(tbQnt.Text + ch, out x))
            {
                e.Handled = true;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnBack.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}