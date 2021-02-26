using Microsoft.EntityFrameworkCore;
using Profit.Data;
using Profit.Models;
using Profit.Models.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class ProdutosForm : Form
    {
        double id = -1, id_receita = -1, ableToEdit;
        public ProdutosForm()
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
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
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
        private async Task<List<Produto>> GetData()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    List<Receita> recipes = await db.Receita.ToListAsync();
                    recipes.ForEach(x => comboBox.Items.Add(x.Name));

                    var products = await db.Produto.ToListAsync();
                    return products;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função GetData -> Produtos\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }                
        private async Task FillGrid(List<Produto> products)
        {
            try
            {                
                dgvProdutos.DataSource = products;
                FormatColumns();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FillGrid -> Produtos\n" + e.Message, "ERRO");
            }
        }
        private async Task Insert()
        {
            try
            {
                if (NameExists(tbName.Text))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        db.Produto.Add(new Produto
                        {
                            Name = tbName.Text.Trim(),
                            Price = Convert.ToDecimal(tbPrice.Text.Replace("R$ ", "").Trim()),
                            Profit = Convert.ToDecimal(tbPrice.Text.Replace("R$ ", "")) - await GetCostByRecipe(comboBox.SelectedItem.ToString()),
                            Id_Receita = await GetRecipeId(comboBox.SelectedItem.ToString())
                        });

                        await db.SaveChangesAsync();

                        AutoClosingMessageBox.Show("Dados inseridos com sucesso", "SUCESSO", 500);
                        await FillGrid(await GetData());
                    }
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Insert -> Produtos\n" + e.Message, "ERRO");
            }
        }
        private async Task<int> GetRecipeId(string name)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Receita.Where(x => x.Name == name).FirstOrDefault().Id;
            }
        }
        private async Task _Update()
        {
            try
            {       
                using (var db = new ApplicationDbContext())
                {
                    Produto newProduct = new Produto
                    {
                        Id = (int)id,
                        Id_Receita = (int)id_receita,
                        Name = tbName.Text.Trim(),
                        Price = Convert.ToDecimal(tbPrice.Text.Replace("R$", "").Trim()),
                        Profit = Convert.ToDecimal(tbPrice.Text.Replace("R$", "").Trim()) - await GetCostByRecipe(id_receita)
                    };

                    db.Produto.Update(newProduct);
                    await db.SaveChangesAsync();

                    await FillGrid(await GetData());
                    AutoClosingMessageBox.Show("Dados atualizados com sucesso", "Sucesso", 500);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Update -> Produtos\n" + e.Message);
            }            
        }
        private async Task<decimal> GetCostByRecipe(double recipeId)
        {
            decimal response = -1;

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var curRecipe = db.Receita.Where(x => x.Id == recipeId).FirstOrDefault();

                    response = curRecipe != null ? curRecipe.Cost : -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função GetCostByName -> Produtos\n" + e.Message);
                return -1;
            }

            return response;
        }
        private async Task<decimal> GetCostByRecipe(string recipeName)
        {
            decimal response = -1;

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var curRecipe = db.Receita.Where(x => x.Name == recipeName).FirstOrDefault();

                    response = curRecipe != null ? curRecipe.Cost : -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função GetCostByName -> Produtos\n" + e.Message);
                return -1;
            }

            return response;
        }
        private async Task Delete()
        {
            try
            {
                if (dgvProdutos.SelectedRows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir esse registro?", "Excluindo", MessageBoxButtons.YesNo))
                    {
                        using (var db = new ApplicationDbContext())
                        {
                            db.Produto.RemoveRange(db.Produto.Where(x => x.Id == id));
                            await db.SaveChangesAsync();

                            AutoClosingMessageBox.Show("Dados deletados com sucesso", "SUCESSO", 500);                            
                            await FillGrid(await GetData());
                            FormatColumns();
                        }                        
                    }
                }
                else
                {
                    AutoClosingMessageBox.Show("Selecione uma linha para deletar", "ERRO", 500);
                }                    
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Delete -> Produtos\n" + e.Message, "ERRO");                
            }
        }
        void FormatColumns()
        {
            dgvProdutos.Columns[0].Visible = false;
            dgvProdutos.Columns[4].Visible = false;
            dgvProdutos.Columns[5].Visible = false;

            dgvProdutos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProdutos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                                    

            dgvProdutos.Columns[2].DefaultCellStyle.Format = "c";
            dgvProdutos.Columns[3].DefaultCellStyle.Format = "c";

            dgvProdutos.Columns[1].HeaderText = "Nome";
            dgvProdutos.Columns[2].HeaderText = "Preço";
            dgvProdutos.Columns[3].HeaderText = "Lucro";

            for (int i = 0; i < dgvProdutos.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvProdutos.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    dgvProdutos.Rows[i].Cells[1].Value = dgvProdutos.Rows[i].Cells[1].Value.ToString().Trim();                    
                }                    
                else
                {
                    dgvProdutos.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvProdutos.Rows[i].Cells[1].Value = dgvProdutos.Rows[i].Cells[1].Value.ToString().Trim();
                }                   
            }
            
            dgvProdutos.ClearSelection();
            tbName.Clear();
            tbPrice.Clear();
            comboBox.SelectedItem = null;
        }
        public bool NameExists(string curName)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var currentName = db.Produto.Where(x => x.Name == curName.Trim()).FirstOrDefault();

                    return currentName is null ? true : false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função NameExists -> Produtos\n" + e.Message, "ERRO");

                tbName.Clear();
                return true;
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            animGone.Start();
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            await Insert();
        }
        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            await Delete();
        }
        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToDouble(dgvProdutos.SelectedRows[0].Cells[0].Value);
                id_receita = Convert.ToDouble(dgvProdutos.SelectedRows[0].Cells[4].Value);
            }
            catch (Exception)
            {
                
            }            
        }
        private void DgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToDouble(dgvProdutos.SelectedRows[0].Cells[0].Value);
                id_receita = Convert.ToDouble(dgvProdutos.SelectedRows[0].Cells[4].Value);
            }
            catch (Exception)
            {
                
            }
        }
        private async void Produtos_Load(object sender, EventArgs e)
        {            
            await FillGrid(await GetData());            
            animOpen.Start();
        }
        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.125;
            else
            {
                animOpen.Stop();
            }
        }

        private void AnimGone_Tick(object sender, EventArgs e)
        {
            if (animOpen.Enabled)
                animOpen.Stop();

            if (Opacity > 0)
                Opacity -= 0.10;
            else
            {
                animGone.Stop();
                Close();
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                if (ableToEdit <= 0)
                {
                    dgvProdutos.Enabled = false;
                    btnSave.Enabled = false;                    
                    btnExcluir.Enabled = false;                   
                    btnEdit.Text = "Salvar!";
                    tbName.Text = dgvProdutos.SelectedRows[0].Cells[1].Value.ToString();
                    tbPrice.Text = Convert.ToDouble(dgvProdutos.SelectedRows[0].Cells[2].Value).ToString("c");

                    using (var db = new ApplicationDbContext())
                    {
                        comboBox.SelectedItem = db.Receita.Where(x => x.Id == id_receita).FirstOrDefault().Name;
                    }

                    tbName.Focus();
                }

                ableToEdit++;

                if (ableToEdit > 1)
                {
                    if (comboBox.SelectedIndex >= 0)
                    {
                        await _Update();

                        dgvProdutos.Enabled = true;
                        btnSave.Enabled = true;                        
                        btnExcluir.Enabled = true;                      
                        btnEdit.Text = "Editar";
                        tbName.Text = "";
                        tbPrice.Text = "";
                        tbPrice.Focus();
                        ableToEdit = 0;
                    }
                    else
                    {
                        MessageBox.Show("Certifique-se de selecionar uma receita!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                        
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        private void TbPrice_Leave(object sender, EventArgs e)
        {
            if (tbPrice.Text.Trim() != string.Empty)
                tbPrice.Text = Convert.ToDouble(tbPrice.Text.Replace("R$ ", "").Trim()).ToString("c");
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