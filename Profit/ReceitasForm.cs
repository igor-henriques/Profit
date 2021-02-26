using Microsoft.EntityFrameworkCore;
using Profit.Data;
using Profit.Models.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class ReceitasForm : Form
    {
        Quantify quantify;

        List<CheckBox> checkBoxes = new List<CheckBox>();

        List<Ingrediente> allIngredients = new List<Ingrediente>();
        List<Tuple<Ingrediente, decimal>> usedIngredientAmount = new List<Tuple<Ingrediente, decimal>>();       

        double id = -1, ableToEdit = 0;
        decimal totalCost = 0;

        bool editing = false;
        public ReceitasForm()
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
        public async Task GetIngredients()
        {
            try
            {
                allIngredients.Clear();
                flowPanel.Controls.Clear();

                using (var db = new ApplicationDbContext())
                {
                    allIngredients = await db.Ingrediente.ToListAsync();

                    foreach (var ing in allIngredients)
                    {
                        CheckBox b = new CheckBox
                        {
                            Name = ing.Name,
                            Text = ing.Name,
                            AutoSize = true,
                        };

                        b.CheckedChanged += (sender, e) => CheckBox_CheckedChanged(b);

                        checkBoxes.Add(b);
                        flowPanel.Controls.Add(b);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função GetIngredients -> Receitas\n" + e.Message, "ERRO");
            }
        }
        private void CheckBox_CheckedChanged(CheckBox cb)
        {
            try
            {
                if (cb.Checked)
                {
                    rtbAtual.Text += (cb.Name + "+").Trim();

                    foreach (var ingredient in allIngredients)
                    {
                        if (cb.Name.Equals(ingredient.Name))
                        {
                            quantify = new Quantify();
                            quantify.ShowDialog();

                            usedIngredientAmount.Add(new Tuple<Ingrediente, decimal>(ingredient, quantify.quantidadeUtilizada));

                            totalCost += (ingredient.Price * quantify.quantidadeUtilizada) / ingredient.Quantia_Total;
                            lblCost.Text = totalCost.ToString("c");

                            break;
                        }
                    }
                }
                else if (!cb.Checked)
                {
                    rtbAtual.Text = rtbAtual.Text.Replace(cb.Name + "+", "").Trim();

                    foreach (var ingredient in allIngredients)
                    {
                        if (cb.Name.Equals(ingredient.Name))
                        {
                            usedIngredientAmount.Remove(usedIngredientAmount.Where(x => x.Item1.Name == cb.Name).FirstOrDefault());

                            totalCost -= (ingredient.Price * quantify.quantidadeUtilizada) / ingredient.Quantia_Total;
                            lblCost.Text = totalCost.ToString("c");

                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro no evento CheckedChange -> Receitas\n" + e.Message, "ERRO");
            }
        }
        public bool NameExists(string curName)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var currentName = db.Receita.Where(x => x.Name == curName.Trim()).FirstOrDefault();

                    return currentName is null ? true : false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função NameExists -> Receitas\n" + e.Message, "ERRO");

                tbName.Clear();
                return true;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != string.Empty)
            {
                if (Convert.ToDouble(lblCost.Text.Replace("R$", "").Trim()) <= 0)
                {
                    MessageBox.Show("Selecione ao menos um ingrediente para salvar essa receita!", "ERRO");
                }
                else
                {
                    await Insert();
                }
            }
            else
            {
                MessageBox.Show("Por favor, indique um nome para esta receita!", "ERRO");
            }

            checkBoxes.ForEach(x => x.Checked = false);

            totalCost = 0;
            lblCost.Text = totalCost.ToString("c");

            await GetIngredients();
        }
        public async Task Insert()
        {
            try
            {
                if (NameExists(tbName.Text))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        Receita novaReceita = new Receita
                        {
                            Name = tbName.Text.Trim(),
                            Description = rtbAtual.Text.Trim().Remove(rtbAtual.Text.Length - 1, 1),
                            Cost = totalCost
                        };

                        db.Receita.Add(novaReceita);

                        await db.SaveChangesAsync();

                        foreach (var checkbox in checkBoxes.Where(x => x.Checked))
                        {
                            Ingrediente currentIngredient = db.Ingrediente.Where(x => x.Name == checkbox.Name).FirstOrDefault();
                            Receita currentRecipe = db.Receita.Where(x => x.Name == novaReceita.Name).FirstOrDefault();

                            var curPrice = GetUnitPrice(currentIngredient.Name, usedIngredientAmount.Where(x => x.Item1.Id == currentIngredient.Id).FirstOrDefault().Item2);
                            var curAmount = usedIngredientAmount.Where(x => x.Item1.Id == currentIngredient.Id).FirstOrDefault().Item2;

                            Ingrediente_Receita bridgeInfo = new Ingrediente_Receita
                            {
                                Ingrediente = currentIngredient,                                
                                Id_Ingrediente = currentIngredient.Id,
                                Receita = currentRecipe,
                                Id_Receita = currentRecipe.Id,
                                Preco_Unitario = curPrice,
                                Quantia_Usada = curAmount
                            };

                            db.Ingrediente_Receita.Add(bridgeInfo);
                        }

                        await db.SaveChangesAsync();

                        await GetRecipes();

                        AutoClosingMessageBox.Show("Dados salvos com sucesso", "SUCESSO", 500);
                    }
                }
                else
                {
                    MessageBox.Show("Nome já cadastrado!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Insert -> Receitas\n" + e.Message, "ERRO");
            }
        }
        public decimal GetUnitPrice(string ing, decimal quantidade_utilizada)
        {
            decimal response = -1;

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var ingredient = db.Ingrediente.Where(x => x.Name == ing).FirstOrDefault();

                    if (ingredient != null)
                    {
                        decimal quantidade_total = ingredient.Quantia_Total, preco_total = ingredient.Price;

                        response = (preco_total * quantidade_utilizada) / quantidade_total;
                    }
                    else
                    {
                        response = -1;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Insert -> Receitas\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                response = -1;
            }

            return response;
        }
        private async Task Delete()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Ingrediente_Receita.RemoveRange(db.Ingrediente_Receita.Where(x => x.Id_Receita == id).ToList());
                    db.Receita.RemoveRange(db.Receita.Where(x => x.Id == id).ToList());

                    await db.SaveChangesAsync();
                }

                MessageBox.Show("Dados deletados com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Delete -> Receitas\n" + e.Message, "ERRO");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete && dgvReceitas.SelectedRows.Count > 0)
            {
                btnExcluir.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btnBack.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btnBack.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void ReceitasForm_Load(object sender, EventArgs e)
        {
            await GetIngredients();
            await GetRecipes();

            animOpen.Start();
        }
        private async Task GetRecipes()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var recipes = await db.Receita.ToListAsync();

                    dgvReceitas.DataSource = null;
                    dgvReceitas.DataSource = recipes;
                    dgvReceitas.Update();

                    FormatColumns();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função GetRecipes -> Receitas\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FormatColumns()
        {
            dgvReceitas.Columns[0].Visible = false;
            
            dgvReceitas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvReceitas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvReceitas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvReceitas.Columns[3].DefaultCellStyle.Format = "c";

            dgvReceitas.Columns[1].HeaderText = "Nome";
            dgvReceitas.Columns[2].HeaderText = "Descrição";
            dgvReceitas.Columns[3].HeaderText = "Custo Total";

            for (int i = 0; i < dgvReceitas.RowCount; i++)
            {
                if (i % 2 == 0)
                    dgvReceitas.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                else
                    dgvReceitas.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            dgvReceitas.ClearSelection();
            tbName.Clear();
            rtbAtual.Clear();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            animGone.Start();
        }
        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvReceitas.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir esse registro?", "Excluindo...", MessageBoxButtons.YesNo))
                {
                    await Delete();
                    await GetRecipes();
                    lblCost.Text = totalCost.ToString("c");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para excluir", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Label5_Click(object sender, EventArgs e)
        {
            totalCost = 0;
            lblCost.Text = "R$00" + totalCost.ToString(".00");
        }
        private void Label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }
        private void Label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }
        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.125;
            else
                animOpen.Stop();
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
        private void DgvReceitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToDouble(dgvReceitas.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {
                
            }
        }
        private void TbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReceitas.SelectedRows.Count > 0 && id != -1)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var cost = db.Receita.Where(x => x.Id == id).Select(y => y.Cost).FirstOrDefault();
                        var ingredientes = dgvReceitas.SelectedRows[0].Cells[2].Value.ToString().Split('+');

                        RecipeEdit editar = new RecipeEdit(id, await GetIngredientAmount(id), dgvReceitas.SelectedRows[0].Cells[1].Value.ToString(), dgvReceitas.SelectedRows[0].Cells[2].Value.ToString(), cost);

                        Hide();
                        editar.ShowDialog();
                        Show();

                        await GetRecipes();
                        await GetIngredients();

                        Update();
                    }                    
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento btnEdit -> Receitas\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<List<Tuple<Ingrediente, decimal>>> GetIngredientAmount(double recipeId)
        {
            using (var db = new ApplicationDbContext())
            {
                List<Tuple<Ingrediente, decimal>> response = new List<Tuple<Ingrediente, decimal>>();

                var ingredientsUsed = await db.Ingrediente_Receita.Include(a => a.Ingrediente).Include(c => c.Receita).Where(x => x.Id_Receita == recipeId).ToListAsync();

                ingredientsUsed.ForEach(x => response.Add(new Tuple<Ingrediente, decimal>(db.Ingrediente.Find(x.Id_Ingrediente), x.Preco_Unitario)));

                return response;
            }
        }
        private void dgvReceitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (id != -1)
            {
                btnEdit.PerformClick();
            }
        }
    }
}