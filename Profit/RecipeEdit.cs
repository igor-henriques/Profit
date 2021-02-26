using Microsoft.EntityFrameworkCore;
using Profit.Data;
using Profit.Models;
using Profit.Models.Db;
using Renci.SshNet.Security;
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
    public partial class RecipeEdit : Form
    {
        ReceitasForm receitas = new ReceitasForm();
        Quantify quantify;
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<Ingrediente> allIngredients = new List<Ingrediente>();
        List<Tuple<Ingrediente, decimal>> usedIngredients;

        double id;
        decimal totalCost = 0;
        string recipeName, wholeDesc;

        public RecipeEdit(double recipeId, List<Tuple<Ingrediente, decimal>> usedIngredients, string recipeName, string wholeDesc, decimal recipeCost)
        {
            InitializeComponent();

            this.usedIngredients = usedIngredients;
            this.id = recipeId;
            this.recipeName = recipeName;
            this.wholeDesc = wholeDesc;
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
        private async void RecipeEdit_Load(object sender, EventArgs e)
        {
            await GetIngredients();

            lblCost.Text = totalCost.ToString("c");
            tbName.Text = recipeName;           
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbName.Text.Trim()))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var curRecipe = db.Receita.Where(x => x.Id == id).FirstOrDefault();

                        if (curRecipe != null)
                        {
                            curRecipe.Name = tbName.Text;
                            curRecipe.Description = rtbAtual.Text.Remove(rtbAtual.Text.Length - 1);
                            curRecipe.Cost = Convert.ToDecimal(lblCost.Text.Replace("R$ ", ""));
                        }

                        db.Ingrediente_Receita.RemoveRange(from i in db.Ingrediente_Receita where i.Id_Receita == curRecipe.Id select i);

                        await db.SaveChangesAsync();

                        foreach (var checkbox in checkBoxes.Where(x => x.Checked))
                        {
                            Ingrediente curIngredient = db.Ingrediente.Where(x => x.Name == checkbox.Name).FirstOrDefault();
                            Receita currentRecipe = db.Receita.Where(x => x.Name == curRecipe.Name).FirstOrDefault();

                            var curPrice = usedIngredients.Where(x => x.Item1.Id == curIngredient.Id).FirstOrDefault().Item2;
                            var curAmount = GetAmountByPrice(curIngredient.Name, curPrice);

                            Ingrediente_Receita bridgeInfo = new Ingrediente_Receita
                            {                                
                                Id_Ingrediente = curIngredient.Id,
                                Ingrediente = curIngredient,
                                Receita = currentRecipe,
                                Id_Receita = currentRecipe.Id,
                                Preco_Unitario = curPrice,
                                Quantia_Usada = curAmount
                            };

                            db.Ingrediente_Receita.Add(bridgeInfo);
                            await UpdateProducts(currentRecipe);
                        }

                        await db.SaveChangesAsync();
                    }

                    MessageBox.Show("Receita atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GC.Collect();
                    Close();
                }
                else
                {
                    MessageBox.Show("Defina um nome para a receita!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento btnSave -> RecipeEdit\n" + ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task UpdateProducts(Receita affectedRecipe)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var productsAffected = await db.Produto.Include(x => x.Receita).Where(z => z.Receita == affectedRecipe).ToListAsync();

                    productsAffected.ForEach(x => x.Profit = x.Price - affectedRecipe.Cost);

                    await db.SaveChangesAsync();
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função UpdateProducts -> RecipeEdit\n" + e.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private decimal GetUnitPrice(string ing, decimal quantidade_utilizada)
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
        public decimal GetAmountByPrice(string ing, decimal price)
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

                        response = (price * quantidade_total) / preco_total;
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

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private async Task GetIngredients()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    flowPanel.Controls.Clear();

                    foreach (var ingredient in db.Ingrediente.ToList())
                    {
                        CheckBox b = new CheckBox
                        {
                            Name = ingredient.Name,
                            Text = ingredient.Name,
                            AutoSize = true,
                        };

                        b.Checked = usedIngredients.Select(y => y.Item1.Id).Contains(ingredient.Id);
                        b.CheckedChanged += (sender, e) => CheckBox_CheckedChanged(b, false);

                        CheckBox_CheckedChanged(b, true);

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
        private async void CheckBox_CheckedChanged(CheckBox cb, bool method)
        {
            try
            {
                _ = cb.Checked ? Checked(cb, method) : Unchecked(cb);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro no evento CheckedChange -> Receitas\n" + e.Message, "ERRO");
            }
        }
        private async Task Checked(CheckBox cb, bool manual)
        {
            rtbAtual.Text += (cb.Name + "+").Trim();

            using (var db = new ApplicationDbContext())
            {
                allIngredients = db.Ingrediente.ToList();

                foreach (var ingredient in allIngredients)
                {
                    if (cb.Name.Equals(ingredient.Name))
                    {
                        quantify = new Quantify();
                        _ = manual ? DialogResult.Cancel : quantify.ShowDialog();

                        decimal quantidade_utilizada = quantify.quantidadeUtilizada == 0 ? usedIngredients.Where(x => x.Item1.Name == cb.Name).FirstOrDefault().Item2 : quantify.quantidadeUtilizada;

                        if (usedIngredients.Select(x => x.Item1).Where(z => z.Id == ingredient.Id).FirstOrDefault() == null)
                            usedIngredients.Add(new Tuple<Ingrediente, decimal>(ingredient, GetUnitPrice(cb.Name, quantidade_utilizada)));

                        totalCost += quantify.quantidadeUtilizada == 0 ? quantidade_utilizada : (ingredient.Price * quantidade_utilizada) / ingredient.Quantia_Total;
                        lblCost.Text = totalCost.ToString("c");

                        Update();

                        break;
                    }
                }
            }
        }
        private async Task Unchecked(CheckBox cb)
        {
            rtbAtual.Text = rtbAtual.Text.Replace(cb.Name + "+", "").Trim();

            using (var db = new ApplicationDbContext())
            {
                foreach (var ingredient in allIngredients)
                {
                    if (cb.Name.Equals(ingredient.Name))
                    {
                        if (usedIngredients.Select(x => x.Item1).Where(z => z.Name == cb.Name).FirstOrDefault() != null)
                        {
                            decimal quantidade_utilizada = usedIngredients.Where(x => x.Item1.Name == cb.Name).FirstOrDefault().Item2;
                            usedIngredients.Remove(usedIngredients.Where(x => x.Item1.Name == cb.Name).FirstOrDefault());

                            totalCost -= quantidade_utilizada;
                            lblCost.Text = totalCost.ToString("c");

                            Update();

                            break;
                        }
                    }
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}