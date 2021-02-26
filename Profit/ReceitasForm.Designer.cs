namespace Profit
{
    partial class ReceitasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceitasForm));
            this.label4 = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbAtual = new System.Windows.Forms.RichTextBox();
            this.dgvReceitas = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceitas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label4.Location = new System.Drawing.Point(83, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(653, 63);
            this.label4.TabIndex = 13;
            this.label4.Text = "Gerenciador de Receitas";
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.AutoScrollMargin = new System.Drawing.Size(650, 0);
            this.flowPanel.AutoSize = true;
            this.flowPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.flowPanel.Location = new System.Drawing.Point(10, 154);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flowPanel.MaximumSize = new System.Drawing.Size(823, 60);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(823, 60);
            this.flowPanel.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label1.Location = new System.Drawing.Point(153, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cadastre abaixo a receita usada em algum de seus produtos finais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Marque a seguir cada ingrediente que será utlizado nesta receita:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 224);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.MaximumSize = new System.Drawing.Size(0, 679);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nomeie a receita atual:";
            // 
            // rtbAtual
            // 
            this.rtbAtual.BackColor = System.Drawing.Color.Gainsboro;
            this.rtbAtual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAtual.Enabled = false;
            this.rtbAtual.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.rtbAtual.Location = new System.Drawing.Point(10, 257);
            this.rtbAtual.Margin = new System.Windows.Forms.Padding(4);
            this.rtbAtual.Name = "rtbAtual";
            this.rtbAtual.Size = new System.Drawing.Size(724, 57);
            this.rtbAtual.TabIndex = 17;
            this.rtbAtual.Text = "";
            // 
            // dgvReceitas
            // 
            this.dgvReceitas.AllowUserToAddRows = false;
            this.dgvReceitas.AllowUserToDeleteRows = false;
            this.dgvReceitas.AllowUserToResizeColumns = false;
            this.dgvReceitas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReceitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReceitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceitas.Location = new System.Drawing.Point(0, 327);
            this.dgvReceitas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReceitas.MultiSelect = false;
            this.dgvReceitas.Name = "dgvReceitas";
            this.dgvReceitas.ReadOnly = true;
            this.dgvReceitas.RowHeadersVisible = false;
            this.dgvReceitas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvReceitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceitas.Size = new System.Drawing.Size(852, 220);
            this.dgvReceitas.TabIndex = 18;
            this.dgvReceitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvReceitas_CellClick);
            this.dgvReceitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvReceitas_CellClick);
            this.dgvReceitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceitas_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label5.Location = new System.Drawing.Point(767, 265);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Custo";
            this.toolTip.SetToolTip(this.label5, "Clique para reiniciar o custo total");
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            this.label5.MouseEnter += new System.EventHandler(this.Label5_MouseHover);
            this.label5.MouseLeave += new System.EventHandler(this.Label5_MouseLeave);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.lblCost.Location = new System.Drawing.Point(759, 288);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(65, 19);
            this.lblCost.TabIndex = 24;
            this.lblCost.Text = "R$ 0,00";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.ReshowDelay = 40;
            this.toolTip.ToolTipTitle = "Informação!";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Profit.Properties.Resources.refresh;
            this.btnEdit.Location = new System.Drawing.Point(368, -1);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(251, 99);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "   Editar";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnEdit, "Será implementado futuramente");
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbName.Location = new System.Drawing.Point(187, 225);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(646, 19);
            this.tbName.TabIndex = 25;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbName_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Location = new System.Drawing.Point(0, 548);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 161);
            this.panel1.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Profit.Properties.Resources.thumb_drive;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(370, 98);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "    Salvar Nova Receita";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Salmon;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::Profit.Properties.Resources.previous__1_;
            this.btnBack.Location = new System.Drawing.Point(0, 99);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(852, 62);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Voltar";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::Profit.Properties.Resources.delete;
            this.btnExcluir.Location = new System.Drawing.Point(615, 0);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(237, 98);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = " Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 120);
            this.panel2.TabIndex = 27;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // animOpen
            // 
            this.animOpen.Interval = 2;
            this.animOpen.Tick += new System.EventHandler(this.AnimOpen_Tick);
            // 
            // animGone
            // 
            this.animGone.Interval = 1;
            this.animGone.Tick += new System.EventHandler(this.AnimGone_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(187, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(646, 2);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // ReceitasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(849, 709);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvReceitas);
            this.Controls.Add(this.rtbAtual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceitasForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H. Production - Gerência de Lucro | Cadastro de Receitas";
            this.Load += new System.EventHandler(this.ReceitasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceitas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbAtual;
        private System.Windows.Forms.DataGridView dgvReceitas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.Timer animGone;
    }
}