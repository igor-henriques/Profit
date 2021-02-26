using Profit.Data;
using Profit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Profit.Models.Db;

namespace Profit
{
    public partial class ObservationsForm : Form
    {
        Shortcut shortcut = new Shortcut();
        VendasForm vendas;
        public List<CheckBox> checkBoxesAdd = new List<CheckBox>();
        public List<CheckBox> checkBoxesRemove = new List<CheckBox>();
        public string thisName, observation;
        public decimal sum = 0, taxa = 0, desconto = 0;
        int index;
        bool alreadyEdit = false;
        public bool houveAlteracao = false;
        public ObservationsForm(string name, int indexList)
        {
            InitializeComponent();
            thisName = name;
            tbNomeProduto.Text = thisName;
            index = indexList;

            if (name.Contains("*"))
                alreadyEdit = true;

            vendas = new VendasForm(shortcut, false);

            tbDesconto.Text = 0.ToString("c");
            tbTaxa.Text = 0.ToString("c");
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
        private async Task<Receita> GetRecipeByName(string productName)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Produto.Include(z => z.Receita).Where(x => x.Name == productName).FirstOrDefault().Receita;                
            }
        }
        private async Task LoadCheckboxes()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var recipe = await GetRecipeByName(thisName);

                    flowLayoutRemove.Controls.Clear();
                    flowLayoutAdd.Controls.Clear();

                    tbTotalGasto.Text = db.Receita.Where(x => x.Id == recipe.Id).FirstOrDefault().Cost.ToString("c");

                    var ingredientsByRecipe = await db.Ingrediente_Receita.Include(z => z.Receita).Include(a => a.Ingrediente).Where(x => x.Id_Receita == recipe.Id).ToListAsync();

