namespace Profit
{
    partial class ClientesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.MaskedTextBox();
            this.tbCpf = new System.Windows.Forms.MaskedTextBox();
            this.tbNumber = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBairro = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbStreet = new System.Windows.Forms.MaskedTextBox();
            this.rtbReference = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStNumber = new System.Windows.Forms.MaskedTextBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.tbSearch = new System.Windows.Forms.MaskedTextBox();
            this.rbCPF = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pbGenerate = new System.Windows.Forms.PictureBox();
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.rbTel = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerate)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "CPF*";
            this.toolTip.SetToolTip(this.label1, "Campos com * são obrigatórios");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nome do cliente*";
            this.toolTip.SetToolTip(this.label2, "Campos com * são obrigatórios");
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(25, 146);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.PromptChar = ' ';
            this.tbName.Size = new System.Drawing.Size(363, 19);
            this.tbName.TabIndex = 0;
            this.tbName.ValidatingType = typeof(int);
            // 
            // tbCpf
            // 
            this.tbCpf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCpf.Location = new System.Drawing.Point(401, 149);
            this.tbCpf.Mask = "000,000,000-00";
            this.tbCpf.Name = "tbCpf";
            this.tbCpf.Size = new System.Drawing.Size(136, 19);
            this.tbCpf.TabIndex = 1;
            // 
            // tbNumber
            // 
            this.tbNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumber.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumber.Location = new System.Drawing.Point(549, 149);
            this.tbNumber.Mask = "(99) 00000-0000";
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(151, 19);
            this.tbNumber.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(544, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Telefone*";
            this.toolTip.SetToolTip(this.label3, "Campos com * são obrigatórios");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "Bairro";
            // 
            // tbBairro
            // 
            this.tbBairro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBairro.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBairro.Location = new System.Drawing.Point(25, 192);
            this.tbBairro.Margin = new System.Windows.Forms.Padding(4);
            this.tbBairro.Name = "tbBairro";
            this.tbBairro.PromptChar = ' ';
            this.tbBairro.Size = new System.Drawing.Size(363, 19);
            this.tbBairro.TabIndex = 3;
            this.tbBairro.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(396, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Rua";
            // 
            // tbStreet
            // 
            this.tbStreet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbStreet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStreet.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStreet.Location = new System.Drawing.Point(401, 192);
            this.tbStreet.Margin = new System.Windows.Forms.Padding(4);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.PromptChar = ' ';
            this.tbStreet.Size = new System.Drawing.Size(255, 19);
            this.tbStreet.TabIndex = 4;
            this.tbStreet.ValidatingType = typeof(int);
            // 
            // rtbReference
            // 
            this.rtbReference.BackColor = System.Drawing.Color.White;
            this.rtbReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReference.Location = new System.Drawing.Point(23, 245);
            this.rtbReference.Name = "rtbReference";
            this.rtbReference.Size = new System.Drawing.Size(677, 96);
            this.rtbReference.TabIndex = 6;
            this.rtbReference.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 219);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Referência";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(664, 172);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nº";
            // 
            // tbStNumber
            // 
            this.tbStNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbStNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStNumber.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStNumber.Location = new System.Drawing.Point(668, 192);
            this.tbStNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbStNumber.Name = "tbStNumber";
            this.tbStNumber.PromptChar = ' ';
            this.tbStNumber.Size = new System.Drawing.Size(32, 19);
            this.tbStNumber.TabIndex = 5;
            this.tbStNumber.ValidatingType = typeof(int);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(0, 385);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(725, 180);
            this.dgvClientes.TabIndex = 29;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            this.dgvClientes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvClientes_CellMouseDoubleClick);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Enabled = false;
            this.tbSearch.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.DimGray;
            this.tbSearch.Location = new System.Drawing.Point(341, 355);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PromptChar = ' ';
            this.tbSearch.Size = new System.Drawing.Size(359, 19);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "Selecione uma opção ao lado para pesquisar";
            this.tbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSearch.ValidatingType = typeof(int);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbSearch_KeyUp);
            // 
            // rbCPF
            // 
            this.rbCPF.AutoSize = true;
            this.rbCPF.Location = new System.Drawing.Point(23, 352);
            this.rbCPF.Name = "rbCPF";
            this.rbCPF.Size = new System.Drawing.Size(56, 23);
            this.rbCPF.TabIndex = 30;
            this.rbCPF.TabStop = true;
            this.rbCPF.Text = "CPF";
            this.rbCPF.UseVisualStyleBackColor = true;
            this.rbCPF.CheckedChanged += new System.EventHandler(this.RbCPF_CheckedChanged);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(86, 352);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(67, 23);
            this.rbName.TabIndex = 30;
            this.rbName.TabStop = true;
            this.rbName.Text = "Nome";
            this.rbName.UseVisualStyleBackColor = true;
            this.rbName.CheckedChanged += new System.EventHandler(this.RbName_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Caviar Dreams", 14F);
            this.label9.Location = new System.Drawing.Point(247, 352);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 22);
            this.label9.TabIndex = 17;
            this.label9.Text = "Pesquisar:";
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Informação";
            // 
            // pbGenerate
            // 
            this.pbGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGenerate.Image = global::Profit.Properties.Resources.refresh_button;
            this.pbGenerate.Location = new System.Drawing.Point(441, 126);
            this.pbGenerate.Name = "pbGenerate";
            this.pbGenerate.Size = new System.Drawing.Size(19, 19);
            this.pbGenerate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGenerate.TabIndex = 31;
            this.pbGenerate.TabStop = false;
            this.toolTip.SetToolTip(this.pbGenerate, "Clique para gerar um CPF aleatório");
            this.pbGenerate.Click += new System.EventHandler(this.PbGenerate_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(-3, 565);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 161);
            this.panel1.TabIndex = 32;
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
            this.btnSave.Size = new System.Drawing.Size(349, 98);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "    Salvar Novo Cliente";
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
            this.btnBack.Size = new System.Drawing.Size(731, 62);
            this.btnBack.TabIndex = 4;
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
            this.btnEdit.Location = new System.Drawing.Point(344, -1);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(210, 99);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "   Editar";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Profit.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(552, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(179, 98);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = " Excluir";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 100);
            this.panel2.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label10.Location = new System.Drawing.Point(202, 67);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(315, 19);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cadastre e pesquise seus clientes abaixo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label4.Location = new System.Drawing.Point(144, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(441, 63);
            this.label4.TabIndex = 3;
            this.label4.Text = "Área de Clientes";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox5.Location = new System.Drawing.Point(668, 211);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 2);
            this.pictureBox5.TabIndex = 37;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox4.Location = new System.Drawing.Point(401, 211);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(255, 2);
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Location = new System.Drawing.Point(25, 211);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(363, 2);
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(25, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 2);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Location = new System.Drawing.Point(341, 374);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(359, 2);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox6.Location = new System.Drawing.Point(401, 165);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(136, 2);
            this.pictureBox6.TabIndex = 41;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox7.Location = new System.Drawing.Point(549, 165);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(151, 2);
            this.pictureBox7.TabIndex = 42;
            this.pictureBox7.TabStop = false;
            // 
            // rbTel
            // 
            this.rbTel.AutoSize = true;
            this.rbTel.Location = new System.Drawing.Point(156, 352);
            this.rbTel.Name = "rbTel";
            this.rbTel.Size = new System.Drawing.Size(87, 23);
            this.rbTel.TabIndex = 30;
            this.rbTel.TabStop = true;
            this.rbTel.Text = "Telefone";
            this.rbTel.UseVisualStyleBackColor = true;
            this.rbTel.CheckedChanged += new System.EventHandler(this.rbTel_CheckedChanged);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(725, 726);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbGenerate);
            this.Controls.Add(this.rbTel);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.rbCPF);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.rtbReference);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.tbCpf);
            this.Controls.Add(this.tbStreet);
            this.Controls.Add(this.tbStNumber);
            this.Controls.Add(this.tbBairro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Clients";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbName;
        private System.Windows.Forms.MaskedTextBox tbCpf;
        private System.Windows.Forms.MaskedTextBox tbNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbBairro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tbStreet;
        private System.Windows.Forms.RichTextBox rtbReference;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbStNumber;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.MaskedTextBox tbSearch;
        private System.Windows.Forms.RadioButton rbCPF;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbGenerate;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer animGone;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.RadioButton rbTel;
    }
}