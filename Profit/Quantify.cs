using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class Quantify : Form
    {      
        public decimal quantidadeUtilizada = 0;
        public Quantify()
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza do valor?", "Salvando...", MessageBoxButtons.YesNo))
            {
                if (tbQnt.Text.Trim() != string.Empty)
                {
                    quantidadeUtilizada = Convert.ToDecimal(tbQnt.Text);
                    FormClosing -= new FormClosingEventHandler(Quantify_FormClosing);
                    Close();
                }
                else
                {
                    AutoClosingMessageBox.Show("Esse campo não pode ser vazio!", "ERRO", 1000);
                    tbQnt.Focus();
                }                    
            }
            else
            {
                tbQnt.Clear();
                tbQnt.Focus();
            }
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
        private void TbQnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }
        private void Quantify_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Quantify_Load(object sender, EventArgs e)
        {
            tbQnt.Clear();
            tbQnt.Focus();
        }
    }
}