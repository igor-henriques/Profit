namespace Profit
{
    partial class IngredienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngredienteForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Digite o nome do ingrediente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Digite o preço do ingrediente";
            // 
            // tbQnt
            // 
            this.tbQnt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbQnt.Font = new System.Drawing.Font("Caviar Dreams", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQnt.Location = new System.Drawing.Point(16, 327);
            this.tbQnt.Margin = new System.Windows.Forms.Padding(4);
            this.tbQnt.Name = "tbQnt";
            this.tbQnt.Size = new System.Drawing.Size(394, 25);
            this.tbQnt.TabIndex = 2;
            this.tbQnt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbQnt_KeyDown);
            this.tbQnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbQnt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 303);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Digite a quantidade total do ingrediente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label4.Location = new System.Drawing.Point(50, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(743, 63);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gerenciador de Ingredientes";
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.AllowUserToAddRows = false;
            this.dgvIngredientes.AllowUserToDeleteRows = false;
            this.dgvIngredientes.AllowUserToResizeColumns = false;
            this.dgvIngredientes.AllowUserToResizeRows = false;
            this.dgvIngredientes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Location = new System.Drawing.Point(436, 130);
            this.dgvIngredientes.Margin = new System.Windows.Forms.Padding(4);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.ReadOnly = true;
            this.dgvIngredientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvIngredientes.RowHeadersVisible = false;
            this.dgvIngredientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientes.Size = new System.Drawing.Size(397, 285);
            this.dgvIngredientes.TabIndex = 7;
            this.dgvIngredientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIngredientes_CellContentClick);
            this.dgvIngredientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIngredientes_CellContentClick);
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Font = new System.Drawing.Font("Caviar Dreams", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(17, 241);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(396, 25);
            this.tbPrice.TabIndex = 1;
            this.tbPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbPrice_KeyDown);
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPrice_KeyPress);
            this.tbPrice.Leave += new System.EventHandler(this.TbPrice_Leave);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbName.Font = new System.Drawing.Font("Caviar Dreams", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(17, 153);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(394, 25);
            this.tbName.TabIndex = 0;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbName_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(-2, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 161);
            this.panel1.TabIndex = 8;
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
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Voltar";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
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
            this.btnEdit.Size = new System.Drawing.Size(251, 102);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "   Editar";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
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
            this.btnExcluir.Size = new System.Drawing.Size(237, 101);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = " Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
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
            this.btnSave.Size = new System.Drawing.Size(370, 101);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "    Salvar Novo Ingrediente";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(17, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 2);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 100);
            this.panel2.TabIndex = 28;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label6.Location = new System.Drawing.Point(178, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(484, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cadastre abaixo todos ingredientes usados em todos produtos";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Location = new System.Drawing.Point(17, 268);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(396, 2);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Location = new System.Drawing.Point(17, 354);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(396, 2);
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(548, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dados Cadastrados";
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
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox4.Location = new System.Drawing.Point(113, 412);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(300, 2);
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Caviar Dreams", 14F);
            this.label9.Location = new System.Drawing.Point(14, 390);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 22);
            this.label9.TabIndex = 35;
            this.label9.Text = "Pesquisar:";
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Caviar Dreams", 15.75F);
            this.tbSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbSearch.Location = new System.Drawing.Point(113, 389);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PromptChar = ' ';
            this.tbSearch.Size = new System.Drawing.Size(300, 25);
            this.tbSearch.TabIndex = 50;
            this.tbSearch.Text = "ex: \'\'PRESUNTO\'\'";
            this.tbSearch.ValidatingType = typeof(int);
            this.tbSearch.Enter += new System.EventHandler(this.TbSearch_Enter);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbSearch_KeyUp);
            this.tbSearch.Leave += new System.EventHandler(this.TbSearch_Leave);
            // 
            // IngredienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(849, 585);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgvIngredientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbQnt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IngredienteForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H. Production - Gerência de Lucro  | Cadastro de Ingredientes";
            this.Load += new System.EventHandler(this.IngredienteForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IngredienteForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer animGone;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbSearch;
    }
}