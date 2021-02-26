namespace Profit
{
    partial class ObservationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObservationsForm));
            this.flowLayoutRemove = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNomeProduto = new System.Windows.Forms.TextBox();
            this.tbTotalGasto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTaxa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDesconto = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutRemove
            // 
            this.flowLayoutRemove.AutoScroll = true;
            this.flowLayoutRemove.AutoScrollMargin = new System.Drawing.Size(230, 0);
            this.flowLayoutRemove.AutoSize = true;
            this.flowLayoutRemove.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutRemove.Location = new System.Drawing.Point(9, 138);
            this.flowLayoutRemove.MaximumSize = new System.Drawing.Size(268, 150);
            this.flowLayoutRemove.Name = "flowLayoutRemove";
            this.flowLayoutRemove.Size = new System.Drawing.Size(268, 130);
            this.flowLayoutRemove.TabIndex = 0;
            // 
            // flowLayoutAdd
            // 
            this.flowLayoutAdd.AutoScroll = true;
            this.flowLayoutAdd.AutoScrollMargin = new System.Drawing.Size(230, 0);
            this.flowLayoutAdd.AutoSize = true;
            this.flowLayoutAdd.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutAdd.Location = new System.Drawing.Point(286, 138);
            this.flowLayoutAdd.MaximumSize = new System.Drawing.Size(268, 150);
            this.flowLayoutAdd.Name = "flowLayoutAdd";
            this.flowLayoutAdd.Size = new System.Drawing.Size(268, 130);
            this.flowLayoutAdd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Marque para remover";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Marque para adicionar";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Salmon;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::Profit.Properties.Resources.error__1_;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.Location = new System.Drawing.Point(0, 394);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(563, 41);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = " Voltar";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Produto Atual";
            this.toolTip1.SetToolTip(this.label4, "Produto atual sendo editado");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total Gasto";
            this.toolTip1.SetToolTip(this.label5, "Total gasto para o produto atual");
            // 
            // tbNomeProduto
            // 
            this.tbNomeProduto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNomeProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNomeProduto.Enabled = false;
            this.tbNomeProduto.Location = new System.Drawing.Point(119, 290);
            this.tbNomeProduto.Name = "tbNomeProduto";
            this.tbNomeProduto.ReadOnly = true;
            this.tbNomeProduto.Size = new System.Drawing.Size(158, 19);
            this.tbNomeProduto.TabIndex = 0;
            // 
            // tbTotalGasto
            // 
            this.tbTotalGasto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTotalGasto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotalGasto.Enabled = false;
            this.tbTotalGasto.Location = new System.Drawing.Point(119, 312);
            this.tbTotalGasto.Name = "tbTotalGasto";
            this.tbTotalGasto.ReadOnly = true;
            this.tbTotalGasto.Size = new System.Drawing.Size(158, 19);
            this.tbTotalGasto.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Adicionar Taxa";
            this.toolTip1.SetToolTip(this.label6, "Opcional. Coloque algum valor em real ao lado para adicionar no pedido.");
            // 
            // tbTaxa
            // 
            this.tbTaxa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTaxa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTaxa.Location = new System.Drawing.Point(407, 290);
            this.tbTaxa.Name = "tbTaxa";
            this.tbTaxa.Size = new System.Drawing.Size(147, 19);
            this.tbTaxa.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbTaxa, "Atalho: Ctrl+T");
            this.tbTaxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbTaxa_KeyDown);
            this.tbTaxa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbTaxa_KeyPress);
            this.tbTaxa.Leave += new System.EventHandler(this.TbTaxa_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "Dar Desconto";
            this.toolTip1.SetToolTip(this.label7, "Opcional. Coloque algum valor em real ao lado para retirar do pedido.");
            // 
            // tbDesconto
            // 
            this.tbDesconto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDesconto.Location = new System.Drawing.Point(407, 312);
            this.tbDesconto.Name = "tbDesconto";
            this.tbDesconto.Size = new System.Drawing.Size(147, 19);
            this.tbDesconto.TabIndex = 3;
            this.tbDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbDesconto_KeyDown);
            this.tbDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbDesconto_KeyPress);
            this.tbDesconto.Leave += new System.EventHandler(this.TbDesconto_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 109);
            this.panel2.TabIndex = 40;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label13.Location = new System.Drawing.Point(102, 68);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(352, 19);
            this.label13.TabIndex = 16;
            this.label13.Text = "Retire, adicione, cobre taxas ou dê descontos";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label14.Location = new System.Drawing.Point(99, 13);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(362, 63);
            this.label14.TabIndex = 3;
            this.label14.Text = "Observações";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Informação";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox4.Location = new System.Drawing.Point(407, 329);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(147, 2);
            this.pictureBox4.TabIndex = 42;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Location = new System.Drawing.Point(119, 329);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 2);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Location = new System.Drawing.Point(407, 307);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(147, 2);
            this.pictureBox3.TabIndex = 41;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(119, 307);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 2);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Image = global::Profit.Properties.Resources.confirmation;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.Location = new System.Drawing.Point(0, 336);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(563, 61);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = " Confirmar";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // animGone
            // 
            this.animGone.Interval = 1;
            this.animGone.Tick += new System.EventHandler(this.AnimGone_Tick);
            // 
            // animOpen
            // 
            this.animOpen.Interval = 1;
            this.animOpen.Tick += new System.EventHandler(this.AnimOpen_Tick);
            // 
            // Observations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(563, 435);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbTotalGasto);
            this.Controls.Add(this.tbDesconto);
            this.Controls.Add(this.tbTaxa);
            this.Controls.Add(this.tbNomeProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.flowLayoutAdd);
            this.Controls.Add(this.flowLayoutRemove);
            this.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Observations";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H. Production - Gerência de Lucro  | Cadastro de Ingredientes | Painel de Vendas";
            this.Load += new System.EventHandler(this.Observations_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutRemove;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutAdd;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNomeProduto;
        private System.Windows.Forms.TextBox tbTotalGasto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTaxa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDesconto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer animGone;
        private System.Windows.Forms.Timer animOpen;
    }
}