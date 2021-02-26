namespace Profit
{
    partial class PicPayForm
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
            this.btnPay = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(419, 102);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "PAGAR";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(405, 188);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 0;
            this.btnStatus.Text = "STATUS";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // PicPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnPay);
            this.Name = "PicPay";
            this.Text = "PicPay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnStatus;
    }
}