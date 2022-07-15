namespace CollegeLMS.Video {
    partial class showVideos {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbTitle = new System.Windows.Forms.RadioButton();
            this.rbAuth = new System.Windows.Forms.RadioButton();
            this.rdGen = new System.Windows.Forms.RadioButton();
            this.rbLan = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlUsername.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CollegeLMS.Properties.Resources.rightBack;
            this.pictureBox1.Location = new System.Drawing.Point(-54, -815);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 1989);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CollegeLMS.Properties.Resources.leftBack;
            this.pictureBox2.Location = new System.Drawing.Point(993, -66);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 686);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pnlResults
            // 
            this.pnlResults.AutoScroll = true;
            this.pnlResults.Location = new System.Drawing.Point(41, 177);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(948, 423);
            this.pnlResults.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "Search for Books by Title, Author, Genre, Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 35);
            this.label1.TabIndex = 42;
            this.label1.Text = "SEARCH FOR DOCUMENTRIES";
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.pnlUsername.Controls.Add(this.panel2);
            this.pnlUsername.Location = new System.Drawing.Point(53, 98);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(547, 40);
            this.pnlUsername.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 38);
            this.panel2.TabIndex = 9;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(5, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(533, 21);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.txtSearch.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(605, 98);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSearch.Size = new System.Drawing.Size(176, 40);
            this.btnSearch.TabIndex = 44;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnPrintCard_Click);
            // 
            // rbTitle
            // 
            this.rbTitle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbTitle.Checked = true;
            this.rbTitle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbTitle.FlatAppearance.BorderSize = 2;
            this.rbTitle.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.rbTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.rbTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.rbTitle.ForeColor = System.Drawing.Color.Black;
            this.rbTitle.Location = new System.Drawing.Point(54, 70);
            this.rbTitle.Name = "rbTitle";
            this.rbTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rbTitle.Size = new System.Drawing.Size(68, 28);
            this.rbTitle.TabIndex = 48;
            this.rbTitle.TabStop = true;
            this.rbTitle.Text = "Title";
            this.rbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbTitle.UseVisualStyleBackColor = false;
            this.rbTitle.Click += new System.EventHandler(this.rbTitle_Click);
            // 
            // rbAuth
            // 
            this.rbAuth.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbAuth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbAuth.FlatAppearance.BorderSize = 2;
            this.rbAuth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.rbAuth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.rbAuth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.rbAuth.ForeColor = System.Drawing.Color.Black;
            this.rbAuth.Location = new System.Drawing.Point(291, 70);
            this.rbAuth.Name = "rbAuth";
            this.rbAuth.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rbAuth.Size = new System.Drawing.Size(77, 28);
            this.rbAuth.TabIndex = 49;
            this.rbAuth.Text = "Author";
            this.rbAuth.UseVisualStyleBackColor = false;
            this.rbAuth.CheckedChanged += new System.EventHandler(this.rbAuth_CheckedChanged);
            // 
            // rdGen
            // 
            this.rdGen.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rdGen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rdGen.FlatAppearance.BorderSize = 2;
            this.rdGen.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.rdGen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.rdGen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.rdGen.ForeColor = System.Drawing.Color.Black;
            this.rdGen.Location = new System.Drawing.Point(123, 70);
            this.rdGen.Name = "rdGen";
            this.rdGen.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rdGen.Size = new System.Drawing.Size(70, 28);
            this.rdGen.TabIndex = 50;
            this.rdGen.Text = "Genre";
            this.rdGen.UseVisualStyleBackColor = false;
            this.rdGen.CheckedChanged += new System.EventHandler(this.rdGen_CheckedChanged);
            // 
            // rbLan
            // 
            this.rbLan.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbLan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbLan.FlatAppearance.BorderSize = 2;
            this.rbLan.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.rbLan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.rbLan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.rbLan.ForeColor = System.Drawing.Color.Black;
            this.rbLan.Location = new System.Drawing.Point(194, 70);
            this.rbLan.Name = "rbLan";
            this.rbLan.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rbLan.Size = new System.Drawing.Size(96, 28);
            this.rbLan.TabIndex = 51;
            this.rbLan.Text = "Language";
            this.rbLan.UseVisualStyleBackColor = false;
            this.rbLan.CheckedChanged += new System.EventHandler(this.rbLan_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 52;
            this.label3.Text = "Search Results: ";
            // 
            // lblRes
            // 
            this.lblRes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblRes.Location = new System.Drawing.Point(148, 150);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(455, 15);
            this.lblRes.TabIndex = 53;
            this.lblRes.Text = "Search Results";
            // 
            // showVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 610);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbLan);
            this.Controls.Add(this.rdGen);
            this.Controls.Add(this.rbAuth);
            this.Controls.Add(this.rbTitle);
            this.Controls.Add(this.pnlUsername);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "showVideo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Documentries - CLMS Control Panel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlUsername.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbTitle;
        private System.Windows.Forms.RadioButton rbAuth;
        private System.Windows.Forms.RadioButton rdGen;
        private System.Windows.Forms.RadioButton rbLan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRes;
    }
}