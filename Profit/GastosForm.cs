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
    public partial class GastosForm : Form
    {
        int id = -1, ableToEdit = 0;
        public GastosForm()
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
        public void FormatColumns()
        {
            dgvGastos.Columns[0].Visible = false;
            dgvGastos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGastos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvGastos.Columns[2].DefaultCellStyle.Format = "c";

            dgvGastos.Columns[1].HeaderText = "Nome";
            dgvGastos.Columns[2].HeaderText = "Preço";

            for (int i = 0; i < dgvGastos.RowCount; i++)
                if (i % 2 == 0)
                    dgvGastos.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                else
                    dgvGastos.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvGastos.ClearSelection();
        }
        private async Task FillGrid()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    dgvGastos.DataSource = await db.Gasto.ToListAsync();
                    FormatColumns();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FillGrid -> Gastos\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty && tbPrice.Text != string.Empty)
                Insert();
            else
                MessageBox.Show("Há campos vazios!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async Task Insert()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Gasto.Add(new Gasto
                    {
                        Nome = tbName.Text.Trim(),
                        Cost = Convert.ToDecimal(tbPrice.Text.Replace("R$ ", "").Trim()),                        
                    });

                    await db.SaveChangesAsync();

                    await FillGrid();
                    AutoClosingMessageBox.Show("Dados salvos com sucesso", "Sucesso", 500);
                    tbName.Clear();
                    tbPrice.Clear();
                    tbName.Focus();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Insert -> Gastos\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
        private async Task Delete()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    foreach (DataGridViewRow row in dgvGastos.SelectedRows)
                    {
                        int id = (int)row.Cells["id"].Value;
                        db.Gasto.Remove(db.Gasto.Find(id));
                    }

                    await db.SaveChangesAsync();
                }

                await FillGrid();
                tbName.Clear();
                tbPrice.Clear();
                tbName.Focus();

                AutoClosingMessageBox.Show("Dados deletados com sucesso!", "Sucesso!", 500);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Delete -> Gastos\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async new Task Update()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    Gasto newSpent = new Gasto
                    {
                        Id = id,
                        Nome = tbName.Text.Trim(),
                        Cost = Convert.ToDecimal(tbPrice.Text.Replace("R$ ", "").Trim())
                    };

                    db.Gasto.Update(newSpent);
                    await db.SaveChangesAsync();
                }

                await FillGrid();

                AutoClosingMessageBox.Show("Dados atualizados com sucesso", "Sucesso", 500);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Update -> Gastos\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Gastos_Load(object sender, EventArgs e)
        {
            animOpen.Start();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            animGone.Start();
        }
        private void dgvGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgvGastos.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {
                
            }            
        }
        private void dgvGastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgvGastos.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {
                
            }
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvGastos.SelectedRows.Count > 0)
                await Delete();
            else
                AutoClosingMessageBox.Show("Selecione uma linha para excluir!", "ERRO", 500);
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
                Close();
            }
        }
        private async void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.1;
            else
            {
                animOpen.Stop();
                await FillGrid();
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGastos.SelectedRows.Count > 0)
            {
                if (ableToEdit <= 0)
                {
                    dgvGastos.Enabled = false;
                    btnSave.Enabled = false;                    
                    btnExcluir.Enabled = false;                   
                    btnEdit.Text = "Salvar!";
                    tbName.Text = dgvGastos.SelectedRows[0].Cells[1].Value.ToString();
                    tbPrice.Text = Convert.ToDouble(dgvGastos.SelectedRows[0].Cells[2].Value).ToString("c");
                    tbName.Focus();                        
                }

                ableToEdit++;

                if (ableToEdit > 1)
                {
                    if (tbName.Text.Trim() != string.Empty && tbPrice.Text.Trim() != string.Empty)
                    {
                        await Update();

                        dgvGastos.Enabled = true;
                        btnSave.Enabled = true;                        
                        btnExcluir.Enabled = true;                        
                        btnEdit.Text = "   Editar";
                        tbName.Text = "";
                        tbPrice.Text = "";
                        tbName.Focus();
                        ableToEdit = 0;
                    }
                    else
                        AutoClosingMessageBox.Show("Há campos vazios!", "ERRO", 2000);
                }                
            }
            else
                AutoClosingMessageBox.Show("Selecione uma linha para editar!", "Erro", 500);
        }
        private void TbPrice_Leave(object sender, EventArgs e)
        {
            if (tbPrice.Text.Trim() != string.Empty)
                tbPrice.Text = Convert.ToDouble(tbPrice.Text.Replace("R$ ", "").Trim()).ToString("c");
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.PerformClick();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnEdit.PerformClick();
                }
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