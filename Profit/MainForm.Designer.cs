namespace Profit
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbUpdate = new System.Windows.Forms.PictureBox();
            this.btnBackup = new System.Windows.Forms.PictureBox();
            this.btnHelp = new ns1.BunifuTileButton();
            this.btnGastos = new System.Windows.Forms.Button();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.btnProdCad = new System.Windows.Forms.Button();
            this.lblExit = new System.Windows.Forms.Label();
            this.btnRecCad = new System.Windows.Forms.Button();
            this.lblRemainingDays = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngCad = new System.Windows.Forms.Button();
            this.mainLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblDividendos = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblLucro = new System.Windows.Forms.Label();
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbConcluidos = new System.Windows.Forms.RadioButton();
            this.rbCancelados = new System.Windows.Forms.RadioButton();
            this.rbPendentes = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshTime = new System.Windows.Forms.Timer(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxSituation = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pbUpdate);
            this.panel2.Controls.Add(this.btnBackup);
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.btnGastos);
            this.panel2.Controls.Add(this.lblMinimize);
            this.panel2.Controls.Add(this.btnProdCad);
            this.panel2.Controls.Add(this.lblExit);
            this.panel2.Controls.Add(this.btnRecCad);
            this.panel2.Controls.Add(this.lblRemainingDays);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnIngCad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 134);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // pbUpdate
            // 
            this.pbUpdate.BackColor = System.Drawing.Color.White;
            this.pbUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUpdate.Image = global::Profit.Properties.Resources.refresh;
            this.pbUpdate.Location = new System.Drawing.Point(906, 2);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(26, 26);
            this.pbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpdate.TabIndex = 9;
            this.pbUpdate.TabStop = false;
            this.toolTip.SetToolTip(this.pbUpdate, "Verifica se há atualização. Se houver, fecha a aplicação para aplicar.");
            this.pbUpdate.Click += new System.EventHandler(this.pbUpdate_Click);
            this.pbUpdate.MouseEnter += new System.EventHandler(this.pbUpdate_MouseEnter);
            this.pbUpdate.MouseLeave += new System.EventHandler(this.pbUpdate_MouseLeave);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.White;
            this.btnBackup.Image = global::Profit.Properties.Resources.cloud_backup_up_arrow;
            this.btnBackup.Location = new System.Drawing.Point(943, -1);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(27, 31);
            this.btnBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBackup.TabIndex = 9;
            this.btnBackup.TabStop = false;
            this.toolTip.SetToolTip(this.btnBackup, "Backup do banco de dados");
            this.btnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            this.btnBackup.MouseEnter += new System.EventHandler(this.BtnBackup_MouseEnter);
            this.btnBackup.MouseLeave += new System.EventHandler(this.BtnBackup_MouseLeave);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.color = System.Drawing.Color.Transparent;
            this.btnHelp.colorActive = System.Drawing.Color.Transparent;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Image = global::Profit.Properties.Resources.icon;
            this.btnHelp.ImagePosition = 0;
            this.btnHelp.ImageZoom = 100;
            this.btnHelp.LabelPosition = 0;
            this.btnHelp.LabelText = "";
            this.btnHelp.Location = new System.Drawing.Point(8, 4);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(19, 19);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnGastos
            // 
            this.btnGastos.BackColor = System.Drawing.Color.Transparent;
            this.btnGastos.FlatAppearance.BorderSize = 0;
            this.btnGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGastos.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGastos.ForeColor = System.Drawing.Color.Black;
            this.btnGastos.Image = global::Profit.Properties.Resources.debt__2_;
            this.btnGastos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGastos.Location = new System.Drawing.Point(771, 31);
            this.btnGastos.Margin = new System.Windows.Forms.Padding(4);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Size = new System.Drawing.Size(260, 103);
            this.btnGastos.TabIndex = 2;
            this.btnGastos.Text = "Gerenciador de Gastos";
            this.btnGastos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGastos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnGastos, "Atalho: F8");
            this.btnGastos.UseVisualStyleBackColor = false;
            this.btnGastos.Click += new System.EventHandler(this.BtnGastos_Click);
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Black;
            this.lblMinimize.Location = new System.Drawing.Point(978, 5);
            this.lblMinimize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(17, 15);
            this.lblMinimize.TabIndex = 1;
            this.lblMinimize.Text = "__";
            this.lblMinimize.Click += new System.EventHandler(this.LblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.LblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.LblMinimize_MouseLeave);
            // 
            // btnProdCad
            // 
            this.btnProdCad.BackColor = System.Drawing.Color.Transparent;
            this.btnProdCad.FlatAppearance.BorderSize = 0;
            this.btnProdCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdCad.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdCad.ForeColor = System.Drawing.Color.Black;
            this.btnProdCad.Image = global::Profit.Properties.Resources.product__2_;
            this.btnProdCad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProdCad.Location = new System.Drawing.Point(519, 31);
            this.btnProdCad.Margin = new System.Windows.Forms.Padding(4);
            this.btnProdCad.Name = "btnProdCad";
            this.btnProdCad.Size = new System.Drawing.Size(257, 103);
            this.btnProdCad.TabIndex = 2;
            this.btnProdCad.Text = "Gerenciador de Produtos";
            this.btnProdCad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProdCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnProdCad, "Atalho: F7");
            this.btnProdCad.UseVisualStyleBackColor = false;
            this.btnProdCad.Click += new System.EventHandler(this.BtnProdCad_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblExit.ForeColor = System.Drawing.Color.Black;
            this.lblExit.Location = new System.Drawing.Point(1006, 4);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(20, 21);
            this.lblExit.TabIndex = 1;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.LblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.LblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.LblExit_MouseLeave);
            // 
            // btnRecCad
            // 
            this.btnRecCad.BackColor = System.Drawing.Color.Transparent;
            this.btnRecCad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRecCad.FlatAppearance.BorderSize = 0;
            this.btnRecCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecCad.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecCad.ForeColor = System.Drawing.Color.Black;
            this.btnRecCad.Image = global::Profit.Properties.Resources.open_book__1_;
            this.btnRecCad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecCad.Location = new System.Drawing.Point(259, 31);
            this.btnRecCad.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecCad.Name = "btnRecCad";
            this.btnRecCad.Size = new System.Drawing.Size(257, 103);
            this.btnRecCad.TabIndex = 1;
            this.btnRecCad.Text = "Gerenciador de Receitas";
            this.btnRecCad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnRecCad, "Atalho: F6");
            this.btnRecCad.UseVisualStyleBackColor = false;
            this.btnRecCad.Click += new System.EventHandler(this.BtnRecCad_Click);
            // 
            // lblRemainingDays
            // 
            this.lblRemainingDays.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingDays.ForeColor = System.Drawing.Color.Black;
            this.lblRemainingDays.Location = new System.Drawing.Point(693, 4);
            this.lblRemainingDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemainingDays.Name = "lblRemainingDays";
            this.lblRemainingDays.Size = new System.Drawing.Size(212, 20);
            this.lblRemainingDays.TabIndex = 0;
            this.lblRemainingDays.Text = "Dias para expirar licença: 30";
            this.lblRemainingDays.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRemainingDays.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.lblRemainingDays.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.lblRemainingDays.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ironside Productions - Gerência de Lucro - v0.4";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // btnIngCad
            // 
            this.btnIngCad.BackColor = System.Drawing.Color.Transparent;
            this.btnIngCad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIngCad.FlatAppearance.BorderSize = 0;
            this.btnIngCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngCad.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnIngCad.ForeColor = System.Drawing.Color.Black;
            this.btnIngCad.Image = ((System.Drawing.Image)(resources.GetObject("btnIngCad.Image")));
            this.btnIngCad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIngCad.Location = new System.Drawing.Point(0, 31);
            this.btnIngCad.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngCad.Name = "btnIngCad";
            this.btnIngCad.Size = new System.Drawing.Size(266, 103);
            this.btnIngCad.TabIndex = 0;
            this.btnIngCad.Text = "Gerenciador de Ingredientes";
            this.btnIngCad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIngCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnIngCad, "Atalho: F5");
            this.btnIngCad.UseVisualStyleBackColor = false;
            this.btnIngCad.Click += new System.EventHandler(this.BtnIngCad_Click);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.White;
            this.mainLabel.Font = new System.Drawing.Font("Caviar Dreams", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.Color.Black;
            this.mainLabel.Location = new System.Drawing.Point(309, 9);
            this.mainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(421, 33);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "ESTATÍSTICAS GERAIS DO DIA";
            this.mainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.mainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.mainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.btnGenerateReport);
            this.panel3.Controls.Add(this.btnData);
            this.panel3.Controls.Add(this.btnClients);
            this.panel3.Controls.Add(this.btnSell);
            this.panel3.Location = new System.Drawing.Point(0, 537);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1029, 141);
            this.panel3.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.White;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateReport.Image = global::Profit.Properties.Resources.diagram;
            this.btnGenerateReport.Location = new System.Drawing.Point(513, 1);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(258, 97);
            this.btnGenerateReport.TabIndex = 0;
            this.btnGenerateReport.Text = "Área de Relatórios";
            this.btnGenerateReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnGenerateReport, "Atalho: F3");
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.BtnGenerateReport_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.White;
            this.btnData.FlatAppearance.BorderSize = 0;
            this.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnData.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnData.ForeColor = System.Drawing.Color.Black;
            this.btnData.Image = global::Profit.Properties.Resources.investment;
            this.btnData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnData.Location = new System.Drawing.Point(769, 1);
            this.btnData.Margin = new System.Windows.Forms.Padding(4);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(262, 97);
            this.btnData.TabIndex = 0;
            this.btnData.Text = "Área de Rendimentos";
            this.btnData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnData, "Atalho: F4");
            this.btnData.UseVisualStyleBackColor = false;
            this.btnData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.White;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.Black;
            this.btnClients.Image = global::Profit.Properties.Resources.customer_service;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClients.Location = new System.Drawing.Point(258, 1);
            this.btnClients.Margin = new System.Windows.Forms.Padding(4);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(257, 97);
            this.btnClients.TabIndex = 0;
            this.btnClients.Text = "Área de Clientes";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnClients, "Atalho: F2");
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.White;
            this.btnSell.FlatAppearance.BorderSize = 0;
            this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSell.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.ForeColor = System.Drawing.Color.Black;
            this.btnSell.Image = global::Profit.Properties.Resources.euro;
            this.btnSell.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSell.Location = new System.Drawing.Point(1, 1);
            this.btnSell.Margin = new System.Windows.Forms.Padding(4);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(257, 97);
            this.btnSell.TabIndex = 0;
            this.btnSell.Text = "Iniciar Nova Venda";
            this.btnSell.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnSell, "Atalho: F1");
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.BtnSell_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(-1, 228);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1029, 308);
            this.dgvDetails.TabIndex = 3;
            this.toolTip.SetToolTip(this.dgvDetails, "Clique duas vezes sobre uma linha para detalhes sobre o pedido");
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetails_CellClick);
            this.dgvDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetails_CellContentClick);
            this.dgvDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetails_CellDoubleClick);
            this.dgvDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDetails_KeyDown);
            this.dgvDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDetails_MouseDown);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Informação";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(13, 2);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(91, 20);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Dividendos:";
            this.toolTip.SetToolTip(this.lbl1, "Relação de todos os gastos mensais em dias");
            // 
            // lblDividendos
            // 
            this.lblDividendos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDividendos.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDividendos.Location = new System.Drawing.Point(120, 3);
            this.lblDividendos.Name = "lblDividendos";
            this.lblDividendos.Size = new System.Drawing.Size(139, 17);
            this.lblDividendos.TabIndex = 4;
            this.lblDividendos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lblDividendos, "Relação de todos os gastos mensais em dias");
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(13, 25);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(109, 20);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Lucro Líquido:";
            this.toolTip.SetToolTip(this.lbl2, "Relação do lucro líquido");
            // 
            // lblLucro
            // 
            this.lblLucro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLucro.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLucro.Location = new System.Drawing.Point(120, 27);
            this.lblLucro.Name = "lblLucro";
            this.lblLucro.Size = new System.Drawing.Size(139, 17);
            this.lblLucro.TabIndex = 7;
            this.lblLucro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lblLucro, "Relação do lucro líquido");
            // 
            // animOpen
            // 
            this.animOpen.Interval = 2;
            this.animOpen.Tick += new System.EventHandler(this.Anim_Tick);
            // 
            // animGone
            // 
            this.animGone.Interval = 1;
            this.animGone.Tick += new System.EventHandler(this.AnimGone_Tick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 11;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.rbConcluidos);
            this.panel1.Controls.Add(this.rbCancelados);
            this.panel1.Controls.Add(this.rbPendentes);
            this.panel1.Controls.Add(this.rbTodos);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.lblDividendos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.mainLabel);
            this.panel1.Controls.Add(this.lblLucro);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Location = new System.Drawing.Point(-1, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 103);
            this.panel1.TabIndex = 5;
            // 
            // rbConcluidos
            // 
            this.rbConcluidos.AutoSize = true;
            this.rbConcluidos.Location = new System.Drawing.Point(916, 69);
            this.rbConcluidos.Name = "rbConcluidos";
            this.rbConcluidos.Size = new System.Drawing.Size(109, 25);
            this.rbConcluidos.TabIndex = 12;
            this.rbConcluidos.Text = "Concluídos";
            this.rbConcluidos.UseVisualStyleBackColor = true;
            this.rbConcluidos.CheckedChanged += new System.EventHandler(this.rbConcluidos_CheckedChanged);
            // 
            // rbCancelados
            // 
            this.rbCancelados.AutoSize = true;
            this.rbCancelados.Location = new System.Drawing.Point(799, 69);
            this.rbCancelados.Name = "rbCancelados";
            this.rbCancelados.Size = new System.Drawing.Size(111, 25);
            this.rbCancelados.TabIndex = 12;
            this.rbCancelados.Text = "Cancelados";
            this.rbCancelados.UseVisualStyleBackColor = true;
            this.rbCancelados.CheckedChanged += new System.EventHandler(this.rbCancelados_CheckedChanged);
            // 
            // rbPendentes
            // 
            this.rbPendentes.AutoSize = true;
            this.rbPendentes.Location = new System.Drawing.Point(688, 69);
            this.rbPendentes.Name = "rbPendentes";
            this.rbPendentes.Size = new System.Drawing.Size(105, 25);
            this.rbPendentes.TabIndex = 12;
            this.rbPendentes.Text = "Pendentes";
            this.rbPendentes.UseVisualStyleBackColor = true;
            this.rbPendentes.CheckedChanged += new System.EventHandler(this.rbPendentes_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(608, 69);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(74, 25);
            this.rbTodos.TabIndex = 12;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(90, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 1);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbSearch.Location = new System.Drawing.Point(91, 72);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(512, 22);
            this.tbSearch.TabIndex = 8;
            this.tbSearch.Text = "ex.: \'\'Fulano da Silva\'\'";
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pesquisa:";
            // 
            // refreshTime
            // 
            this.refreshTime.Interval = 360000;
            this.refreshTime.Tick += new System.EventHandler(this.RefreshTime_Tick);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSituation,
            this.ctxDetail,
            this.ctxPrint,
            this.ctxDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(177, 92);
            this.ctxMenu.Text = "Menu";
            // 
            // ctxSituation
            // 
            this.ctxSituation.Image = global::Profit.Properties.Resources.refresh__2_;
            this.ctxSituation.Name = "ctxSituation";
            this.ctxSituation.Size = new System.Drawing.Size(176, 22);
            this.ctxSituation.Text = "Alterar Estado";
            this.ctxSituation.ToolTipText = "Altera o estado do pedido";
            this.ctxSituation.Click += new System.EventHandler(this.ctxSituation_Click);
            // 
            // ctxDetail
            // 
            this.ctxDetail.Image = global::Profit.Properties.Resources.magnifying_glass;
            this.ctxDetail.Name = "ctxDetail";
            this.ctxDetail.Size = new System.Drawing.Size(176, 22);
            this.ctxDetail.Text = "Detalhes";
            this.ctxDetail.ToolTipText = "Abre detalhes sobre o pedido selecionado";
            this.ctxDetail.Click += new System.EventHandler(this.ctxDetail_Click);
            // 
            // ctxPrint
            // 
            this.ctxPrint.Image = global::Profit.Properties.Resources.print;
            this.ctxPrint.Name = "ctxPrint";
            this.ctxPrint.Size = new System.Drawing.Size(176, 22);
            this.ctxPrint.Text = "Imprimir";
            this.ctxPrint.ToolTipText = "Imprime o pedido selecionado";
            this.ctxPrint.Click += new System.EventHandler(this.ctxPrint_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Image = global::Profit.Properties.Resources.delete1;
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Size = new System.Drawing.Size(176, 22);
            this.ctxDelete.Text = "Excluir";
            this.ctxDelete.ToolTipText = "Deleta permanentemente o pedido selecionado";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1029, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ironside Productions - Gerência de Lucro";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnProdCad;
        private System.Windows.Forms.Button btnRecCad;
        private System.Windows.Forms.Button btnIngCad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnGastos;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.Timer animGone;
        private ns1.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblDividendos;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblLucro;
        private System.Windows.Forms.Timer refreshTime;
        private ns1.BunifuTileButton btnHelp;
        private System.Windows.Forms.PictureBox btnBackup;
        private System.Windows.Forms.PictureBox pbUpdate;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxDetail;
        private System.Windows.Forms.ToolStripMenuItem ctxPrint;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxSituation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbConcluidos;
        private System.Windows.Forms.RadioButton rbCancelados;
        private System.Windows.Forms.RadioButton rbPendentes;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Label lblRemainingDays;
    }
}

