namespace Profit
{
    partial class VendasForm
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendasForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.lbPedido = new System.Windows.Forms.ListBox();
            this.cbDelivery = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnObs = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbNomeCliente = new System.Windows.Forms.TextBox();
            this.tbBairro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbStNumber = new System.Windows.Forms.TextBox();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.tbTotalRecebido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbTroco = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbDinheiro = new System.Windows.Forms.RadioButton();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.tbNumber = new System.Windows.Forms.MaskedTextBox();
            this.gbDelivery = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.animation = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbObservations = new System.Windows.Forms.RichTextBox();
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.gbDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.animation.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Selecione o produto";
            // 
            // comboBox
            // 
            this.comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.animation.SetDecoration(this.comboBox, BunifuAnimatorNS.DecorationType.None);
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(12, 128);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(175, 27);
            this.comboBox.TabIndex = 0;
            this.comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyDown);
            // 
            // lbPedido
            // 
            this.lbPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animation.SetDecoration(this.lbPedido, BunifuAnimatorNS.DecorationType.None);
            this.lbPedido.Font = new System.Drawing.Font("Caviar Dreams", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPedido.FormattingEnabled = true;
            this.lbPedido.ItemHeight = 20;
            this.lbPedido.Location = new System.Drawing.Point(202, 100);
            this.lbPedido.Name = "lbPedido";
            this.lbPedido.Size = new System.Drawing.Size(148, 182);
            this.lbPedido.TabIndex = 23;
            this.toolTip1.SetToolTip(this.lbPedido, "Caso o item esteja com asterisco(*), há alguma observação para ele");
            // 
            // cbDelivery
            // 
            this.cbDelivery.AutoSize = true;
            this.animation.SetDecoration(this.cbDelivery, BunifuAnimatorNS.DecorationType.None);
            this.cbDelivery.Font = new System.Drawing.Font("Caviar Dreams", 13.25F, System.Drawing.FontStyle.Bold);
            this.cbDelivery.Location = new System.Drawing.Point(3, 253);
            this.cbDelivery.Name = "cbDelivery";
            this.cbDelivery.Size = new System.Drawing.Size(98, 25);
            this.cbDelivery.TabIndex = 4;
            this.cbDelivery.Text = "Delivery";
            this.cbDelivery.UseVisualStyleBackColor = true;
            this.cbDelivery.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.animation.SetDecoration(this.label10, BunifuAnimatorNS.DecorationType.None);
            this.label10.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 125);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "Total do Pedido";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.animation.SetDecoration(this.lblPrice, BunifuAnimatorNS.DecorationType.None);
            this.lblPrice.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPrice.Location = new System.Drawing.Point(56, 146);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(83, 22);
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "R$ 0.00";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Informação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animation.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nome do cliente";
            this.toolTip1.SetToolTip(this.label3, "Clique para limpar todos os campos");
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            this.label3.MouseEnter += new System.EventHandler(this.Label3_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.Label3_MouseLeave);
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.Color.Salmon;
            this.animation.SetDecoration(this.btnClean, BunifuAnimatorNS.DecorationType.None);
            this.btnClean.FlatAppearance.BorderSize = 0;
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Image = global::Profit.Properties.Resources.broom__1_;
            this.btnClean.Location = new System.Drawing.Point(349, 232);
            this.btnClean.Margin = new System.Windows.Forms.Padding(4);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(225, 50);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "   Limpar Lista";
            this.btnClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnClean, "Clique para limpar toda a lista de pedidos. Atalho: Shift + Delete");
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.BtnClean_Click);
            // 
            // btnObs
            // 
            this.btnObs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.animation.SetDecoration(this.btnObs, BunifuAnimatorNS.DecorationType.None);
            this.btnObs.FlatAppearance.BorderSize = 0;
            this.btnObs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObs.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObs.Image = global::Profit.Properties.Resources.research;
            this.btnObs.Location = new System.Drawing.Point(349, 98);
            this.btnObs.Margin = new System.Windows.Forms.Padding(4);
            this.btnObs.Name = "btnObs";
            this.btnObs.Size = new System.Drawing.Size(223, 81);
            this.btnObs.TabIndex = 2;
            this.btnObs.Text = "Observações";
            this.btnObs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnObs, "Clique em algum item para adicionais, exclusões, descontos ou taxas. Atalho: Ctrl" +
        " + O");
            this.btnObs.UseVisualStyleBackColor = false;
            this.btnObs.Click += new System.EventHandler(this.BtnObs_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Salmon;
            this.animation.SetDecoration(this.btnExcluir, BunifuAnimatorNS.DecorationType.None);
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::Profit.Properties.Resources.eraser__1_;
            this.btnExcluir.Location = new System.Drawing.Point(349, 177);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(225, 55);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "   Excluir Item";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnExcluir, "Clique em algum item da lista para removê-lo da lista. Atalho: Delete");
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Salmon;
            this.animation.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Profit.Properties.Resources.error__1_;
            this.btnClose.Location = new System.Drawing.Point(0, 439);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(570, 44);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cancelar Pedido";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnClose, "Atalho: ESC");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.animation.SetDecoration(this.btnConfirm, BunifuAnimatorNS.DecorationType.None);
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::Profit.Properties.Resources.completed;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnConfirm.Location = new System.Drawing.Point(0, 365);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(570, 74);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = " ";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnConfirm, "Atalho: Ctrl + ENTER");
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.BackColor = System.Drawing.Color.SkyBlue;
            this.animation.SetDecoration(this.btnDelivery, BunifuAnimatorNS.DecorationType.None);
            this.btnDelivery.FlatAppearance.BorderSize = 0;
            this.btnDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelivery.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.Image = global::Profit.Properties.Resources.scooter;
            this.btnDelivery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelivery.Location = new System.Drawing.Point(-12, 328);
            this.btnDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(591, 37);
            this.btnDelivery.TabIndex = 1;
            this.btnDelivery.Text = "Delivery";
            this.btnDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDelivery, "Atalho: Ctrl + D");
            this.btnDelivery.UseVisualStyleBackColor = false;
            this.btnDelivery.Click += new System.EventHandler(this.BtnDelivery_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.animation.SetDecoration(this.btnAdd, BunifuAnimatorNS.DecorationType.None);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Profit.Properties.Resources.file;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(0, 164);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 59);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Adicionar à Lista";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAdd, "Atalho: Ctrl + A");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // tbNomeCliente
            // 
            this.tbNomeCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tbNomeCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbNomeCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.animation.SetDecoration(this.tbNomeCliente, BunifuAnimatorNS.DecorationType.None);
            this.tbNomeCliente.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomeCliente.Location = new System.Drawing.Point(25, 52);
            this.tbNomeCliente.Name = "tbNomeCliente";
            this.tbNomeCliente.Size = new System.Drawing.Size(184, 19);
            this.tbNomeCliente.TabIndex = 0;
            this.tbNomeCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbNomeCliente_KeyUp);
            this.tbNomeCliente.Leave += new System.EventHandler(this.TbNomeCliente_Leave);
            // 
            // tbBairro
            // 
            this.tbBairro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.animation.SetDecoration(this.tbBairro, BunifuAnimatorNS.DecorationType.None);
            this.tbBairro.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBairro.Location = new System.Drawing.Point(27, 106);
            this.tbBairro.Name = "tbBairro";
            this.tbBairro.Size = new System.Drawing.Size(182, 19);
            this.tbBairro.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.animation.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.label5.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Número do cliente";
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.animation.SetDecoration(this.tbAddress, BunifuAnimatorNS.DecorationType.None);
            this.tbAddress.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(231, 51);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(243, 20);
            this.tbAddress.TabIndex = 1;
            // 
            // tbStNumber
            // 
            this.tbStNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbStNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animation.SetDecoration(this.tbStNumber, BunifuAnimatorNS.DecorationType.None);
            this.tbStNumber.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStNumber.Location = new System.Drawing.Point(497, 51);
            this.tbStNumber.Name = "tbStNumber";
            this.tbStNumber.Size = new System.Drawing.Size(36, 19);
            this.tbStNumber.TabIndex = 2;
            // 
            // tbReference
            // 
            this.tbReference.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.animation.SetDecoration(this.tbReference, BunifuAnimatorNS.DecorationType.None);
            this.tbReference.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReference.Location = new System.Drawing.Point(231, 106);
            this.tbReference.Multiline = true;
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(302, 20);
            this.tbReference.TabIndex = 4;
            // 
            // tbTotalRecebido
            // 
            this.tbTotalRecebido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTotalRecebido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animation.SetDecoration(this.tbTotalRecebido, BunifuAnimatorNS.DecorationType.None);
            this.tbTotalRecebido.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalRecebido.Location = new System.Drawing.Point(231, 163);
            this.tbTotalRecebido.Name = "tbTotalRecebido";
            this.tbTotalRecebido.Size = new System.Drawing.Size(218, 19);
            this.tbTotalRecebido.TabIndex = 6;
            this.tbTotalRecebido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbTotalRecebido_KeyPress);
            this.tbTotalRecebido.Leave += new System.EventHandler(this.TbTotalRecebido_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.animation.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.label6.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(227, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Rua";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.animation.SetDecoration(this.label12, BunifuAnimatorNS.DecorationType.None);
            this.label12.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(493, 29);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 19);
            this.label12.TabIndex = 13;
            this.label12.Text = "Nº";
            // 
            // tbTroco
            // 
            this.tbTroco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTroco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animation.SetDecoration(this.tbTroco, BunifuAnimatorNS.DecorationType.None);
            this.tbTroco.Enabled = false;
            this.tbTroco.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTroco.Location = new System.Drawing.Point(460, 163);
            this.tbTroco.Name = "tbTroco";
            this.tbTroco.ReadOnly = true;
            this.tbTroco.Size = new System.Drawing.Size(72, 19);
            this.tbTroco.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.animation.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.label7.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(227, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ponto de Referência";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.animation.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.label8.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(227, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Total a receber";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.animation.SetDecoration(this.label9, BunifuAnimatorNS.DecorationType.None);
            this.label9.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(456, 141);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Troco";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.animation.SetDecoration(this.label11, BunifuAnimatorNS.DecorationType.None);
            this.label11.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Bairro";
            // 
            // rbDinheiro
            // 
            this.rbDinheiro.AutoSize = true;
            this.animation.SetDecoration(this.rbDinheiro, BunifuAnimatorNS.DecorationType.None);
            this.rbDinheiro.Font = new System.Drawing.Font("Caviar Dreams", 14F);
            this.rbDinheiro.Location = new System.Drawing.Point(178, 186);
            this.rbDinheiro.Name = "rbDinheiro";
            this.rbDinheiro.Size = new System.Drawing.Size(96, 26);
            this.rbDinheiro.TabIndex = 8;
            this.rbDinheiro.TabStop = true;
            this.rbDinheiro.Text = "Dinheiro";
            this.rbDinheiro.UseVisualStyleBackColor = true;
            this.rbDinheiro.CheckedChanged += new System.EventHandler(this.RbDinheiro_CheckedChanged);
            // 
            // rbCard
            // 
            this.rbCard.AutoSize = true;
            this.animation.SetDecoration(this.rbCard, BunifuAnimatorNS.DecorationType.None);
            this.rbCard.Font = new System.Drawing.Font("Caviar Dreams", 14F);
            this.rbCard.Location = new System.Drawing.Point(288, 187);
            this.rbCard.Name = "rbCard";
            this.rbCard.Size = new System.Drawing.Size(93, 26);
            this.rbCard.TabIndex = 9;
            this.rbCard.TabStop = true;
            this.rbCard.Text = "Cartão";
            this.rbCard.UseVisualStyleBackColor = true;
            this.rbCard.CheckedChanged += new System.EventHandler(this.RbCard_CheckedChanged);
            // 
            // tbNumber
            // 
            this.tbNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animation.SetDecoration(this.tbNumber, BunifuAnimatorNS.DecorationType.None);
            this.tbNumber.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumber.Location = new System.Drawing.Point(26, 163);
            this.tbNumber.Mask = "(99) 00000-0000";
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(183, 19);
            this.tbNumber.TabIndex = 5;
            // 
            // gbDelivery
            // 
            this.gbDelivery.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbDelivery.Controls.Add(this.pictureBox8);
            this.gbDelivery.Controls.Add(this.pictureBox7);
            this.gbDelivery.Controls.Add(this.pictureBox6);
            this.gbDelivery.Controls.Add(this.pictureBox5);
            this.gbDelivery.Controls.Add(this.pictureBox4);
            this.gbDelivery.Controls.Add(this.pictureBox3);
            this.gbDelivery.Controls.Add(this.pictureBox2);
            this.gbDelivery.Controls.Add(this.pictureBox1);
            this.gbDelivery.Controls.Add(this.tbNumber);
            this.gbDelivery.Controls.Add(this.rbDinheiro);
            this.gbDelivery.Controls.Add(this.label11);
            this.gbDelivery.Controls.Add(this.label3);
            this.gbDelivery.Controls.Add(this.label9);
            this.gbDelivery.Controls.Add(this.label8);
            this.gbDelivery.Controls.Add(this.label7);
            this.gbDelivery.Controls.Add(this.rbCard);
            this.gbDelivery.Controls.Add(this.tbTroco);
            this.gbDelivery.Controls.Add(this.label12);
            this.gbDelivery.Controls.Add(this.label6);
            this.gbDelivery.Controls.Add(this.tbTotalRecebido);
            this.gbDelivery.Controls.Add(this.tbReference);
            this.gbDelivery.Controls.Add(this.tbStNumber);
            this.gbDelivery.Controls.Add(this.tbAddress);
            this.gbDelivery.Controls.Add(this.label5);
            this.gbDelivery.Controls.Add(this.tbBairro);
            this.gbDelivery.Controls.Add(this.tbNomeCliente);
            this.animation.SetDecoration(this.gbDelivery, BunifuAnimatorNS.DecorationType.None);
            this.gbDelivery.Enabled = false;
            this.gbDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbDelivery.Font = new System.Drawing.Font("Caviar Dreams", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDelivery.Location = new System.Drawing.Point(7, 61);
            this.gbDelivery.Name = "gbDelivery";
            this.gbDelivery.Size = new System.Drawing.Size(555, 215);
            this.gbDelivery.TabIndex = 4;
            this.gbDelivery.TabStop = false;
            this.gbDelivery.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox8, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox8.Location = new System.Drawing.Point(26, 180);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(183, 2);
            this.pictureBox8.TabIndex = 42;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox7, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox7.Location = new System.Drawing.Point(460, 180);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(72, 2);
            this.pictureBox7.TabIndex = 41;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox6, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox6.Location = new System.Drawing.Point(231, 180);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(218, 2);
            this.pictureBox6.TabIndex = 40;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox5, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox5.Location = new System.Drawing.Point(231, 124);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(302, 2);
            this.pictureBox5.TabIndex = 39;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox4, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox4.Location = new System.Drawing.Point(27, 124);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(182, 2);
            this.pictureBox4.TabIndex = 38;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox3, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox3.Location = new System.Drawing.Point(497, 69);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 2);
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox2, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox2.Location = new System.Drawing.Point(231, 69);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 2);
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.animation.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Location = new System.Drawing.Point(25, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 2);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // animation
            // 
            this.animation.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.animation.Cursor = System.Windows.Forms.Cursors.Hand;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.animation.DefaultAnimation = animation1;
            this.animation.Interval = 2;
            this.animation.MaxAnimationTime = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.animation.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 100);
            this.panel2.TabIndex = 39;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.animation.SetDecoration(this.label13, BunifuAnimatorNS.DecorationType.None);
            this.label13.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label13.Location = new System.Drawing.Point(179, 69);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(195, 19);
            this.label13.TabIndex = 16;
            this.label13.Text = "Faça os pedidos abaixo";
            this.label13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.label13.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.label13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.animation.SetDecoration(this.label14, BunifuAnimatorNS.DecorationType.None);
            this.label14.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label14.Location = new System.Drawing.Point(49, 13);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(475, 63);
            this.label14.TabIndex = 3;
            this.label14.Text = "Painel de Pedidos";
            this.label14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.label14.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.label14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.label1);
            this.animation.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 182);
            this.panel1.TabIndex = 14;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.animation.SetDecoration(this.chart1, BunifuAnimatorNS.DecorationType.None);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.animation.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label2.Location = new System.Drawing.Point(4, 295);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Obs.:";
            // 
            // rtbObservations
            // 
            this.rtbObservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animation.SetDecoration(this.rtbObservations, BunifuAnimatorNS.DecorationType.None);
            this.rtbObservations.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbObservations.Location = new System.Drawing.Point(55, 287);
            this.rtbObservations.Name = "rtbObservations";
            this.rtbObservations.Size = new System.Drawing.Size(509, 35);
            this.rtbObservations.TabIndex = 40;
            this.rtbObservations.Text = "";
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
            // VendasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(570, 483);
            this.Controls.Add(this.rtbObservations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.lbPedido);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnObs);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbDelivery);
            this.Controls.Add(this.cbDelivery);
            this.animation.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VendasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H. Production - Gerência de Lucro  | Cadastro de Ingredientes | Painel de Vendas";
            this.Load += new System.EventHandler(this.Vendas_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.gbDelivery.ResumeLayout(false);
            this.gbDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ListBox lbPedido;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.CheckBox cbDelivery;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnObs;
        private System.Windows.Forms.TextBox tbNomeCliente;
        private System.Windows.Forms.TextBox tbBairro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbStNumber;
        private System.Windows.Forms.TextBox tbReference;
        private System.Windows.Forms.TextBox tbTotalRecebido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbTroco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbDinheiro;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.MaskedTextBox tbNumber;
        private System.Windows.Forms.GroupBox gbDelivery;
        private BunifuAnimatorNS.BunifuTransition animation;
        private System.Windows.Forms.Timer animGone;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbObservations;
    }
}