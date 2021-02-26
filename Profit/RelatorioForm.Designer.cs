namespace Profit
{
    partial class RelatorioForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.datePicker2 = new ns1.BunifuDatepicker();
            this.datePicker1 = new ns1.BunifuDatepicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.comboBoxProduto = new System.Windows.Forms.ComboBox();
            this.cbProduto = new System.Windows.Forms.CheckBox();
            this.cbEstado = new System.Windows.Forms.CheckBox();
            this.cbForma = new System.Windows.Forms.CheckBox();
            this.cbGasto = new System.Windows.Forms.CheckBox();
            this.cbCliente = new System.Windows.Forms.CheckBox();
            this.cbLucro = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Location = new System.Drawing.Point(0, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 161);
            this.panel1.TabIndex = 9;
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
            this.btnBack.Size = new System.Drawing.Size(1031, 62);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Voltar";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnBack, "Volta para o menu principal");
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.White;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Image = global::Profit.Properties.Resources.seo_report__2_;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.Location = new System.Drawing.Point(0, 4);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(1031, 97);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "  Gerar Relatório";
            this.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnGenerate, "Gera um arquivo EXCEL dos dados que estão na tabela");
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
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
            this.dgvDetails.Location = new System.Drawing.Point(0, 261);
            this.dgvDetails.Name = "dgvDetails";
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
            this.dgvDetails.TabIndex = 10;
            // 
            // animOpen
            // 
            this.animOpen.Interval = 1;
            this.animOpen.Tick += new System.EventHandler(this.animOpen_Tick);
            // 
            // animGone
            // 
            this.animGone.Interval = 1;
            this.animGone.Tick += new System.EventHandler(this.animGone_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label4.Location = new System.Drawing.Point(216, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(584, 63);
            this.label4.TabIndex = 11;
            this.label4.Text = "Gerador de Relatórios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label1.Location = new System.Drawing.Point(321, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Monte diferentes dados através das suas vendas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 100);
            this.panel2.TabIndex = 29;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // btnShow
            // 
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Caviar Dreams", 16F, System.Drawing.FontStyle.Bold);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(805, 98);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(224, 172);
            this.btnShow.TabIndex = 53;
            this.btnShow.Text = "Mostrar";
            this.toolTip1.SetToolTip(this.btnShow, "Gera uma tabela com todos os dados escolhidos");
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold);
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(417, 216);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(34, 19);
            this.bunifuCustomLabel2.TabIndex = 51;
            this.bunifuCustomLabel2.Text = "Fim";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(401, 146);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(51, 19);
            this.bunifuCustomLabel1.TabIndex = 52;
            this.bunifuCustomLabel1.Text = "Início";
            // 
            // datePicker2
            // 
            this.datePicker2.BackColor = System.Drawing.Color.White;
            this.datePicker2.BorderRadius = 5;
            this.datePicker2.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker2.ForeColor = System.Drawing.Color.Black;
            this.datePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datePicker2.FormatCustom = "d";
            this.datePicker2.Location = new System.Drawing.Point(453, 206);
            this.datePicker2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(349, 38);
            this.datePicker2.TabIndex = 49;
            this.datePicker2.Value = new System.DateTime(2019, 8, 14, 22, 5, 39, 358);
            // 
            // datePicker1
            // 
            this.datePicker1.BackColor = System.Drawing.Color.White;
            this.datePicker1.BorderRadius = 5;
            this.datePicker1.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker1.ForeColor = System.Drawing.Color.Black;
            this.datePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datePicker1.FormatCustom = "";
            this.datePicker1.Location = new System.Drawing.Point(453, 139);
            this.datePicker1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(349, 38);
            this.datePicker1.TabIndex = 50;
            this.datePicker1.Value = new System.DateTime(2019, 8, 14, 22, 5, 39, 358);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(555, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Entre as datas";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.comboBoxCliente);
            this.groupBox.Controls.Add(this.comboBoxProduto);
            this.groupBox.Controls.Add(this.cbProduto);
            this.groupBox.Controls.Add(this.cbEstado);
            this.groupBox.Controls.Add(this.cbForma);
            this.groupBox.Controls.Add(this.cbGasto);
            this.groupBox.Controls.Add(this.cbCliente);
            this.groupBox.Controls.Add(this.cbLucro);
            this.groupBox.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.Location = new System.Drawing.Point(12, 106);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(383, 138);
            this.groupBox.TabIndex = 54;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Dados a Incluir";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxCliente.BackColor = System.Drawing.Color.White;
            this.comboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCliente.Enabled = false;
            this.comboBoxCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCliente.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(107, 102);
            this.comboBoxCliente.MaxDropDownItems = 100;
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(270, 27);
            this.comboBoxCliente.TabIndex = 34;
            this.toolTip1.SetToolTip(this.comboBoxCliente, "Mostra todas as vendas feitas para o cliente selecionado");
            // 
            // comboBoxProduto
            // 
            this.comboBoxProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxProduto.BackColor = System.Drawing.Color.White;
            this.comboBoxProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduto.Enabled = false;
            this.comboBoxProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProduto.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.comboBoxProduto.FormattingEnabled = true;
            this.comboBoxProduto.Location = new System.Drawing.Point(107, 61);
            this.comboBoxProduto.MaxDropDownItems = 100;
            this.comboBoxProduto.Name = "comboBoxProduto";
            this.comboBoxProduto.Size = new System.Drawing.Size(270, 27);
            this.comboBoxProduto.TabIndex = 33;
            this.toolTip1.SetToolTip(this.comboBoxProduto, "Mostra todas as vendas feitas do produto selecionado");
            // 
            // cbProduto
            // 
            this.cbProduto.AutoSize = true;
            this.cbProduto.Location = new System.Drawing.Point(12, 67);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(98, 23);
            this.cbProduto.TabIndex = 32;
            this.cbProduto.Text = "Produto:";
            this.toolTip1.SetToolTip(this.cbProduto, "Mostra todas as vendas feitas do produto selecionado");
            this.cbProduto.UseVisualStyleBackColor = true;
            this.cbProduto.CheckedChanged += new System.EventHandler(this.rbProduto_CheckedChanged);
            // 
            // cbEstado
            // 
            this.cbEstado.AutoSize = true;
            this.cbEstado.Location = new System.Drawing.Point(292, 28);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(85, 23);
            this.cbEstado.TabIndex = 0;
            this.cbEstado.Text = "Estado";
            this.toolTip1.SetToolTip(this.cbEstado, "Mostra o estado(concluído, cancelado, pendente) de todas as vendas feitas entre o" +
        " intervalo selecionado");
            this.cbEstado.UseVisualStyleBackColor = true;
            this.cbEstado.CheckedChanged += new System.EventHandler(this.cbEstado_CheckedChanged);
            // 
            // cbForma
            // 
            this.cbForma.AutoSize = true;
            this.cbForma.Location = new System.Drawing.Point(197, 28);
            this.cbForma.Name = "cbForma";
            this.cbForma.Size = new System.Drawing.Size(78, 23);
            this.cbForma.TabIndex = 0;
            this.cbForma.Text = "Forma";
            this.toolTip1.SetToolTip(this.cbForma, "Mostra a forma de pagamento de todas as vendas feitas entre o intervalo seleciona" +
        "do");
            this.cbForma.UseVisualStyleBackColor = true;
            this.cbForma.CheckedChanged += new System.EventHandler(this.rbForma_CheckedChanged);
            // 
            // cbGasto
            // 
            this.cbGasto.AutoSize = true;
            this.cbGasto.Location = new System.Drawing.Point(102, 28);
            this.cbGasto.Name = "cbGasto";
            this.cbGasto.Size = new System.Drawing.Size(78, 23);
            this.cbGasto.TabIndex = 0;
            this.cbGasto.Text = "Gasto";
            this.toolTip1.SetToolTip(this.cbGasto, "Mostra o gasto de todas as vendas feitas entre o intervalo selecionado");
            this.cbGasto.UseVisualStyleBackColor = true;
            this.cbGasto.CheckedChanged += new System.EventHandler(this.rbGasto_CheckedChanged);
            // 
            // cbCliente
            // 
            this.cbCliente.AutoSize = true;
            this.cbCliente.Location = new System.Drawing.Point(12, 107);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(88, 23);
            this.cbCliente.TabIndex = 0;
            this.cbCliente.Text = "Cliente:";
            this.toolTip1.SetToolTip(this.cbCliente, "Mostra todas as vendas feitas para o cliente descrito");
            this.cbCliente.UseVisualStyleBackColor = true;
            this.cbCliente.CheckedChanged += new System.EventHandler(this.rbCliente_CheckedChanged);
            // 
            // cbLucro
            // 
            this.cbLucro.AutoSize = true;
            this.cbLucro.Location = new System.Drawing.Point(12, 28);
            this.cbLucro.Name = "cbLucro";
            this.cbLucro.Size = new System.Drawing.Size(73, 23);
            this.cbLucro.TabIndex = 0;
            this.cbLucro.Text = "Lucro";
            this.toolTip1.SetToolTip(this.cbLucro, "Mostra o lucro de todas as vendas feitas entre o intervalo selecionado");
            this.cbLucro.UseVisualStyleBackColor = true;
            this.cbLucro.CheckedChanged += new System.EventHandler(this.rbLucro_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "INFORMAÇÃO";
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1029, 729);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.datePicker2);
            this.Controls.Add(this.datePicker1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Relatorio";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área de Relatórios";
            this.Load += new System.EventHandler(this.Relatorio_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Timer animOpen;
        private System.Windows.Forms.Timer animGone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShow;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuDatepicker datePicker2;
        private ns1.BunifuDatepicker datePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox cbForma;
        private System.Windows.Forms.CheckBox cbGasto;
        private System.Windows.Forms.CheckBox cbCliente;
        private System.Windows.Forms.CheckBox cbLucro;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbProduto;
        private System.Windows.Forms.ComboBox comboBoxProduto;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.CheckBox cbEstado;
    }
}