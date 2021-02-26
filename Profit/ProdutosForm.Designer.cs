namespace Profit
{
    partial class ProdutosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutosForm));
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.animGone = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(433, 128);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(397, 234);
            this.dgvProdutos.TabIndex = 18;
            this.dgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProdutos_CellClick);
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProdutos_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Receita utilizada para o produto";
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.ForeColor = System.Drawing.Color.Black;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(15, 335);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(396, 27);
            this.comboBox.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(-2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 100);
            this.panel2.TabIndex = 29;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label4.Location = new System.Drawing.Point(78, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(662, 63);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gerenciador de Produtos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label6.Location = new System.Drawing.Point(171, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(493, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cadastre abaixo todos os produtos finais usados para a venda";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Location = new System.Drawing.Point(15, 270);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(396, 2);
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(15, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 2);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbName.Font = new System.Drawing.Font("Caviar Dreams", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(15, 151);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(394, 25);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Preço do produto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nome do produto";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Font = new System.Drawing.Font("Caviar Dreams", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(15, 243);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(396, 25);
            this.tbPrice.TabIndex = 2;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPrice_KeyPress);
            this.tbPrice.Leave += new System.EventHandler(this.TbPrice_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(558, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Dados Cadastrados";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Location = new System.Drawing.Point(-2, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 161);
            this.panel1.TabIndex = 37;
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
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "    Salvar Novo Produto";
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
            this.btnBack.TabIndex = 7;
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
            this.btnEdit.Size = new System.Drawing.Size(251, 99);
            this.btnEdit.TabIndex = 5;
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
            this.btnExcluir.Size = new System.Drawing.Size(237, 98);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = " Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // animOpen
            // 
            this.animOpen.Interval = 1;
            this.animOpen.Tick += new System.EventHandler(this.AnimOpen_Tick);
            // 
            // animGone
            // 
            this.animGone.Interval = 1;
            this.animGone.Tick += new System.EventHandler(this.AnimGone_Tick);
            // 
            // Produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(849, 532);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPrice);
            this.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Produtos";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H. Production - Gerência de Lucro | Cadastro de Produtos";
            this.Load += new System.EventHandler(this.Produtos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.Timer animGone;
    }
}