                    foreach (var ingredient in ingredientsByRecipe)
                    {
                        CheckBox b = new CheckBox();
                        b.Name = ingredient.Ingrediente.Name + "Add";
                        b.Text = ingredient.Ingrediente.Name;
                        b.AutoSize = true;
                        b.CheckedChanged += (sender, e) => CheckBoxAdd_CheckedChanged(b);
                        checkBoxesAdd.Add(b);

                        CheckBox c = new CheckBox();
                        c.Name = ingredient.Ingrediente.Name + "Remove";
                        c.Text = ingredient.Ingrediente.Name;
                        c.AutoSize = true;
                        c.Checked = true;
                        c.CheckedChanged += (sender, e) => CheckBoxRemove_CheckedChanged(c);
                        checkBoxesRemove.Add(c);

                        flowLayoutRemove.Controls.Add(c);
                        flowLayoutAdd.Controls.Add(b);
                    }

                }

                if (alreadyEdit)
                {
                    int max = 0, min = 1;
                    var lines = File.ReadAllLines(@"Dados\Temporario\OrderN" + index + ".txt");

                    #region First Flow Fill
                    for (int j = 0; j < lines.Length; j++)
                        if (lines[j] == "flow2:")
                        {
                            max = j - 1;
                            break;
                        }

                    for (int i = 0; i < checkBoxesRemove.Count; i++)
                    {
                        if (i <= max)
                            if (lines[i + 1] == 1.ToString())
                                checkBoxesRemove[i].Checked = true;
                            else
                                checkBoxesRemove[i].Checked = false;
                        else
                            break;
                    }
                    #endregion
                    #region Second Flow Fill
                    for (int j = 0; j < lines.Length; j++)
                        if (lines[j].Contains("produto:"))
                        {
                            min = max + 2;
                            max = j - 1;
                            break;
                        }

                    for (int b = 0; b < checkBoxesAdd.Count; b++)
                    {
                        if (b + min <= max)
                            if (lines[b + min] == 1.ToString())
                                checkBoxesAdd[b].Checked = true;
                            else
                                checkBoxesAdd[b].Checked = false;
                        else
                            break;
                    }
                    #endregion

                    for (int k = 0; k < lines.Length; k++)
                    {
                        if (lines[k].Contains("produto:"))
                            tbNomeProduto.Text = lines[k].Replace("produto:", "");
                        else if (lines[k].Contains("totalGasto:"))
                            tbTotalGasto.Text = lines[k].Replace("totalGasto:", "");
                        else if (lines[k].Contains("taxa:"))
                            tbTaxa.Text = lines[k].Replace("taxa:", "");
                        else if (lines[k].Contains("desconto:"))
                            tbDesconto.Text = lines[k].Replace("desconto:", "");
                    }

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Erro na função LoadCheckboxes -> Observations\n" + f.ToString());
            }
        }
        private async void Observations_Load(object sender, EventArgs e)
        {
            await LoadCheckboxes();
            animOpen.Start();
        }
        private decimal ConvertText(string text) => Convert.ToDecimal(text.Replace("R$", "").Trim());
        private async void CheckBoxAdd_CheckedChanged(CheckBox cb)
        {
            if (cb.Checked)
            {
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var ingredientByRecipe = await db.Ingrediente_Receita.Where(x => x.Ingrediente.Name == cb.Text).ToListAsync();

                        tbTotalGasto.Text = (ConvertText(tbTotalGasto.Text) + decimal.Round(ingredientByRecipe.Sum(x => x.Preco_Unitario))).ToString("c");
                    }

                }
                catch (Exception f)
                {
                    MessageBox.Show("Erro no 1º estágio do evento CheckBoxAdd -> Observations\n" + f.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (!cb.Checked)
            {

                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var ingredientByRecipe = await db.Ingrediente_Receita.Where(x => x.Ingrediente.Name == cb.Text).ToListAsync();

                        tbTotalGasto.Text = (ConvertText(tbTotalGasto.Text) - decimal.Round(ingredientByRecipe.Sum(x => x.Preco_Unitario))).ToString("c");
                    }

                }
                catch (Exception f)
                {
                    MessageBox.Show("Erro no 2º estágio do evento CheckBoxAdd -> Observations\n" + f.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private async void CheckBoxRemove_CheckedChanged(CheckBox cb)
        {
            if (cb.Checked)
            {

                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var ingredientByRecipe = await db.Ingrediente_Receita.Where(x => x.Ingrediente.Name == cb.Text).ToListAsync();

                        tbTotalGasto.Text = (ConvertText(tbTotalGasto.Text) + decimal.Round(ingredientByRecipe.Sum(x => x.Preco_Unitario))).ToString("c");
                    }
                }
                catch (Exception f)
                {
                    MessageBox.Show("Erro no 1º estágio do evento CheckBoxRemove -> Observations\n" + f.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (!cb.Checked)
            {

                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var ingredientByRecipe = await db.Ingrediente_Receita.Where(x => x.Ingrediente.Name == cb.Text).ToListAsync();

                        tbTotalGasto.Text = (ConvertText(tbTotalGasto.Text) - decimal.Round(ingredientByRecipe.Sum(x => x.Preco_Unitario))).ToString("c");
                    }                   
                }
                catch (Exception f)
                {
                    MessageBox.Show("Erro no 2º estágio do evento CheckBoxRemove -> Observations\n" + f.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            animGone.Start();
        }
        private void TbTaxa_Leave(object sender, EventArgs e)
        {
            if (tbTaxa.Text.Trim() != "R$ 0,00")
                tbTaxa.Text = Convert.ToDouble(tbTaxa.Text.Replace("R$", string.Empty).Trim()).ToString("c");
        }
        private void TbDesconto_Leave(object sender, EventArgs e)
        {
            if (tbDesconto.Text.Trim() != "R$ 0,00")
                tbDesconto.Text = Convert.ToDouble(tbDesconto.Text.Replace("R$", string.Empty).Trim()).ToString("c");
        }
        private void TbTaxa_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != ',' || !Decimal.TryParse(tbTaxa.Text + ch, out x))
            {
                e.Handled = true;
            }
        }
        private void TbDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != ',' || !Decimal.TryParse(tbDesconto.Text + ch, out x))
            {
                e.Handled = true;
            }
        }
        private void TbTaxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbDesconto.Focus();
        }
        private void TbDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirm.PerformClick();
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
        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.1;
            else
                animOpen.Stop();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnBack.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Enter))
            {
                btnConfirm.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.T))
            {
                tbTaxa.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbTaxa.Text.Trim() != string.Empty)
            {
                taxa = Convert.ToDecimal(tbTaxa.Text.Replace("R$ ", "").Trim());
                sum += taxa;
            }

            if (tbDesconto.Text.Trim() != string.Empty)
            {
                desconto = Convert.ToDecimal(tbDesconto.Text.Replace("R$ ", "").Trim());
                sum -= desconto;
            }

            ChecarAlteracao();

            string path = (@"Dados\Temporario\OrderN" + index + ".txt");

            if (!Directory.Exists(@"Dados\Temporario\"))
                Directory.CreateDirectory(@"Dados\Temporario\");

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("flow1:");
                for (int i = 0; i < checkBoxesRemove.Count; i++)
                    if (checkBoxesRemove[i].Checked)
                        sw.WriteLine("1");
                    else
                        sw.WriteLine("0");

                sw.WriteLine("flow2:");
                for (int i = 0; i < checkBoxesAdd.Count; i++)
                    if (checkBoxesAdd[i].Checked)
                        sw.WriteLine("1");
                    else
                        sw.WriteLine("0");

                sw.WriteLine("produto:" + tbNomeProduto.Text);
                sw.WriteLine("totalGasto:" + tbTotalGasto.Text);
                sw.WriteLine("taxa:" + tbTaxa.Text);
                sw.WriteLine("desconto:" + tbDesconto.Text);
                animGone.Start();
            }
        }
        public void ChecarAlteracao()
        {
            foreach (var item in checkBoxesAdd)
            {
                if (item.Checked || desconto > 0 || taxa > 0)
                {
                    houveAlteracao = true;
                    break;
                }
            }

            foreach (var item in checkBoxesRemove)
            {
                if (!item.Checked || desconto > 0 || taxa > 0)
                {
                    houveAlteracao = true;
                    break;
                }
            }
        }
    }
}