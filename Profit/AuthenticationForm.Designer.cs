namespace Profit
{
    partial class AuthenticationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.tbKey = new ns1.BunifuMetroTextbox();
            this.tbName = new ns1.BunifuMetroTextbox();
            this.btnConnect = new ns1.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkBuy = new System.Windows.Forms.LinkLabel();
            this.lblClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 28;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tbKey
            // 
            this.tbKey.BorderColorFocused = System.Drawing.Color.LightGray;
            this.tbKey.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbKey.BorderColorMouseHover = System.Drawing.Color.LightGray;
            this.tbKey.BorderThickness = 3;
            this.tbKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbKey.isPassword = false;
            this.tbKey.Location = new System.Drawing.Point(12, 167);
            this.tbKey.Margin = new System.Windows.Forms.Padding(4);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(433, 50);
            this.tbKey.TabIndex = 0;
            this.tbKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKey_KeyDown);
            // 
            // tbName
            // 
            this.tbName.BorderColorFocused = System.Drawing.Color.LightGray;
            this.tbName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbName.BorderColorMouseHover = System.Drawing.Color.LightGray;
            this.tbName.BorderThickness = 3;
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbName.isPassword = false;
            this.tbName.Location = new System.Drawing.Point(12, 93);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(433, 50);
            this.tbName.TabIndex = 0;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnConnect.BackColor = System.Drawing.Color.DimGray;
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnect.BorderRadius = 0;
            this.btnConnect.ButtonText = "Conectar";
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.DisabledColor = System.Drawing.Color.Gray;
            this.btnConnect.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConnect.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnConnect.Iconimage")));
            this.btnConnect.Iconimage_right = null;
            this.btnConnect.Iconimage_right_Selected = null;
            this.btnConnect.Iconimage_Selected = null;
            this.btnConnect.IconMarginLeft = 0;
            this.btnConnect.IconMarginRight = 0;
            this.btnConnect.IconRightVisible = true;
            this.btnConnect.IconRightZoom = 0D;
            this.btnConnect.IconVisible = true;
            this.btnConnect.IconZoom = 90D;
            this.btnConnect.IsTab = false;
            this.btnConnect.Location = new System.Drawing.Point(-7, 254);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Normalcolor = System.Drawing.Color.DimGray;
            this.btnConnect.OnHovercolor = System.Drawing.Color.LightGray;
            this.btnConnect.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConnect.selected = false;
            this.btnConnect.Size = new System.Drawing.Size(473, 79);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Textcolor = System.Drawing.Color.White;
            this.btnConnect.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Autenticação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuário";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Não é cadastrado?";
            // 
            // linkBuy
            // 
            this.linkBuy.AutoSize = true;
            this.linkBuy.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.linkBuy.Location = new System.Drawing.Point(230, 225);
            this.linkBuy.Name = "linkBuy";
            this.linkBuy.Size = new System.Drawing.Size(152, 19);
            this.linkBuy.TabIndex = 4;
            this.linkBuy.TabStop = true;
            this.linkBuy.Text = "Compre sua chave!";
            this.linkBuy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBuy_LinkClicked);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblClose.Location = new System.Drawing.Point(428, 7);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(24, 24);
            this.lblClose.TabIndex = 5;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 333);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.linkBuy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autenticação";
            this.Load += new System.EventHandler(this.AuthenticationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuElipse bunifuElipse1;
        private ns1.BunifuMetroTextbox tbKey;
        private ns1.BunifuMetroTextbox tbName;
        private System.Windows.Forms.Label label1;
        private ns1.BunifuFlatButton btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkBuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblClose;
    }
}