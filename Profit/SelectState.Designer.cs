namespace Profit
{
    partial class SelectState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectState));
            this.rbConcluido = new System.Windows.Forms.RadioButton();
            this.rbPendente = new System.Windows.Forms.RadioButton();
            this.rbCancelado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // rbConcluido
            // 
            this.rbConcluido.AutoSize = true;
            this.rbConcluido.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConcluido.Location = new System.Drawing.Point(29, 43);
            this.rbConcluido.Name = "rbConcluido";
            this.rbConcluido.Size = new System.Drawing.Size(91, 20);
            this.rbConcluido.TabIndex = 0;
            this.rbConcluido.TabStop = true;
            this.rbConcluido.Text = "CONCLUÍDO";
            this.toolTip1.SetToolTip(this.rbConcluido, "Atalho: 1");
            this.rbConcluido.UseVisualStyleBackColor = true;
            // 
            // rbPendente
            // 
            this.rbPendente.AutoSize = true;
            this.rbPendente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPendente.Location = new System.Drawing.Point(148, 43);
            this.rbPendente.Name = "rbPendente";
            this.rbPendente.Size = new System.Drawing.Size(85, 20);
            this.rbPendente.TabIndex = 0;
            this.rbPendente.TabStop = true;
            this.rbPendente.Text = "PENDENTE";
            this.toolTip1.SetToolTip(this.rbPendente, "Atalho: 2");
            this.rbPendente.UseVisualStyleBackColor = true;
            // 
            // rbCancelado
            // 
            this.rbCancelado.AutoSize = true;
            this.rbCancelado.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCancelado.Location = new System.Drawing.Point(261, 43);
            this.rbCancelado.Name = "rbCancelado";
            this.rbCancelado.Size = new System.Drawing.Size(93, 20);
            this.rbCancelado.TabIndex = 0;
            this.rbCancelado.TabStop = true;
            this.rbCancelado.Text = "CANCELADO";
            this.toolTip1.SetToolTip(this.rbCancelado, "Atalho: 3");
            this.rbCancelado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Caviar Dreams", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECIONE O STATUS DO PEDIDO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(0, 66);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(378, 50);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "CONFIRMAR";
            this.toolTip1.SetToolTip(this.btnConfirm, "Atalho: enter");
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // SelectState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(376, 116);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbCancelado);
            this.Controls.Add(this.rbPendente);
            this.Controls.Add(this.rbConcluido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado do Pedido";
            this.Load += new System.EventHandler(this.SelectState_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbConcluido;
        private System.Windows.Forms.RadioButton rbPendente;
        private System.Windows.Forms.RadioButton rbCancelado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}