using Profit.Data;
using Profit.Models;
using Profit.Models.Db.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class SelectState : Form
    {
        Status state;
        int id;
        public SelectState(Status state, int id)
        {
            InitializeComponent();
            this.state = state;
            this.id = id;
        }

        #region FormMovement
        private bool mouseDown;
        private Point lastLocation;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D1)
            {
                rbConcluido.Checked = true;
                return true;
            }
            else if (keyData == Keys.D2)
            {
                rbPendente.Checked = true;
                return true;
            }
            else if (keyData == Keys.D3)
            {
                rbCancelado.Checked = true;
                return true;
            }
            else if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                btnConfirm.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectState_Load(object sender, EventArgs e)
        {
            rbConcluido.Checked = state.Equals(Status.Concluido) ? true : false;
            rbPendente.Checked = state.Equals(Status.Pendente) ? true : false;
            rbCancelado.Checked = state.Equals(Status.Cancelado) ? true : false;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var curSelling = db.Venda.Where(x => x.Id == id).FirstOrDefault();

                    if (curSelling != null)
                    {
                        curSelling.Status = rbConcluido.Checked ? Status.Concluido : rbPendente.Checked ? Status.Pendente : Status.Cancelado;
                    }

                    await db.SaveChangesAsync();
                }

                GC.Collect();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento btnConfirm -> SelectState\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
