namespace CollegeLMS.Comics {
    partial class showQR {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.picCode = new System.Windows.Forms.PictureBox();
            this.btnPrintCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            this.SuspendLayout();
            // 
            // picCode
            // 
            this.picCode.BackColor = System.Drawing.Color.White;
            this.picCode.Location = new System.Drawing.Point(12, 13);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(200, 200);
            this.picCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCode.TabIndex = 60;
            this.picCode.TabStop = false;
            // 
            // btnPrintCard
            // 
            this.btnPrintCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.btnPrintCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCard.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPrintCard.ForeColor = System.Drawing.Color.White;
            this.btnPrintCard.Location = new System.Drawing.Point(12, 219);
            this.btnPrintCard.Name = "btnPrintCard";
            this.btnPrintCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrintCard.Size = new System.Drawing.Size(200, 29);
            this.btnPrintCard.TabIndex = 59;
            this.btnPrintCard.Text = "PRINT QR CODE";
            this.btnPrintCard.UseVisualStyleBackColor = false;
            this.btnPrintCard.Click += new System.EventHandler(this.btnPrintCard_Click);
            // 
            // showQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(224, 260);
            this.Controls.Add(this.picCode);
            this.Controls.Add(this.btnPrintCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "showQR";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR Code for Comic";
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCode;
        private System.Windows.Forms.Button btnPrintCard;
    }
}