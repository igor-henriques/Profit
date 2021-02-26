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
    public partial class InformationsForm : Form
    {
        public InformationsForm()
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
