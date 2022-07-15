namespace CollegeLMS {
    partial class startUpCheck {
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
            this.components = new System.ComponentModel.Container();
            this.pnlCore = new System.Windows.Forms.Panel();
            this.pnlTransaction = new System.Windows.Forms.Panel();
            this.pnlDatabase = new System.Windows.Forms.Panel();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.lblCore = new System.Windows.Forms.Label();
            this.lblTransaction = new System.Windows.Forms.Label();
            this.lblDatabse = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCore
            // 
            this.pnlCore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.pnlCore.Location = new System.Drawing.Point(95, 84);
            this.pnlCore.Name = "pnlCore";
            this.pnlCore.Size = new System.Drawing.Size(33, 30);
            this.pnlCore.TabIndex = 0;
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.pnlTransaction.Location = new System.Drawing.Point(95, 120);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.Size = new System.Drawing.Size(33, 30);
            this.pnlTransaction.TabIndex = 1;
            // 
            // pnlDatabase
            // 
            this.pnlDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.pnlDatabase.Location = new System.Drawing.Point(95, 156);
            this.pnlDatabase.Name = "pnlDatabase";
            this.pnlDatabase.Size = new System.Drawing.Size(33, 30);
            this.pnlDatabase.TabIndex = 2;
            // 
            // pnlFile
            // 
            this.pnlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.pnlFile.Location = new System.Drawing.Point(95, 192);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(33, 30);
            this.pnlFile.TabIndex = 3;
            // 
            // lblCore
            // 
            this.lblCore.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCore.ForeColor = System.Drawing.Color.Black;
            this.lblCore.Location = new System.Drawing.Point(133, 84);
            this.lblCore.Name = "lblCore";
            this.lblCore.Size = new System.Drawing.Size(328, 30);
            this.lblCore.TabIndex = 4;
            this.lblCore.Text = "Core Components Loaded";
            this.lblCore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransaction
            // 
            this.lblTransaction.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransaction.ForeColor = System.Drawing.Color.Black;
            this.lblTransaction.Location = new System.Drawing.Point(133, 120);
            this.lblTransaction.Name = "lblTransaction";
            this.lblTransaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTransaction.Size = new System.Drawing.Size(306, 30);
            this.lblTransaction.TabIndex = 5;
            this.lblTransaction.Text = "Transaction Server";
            this.lblTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatabse
            // 
            this.lblDatabse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabse.ForeColor = System.Drawing.Color.Black;
            this.lblDatabse.Location = new System.Drawing.Point(133, 156);
            this.lblDatabse.Name = "lblDatabse";
            this.lblDatabse.Size = new System.Drawing.Size(306, 30);
            this.lblDatabse.TabIndex = 6;
            this.lblDatabse.Text = "Database Server";
            this.lblDatabse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFile
            // 
            this.lblFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.ForeColor = System.Drawing.Color.Black;
            this.lblFile.Location = new System.Drawing.Point(133, 192);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(306, 30);
            this.lblFile.TabIndex = 7;
            this.lblFile.Text = "File Server";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(90, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Establishing Connections and waiting for server responses";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tim
            // 
            this.tim.Enabled = true;
            this.tim.Interval = 93;
            this.tim.Tick += new System.EventHandler(this.tim_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CollegeLMS.Properties.Resources.rightBack;
            this.pictureBox1.Location = new System.Drawing.Point(-16, -774);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 1989);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CollegeLMS.Properties.Resources.leftBack;
            this.pictureBox2.Location = new System.Drawing.Point(471, -149);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 667);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 35);
            this.label1.TabIndex = 39;
            this.label1.Text = "SERVER CONNECTIONS";
            // 
            // startUpCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 243);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblDatabse);
            this.Controls.Add(this.lblTransaction);
            this.Controls.Add(this.lblCore);
            this.Controls.Add(this.pnlFile);
            this.Controls.Add(this.pnlDatabase);
            this.Controls.Add(this.pnlTransaction);
            this.Controls.Add(this.pnlCore);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "startUpCheck";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Establishing Server Connections";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCore;
        private System.Windows.Forms.Panel pnlTransaction;
        private System.Windows.Forms.Panel pnlDatabase;
        private System.Windows.Forms.Panel pnlFile;
        private System.Windows.Forms.Label lblCore;
        private System.Windows.Forms.Label lblTransaction;
        private System.Windows.Forms.Label lblDatabse;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tim;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}