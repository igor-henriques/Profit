namespace Profit
{
    partial class ProductivityForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductivityForm));
            this.datePicker1 = new ns1.BunifuDatepicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.datePicker2 = new ns1.BunifuDatepicker();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.rbBar = new System.Windows.Forms.RadioButton();
            this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
            this.cbIntervalo = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel5 = new ns1.BunifuCustomLabel();
            this.btnBack = new System.Windows.Forms.Button();
            this.animGone = new System.Windows.Forms.Timer(this.components);
            this.animOpen = new System.Windows.Forms.Timer(this.components);
            this.bunifuCustomLabel6 = new ns1.BunifuCustomLabel();
            this.tooltip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCalculate = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new ns1.BunifuCustomLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // datePicker1
            // 
            this.datePicker1.BackColor = System.Drawing.Color.White;
            this.datePicker1.BorderRadius = 5;
            this.datePicker1.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker1.ForeColor = System.Drawing.Color.Black;
            this.datePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datePicker1.FormatCustom = "";
            this.datePicker1.Location = new System.Drawing.Point(24, 137);
            this.datePicker1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(402, 52);
            this.datePicker1.TabIndex = 0;
            this.datePicker1.Value = new System.DateTime(2019, 8, 14, 22, 5, 39, 358);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 100);
            this.panel2.TabIndex = 41;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Caviar Dreams", 12F);
            this.label6.Location = new System.Drawing.Point(276, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(435, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Abaixo há todos os detalhes sobre os relatórios gerados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 40F);
            this.label4.Location = new System.Drawing.Point(326, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 63);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rendimentos";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(198, 110);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(55, 22);
            this.bunifuCustomLabel1.TabIndex = 42;
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
            this.datePicker2.Location = new System.Drawing.Point(547, 137);
            this.datePicker2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(408, 52);
            this.datePicker2.TabIndex = 0;
            this.datePicker2.Value = new System.DateTime(2019, 8, 14, 22, 5, 39, 358);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(731, 110);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(36, 22);
            this.bunifuCustomLabel2.TabIndex = 42;
            this.bunifuCustomLabel2.Text = "Fim";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineWidth = 0;
            this.chart1.BorderSkin.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BorderWidth = 0;
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(-5, 190);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(990, 396);
            this.chart1.TabIndex = 43;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Relação de Lucro Líquido x Dia";
            this.chart1.Titles.Add(title1);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseMove);
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Checked = true;
            this.rbLine.Font = new System.Drawing.Font("Caviar Dreams", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLine.Location = new System.Drawing.Point(184, 591);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(68, 22);
            this.rbLine.TabIndex = 44;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Linhas";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.CheckedChanged += new System.EventHandler(this.RbLine_CheckedChanged);
            // 
            // rbBar
            // 
            this.rbBar.AutoSize = true;
            this.rbBar.Font = new System.Drawing.Font("Caviar Dreams", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBar.Location = new System.Drawing.Point(264, 591);
            this.rbBar.Name = "rbBar";
            this.rbBar.Size = new System.Drawing.Size(68, 22);
            this.rbBar.TabIndex = 45;
            this.rbBar.Text = "Barras";
            this.rbBar.UseVisualStyleBackColor = true;
            this.rbBar.CheckedChanged += new System.EventHandler(this.RbBar_CheckedChanged);
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(23, 587);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(153, 22);
            this.bunifuCustomLabel4.TabIndex = 42;
            this.bunifuCustomLabel4.Text = "Tipo de gráfico:";
            // 
            // cbIntervalo
            // 
            this.cbIntervalo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbIntervalo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIntervalo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIntervalo.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIntervalo.FormattingEnabled = true;
            this.cbIntervalo.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "50"});
            this.cbIntervalo.Location = new System.Drawing.Point(447, 585);
            this.cbIntervalo.Name = "cbIntervalo";
            this.cbIntervalo.Size = new System.Drawing.Size(87, 30);
            this.cbIntervalo.TabIndex = 46;
            this.cbIntervalo.SelectedIndexChanged += new System.EventHandler(this.CbIntervalo_SelectedIndexChanged);
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(351, 589);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(90, 22);
            this.bunifuCustomLabel5.TabIndex = 42;
            this.bunifuCustomLabel5.Text = "Intervalo:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Salmon;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::Profit.Properties.Resources.previous__1_;
            this.btnBack.Location = new System.Drawing.Point(-30, 627);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(1015, 62);
            this.btnBack.TabIndex = 47;
            this.btnBack.Text = "Voltar";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // animGone
            // 
            this.animGone.Interval = 1;
            // 
            // animOpen
            // 
            this.animOpen.Interval = 1;
            this.animOpen.Tick += new System.EventHandler(this.AnimOpen_Tick);
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(23, 218);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(154, 22);
            this.bunifuCustomLabel6.TabIndex = 42;
            this.bunifuCustomLabel6.Text = "Valores em reais";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCalculate.FlatAppearance.BorderSize = 0;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.Location = new System.Drawing.Point(424, 137);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(126, 52);
            this.btnCalculate.TabIndex = 48;
            this.btnCalculate.Text = "Mostrar";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Blue;
            this.pictureBox1.Location = new System.Drawing.Point(735, 585);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(864, 585);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 30);
            this.pictureBox2.TabIndex = 49;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(772, 589);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(76, 22);
            this.bunifuCustomLabel3.TabIndex = 42;
            this.bunifuCustomLabel3.Text = "Vendas";
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(901, 589);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(58, 22);
            this.bunifuCustomLabel7.TabIndex = 42;
            this.bunifuCustomLabel7.Text = "Lucro";
            // 
            // Productivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(979, 689);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cbIntervalo);
            this.Controls.Add(this.rbBar);
            this.Controls.Add(this.rbLine);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel5);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.bunifuCustomLabel7);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.datePicker2);
            this.Controls.Add(this.datePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Productivity";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productivity";
            this.Load += new System.EventHandler(this.Productivity_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuDatepicker datePicker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuDatepicker datePicker2;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.RadioButton rbBar;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.ComboBox cbIntervalo;
        private ns1.BunifuCustomLabel bunifuCustomLabel5;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Timer animGone;
        private System.Windows.Forms.Timer animOpen;
        private ns1.BunifuCustomLabel bunifuCustomLabel6;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.ToolTip tooltip1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private ns1.BunifuCustomLabel bunifuCustomLabel7;
    }
}