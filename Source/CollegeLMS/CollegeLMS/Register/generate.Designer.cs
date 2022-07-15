namespace CollegeLMS.Register {
    partial class generate {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblP = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNIC = new System.Windows.Forms.TextBox();
            this.lblU = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.picUsername = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnTakePicture = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.picBook = new System.Windows.Forms.PictureBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.pnlPassword.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(550, 276);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(210, 29);
            this.btnGenerate.TabIndex = 28;
            this.btnGenerate.Text = "GENERATE REGISTRATION CODE";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblP.Location = new System.Drawing.Point(789, 228);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(118, 15);
            this.lblP.TabIndex = 27;
            this.lblP.Text = "Username is Invalid";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblP.Visible = false;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.pnlPassword.Controls.Add(this.panel3);
            this.pnlPassword.Location = new System.Drawing.Point(465, 216);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(295, 40);
            this.pnlPassword.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.txtNIC);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 38);
            this.panel3.TabIndex = 9;
            this.panel3.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // txtNIC
            // 
            this.txtNIC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtNIC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNIC.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNIC.ForeColor = System.Drawing.Color.Black;
            this.txtNIC.Location = new System.Drawing.Point(9, 9);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.Size = new System.Drawing.Size(275, 21);
            this.txtNIC.TabIndex = 7;
            this.txtNIC.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.txtNIC.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // lblU
            // 
            this.lblU.AutoSize = true;
            this.lblU.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblU.Location = new System.Drawing.Point(788, 170);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(118, 15);
            this.lblU.TabIndex = 24;
            this.lblU.Text = "Username is Invalid";
            this.lblU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblU.Visible = false;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.pnlUsername.Controls.Add(this.panel2);
            this.pnlUsername.Location = new System.Drawing.Point(465, 158);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(295, 40);
            this.pnlUsername.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.txtUID);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 38);
            this.panel2.TabIndex = 9;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // txtUID
            // 
            this.txtUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUID.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUID.ForeColor = System.Drawing.Color.Black;
            this.txtUID.Location = new System.Drawing.Point(9, 9);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(275, 21);
            this.txtUID.TabIndex = 7;
            this.txtUID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUID_KeyDown);
            this.txtUID.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.txtUID.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "NIC Number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "University ID ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(482, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Generate an Unique Registration Code for New Members";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 35);
            this.label1.TabIndex = 18;
            this.label1.Text = "UNIQUE REGISTRATION CODE";
            // 
            // picPassword
            // 
            this.picPassword.Location = new System.Drawing.Point(760, 222);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(27, 27);
            this.picPassword.TabIndex = 26;
            this.picPassword.TabStop = false;
            this.picPassword.Visible = false;
            // 
            // picUsername
            // 
            this.picUsername.Location = new System.Drawing.Point(760, 164);
            this.picUsername.Name = "picUsername";
            this.picUsername.Size = new System.Drawing.Size(27, 27);
            this.picUsername.TabIndex = 23;
            this.picUsername.TabStop = false;
            this.picUsername.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CollegeLMS.Properties.Resources.leftBack;
            this.pictureBox2.Location = new System.Drawing.Point(938, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 686);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CollegeLMS.Properties.Resources.rightBack;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 1989);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.lblWarning.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Location = new System.Drawing.Point(372, 330);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(444, 29);
            this.lblWarning.TabIndex = 29;
            this.lblWarning.Text = "This UNIVERSITY ID AND NIC NUMBER are Already Registered";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarning.Visible = false;
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.BackColor = System.Drawing.Color.Teal;
            this.btnTakePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTakePicture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTakePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakePicture.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTakePicture.ForeColor = System.Drawing.Color.White;
            this.btnTakePicture.Location = new System.Drawing.Point(70, 307);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(240, 29);
            this.btnTakePicture.TabIndex = 33;
            this.btnTakePicture.Text = "Take Picture";
            this.btnTakePicture.UseVisualStyleBackColor = false;
            this.btnTakePicture.Visible = false;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(79, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 22);
            this.label8.TabIndex = 31;
            this.label8.Text = "Member Picture for ID Card";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBook
            // 
            this.picBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBook.Location = new System.Drawing.Point(66, 84);
            this.picBook.Name = "picBook";
            this.picBook.Size = new System.Drawing.Size(248, 221);
            this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBook.TabIndex = 30;
            this.picBook.TabStop = false;
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.Teal;
            this.btnChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnChoose.ForeColor = System.Drawing.Color.White;
            this.btnChoose.Location = new System.Drawing.Point(192, 306);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(118, 29);
            this.btnChoose.TabIndex = 37;
            this.btnChoose.Text = "Browse";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.BackColor = System.Drawing.Color.Teal;
            this.btnCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCamera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCamera.ForeColor = System.Drawing.Color.White;
            this.btnCamera.Location = new System.Drawing.Point(69, 306);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(123, 29);
            this.btnCamera.TabIndex = 36;
            this.btnCamera.Text = "From Camera";
            this.btnCamera.UseVisualStyleBackColor = false;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Images|*.jpg";
            // 
            // generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(979, 403);
            this.Controls.Add(this.btnTakePicture);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.picBook);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.picPassword);
            this.Controls.Add(this.pnlPassword);
            this.Controls.Add(this.lblU);
            this.Controls.Add(this.picUsername);
            this.Controls.Add(this.pnlUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnCamera);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "generate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Registration Code - CLMS";
            this.pnlPassword.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNIC;
        private System.Windows.Forms.Label lblU;
        private System.Windows.Forms.PictureBox picUsername;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnTakePicture;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picBook;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
    }
}