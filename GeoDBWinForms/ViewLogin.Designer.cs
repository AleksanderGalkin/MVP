namespace GeoDBWinForms
{
    partial class ViewLogin
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
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.cbServerName = new System.Windows.Forms.ComboBox();
            this.cbDbName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbServerOrDesktop = new System.Windows.Forms.GroupBox();
            this.btDbFileName = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDbFileName = new System.Windows.Forms.ComboBox();
            this.rbDesktop = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.gbServerOrDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(364, 20);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(364, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbUserName
            // 
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(113, 20);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(121, 21);
            this.cbUserName.TabIndex = 1;
            // 
            // cbServerName
            // 
            this.cbServerName.FormattingEnabled = true;
            this.cbServerName.Location = new System.Drawing.Point(78, 53);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Size = new System.Drawing.Size(121, 21);
            this.cbServerName.TabIndex = 0;
            // 
            // cbDbName
            // 
            this.cbDbName.FormattingEnabled = true;
            this.cbDbName.Location = new System.Drawing.Point(78, 83);
            this.cbDbName.Name = "cbDbName";
            this.cbDbName.Size = new System.Drawing.Size(121, 21);
            this.cbDbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Database";
            // 
            // gbServerOrDesktop
            // 
            this.gbServerOrDesktop.Controls.Add(this.btDbFileName);
            this.gbServerOrDesktop.Controls.Add(this.label5);
            this.gbServerOrDesktop.Controls.Add(this.cbDbFileName);
            this.gbServerOrDesktop.Controls.Add(this.rbDesktop);
            this.gbServerOrDesktop.Controls.Add(this.rbServer);
            this.gbServerOrDesktop.Controls.Add(this.cbServerName);
            this.gbServerOrDesktop.Controls.Add(this.label4);
            this.gbServerOrDesktop.Controls.Add(this.cbDbName);
            this.gbServerOrDesktop.Controls.Add(this.label3);
            this.gbServerOrDesktop.Location = new System.Drawing.Point(35, 58);
            this.gbServerOrDesktop.Name = "gbServerOrDesktop";
            this.gbServerOrDesktop.Size = new System.Drawing.Size(511, 126);
            this.gbServerOrDesktop.TabIndex = 13;
            this.gbServerOrDesktop.TabStop = false;
            this.gbServerOrDesktop.Text = "Database location";
            // 
            // btDbFileName
            // 
            this.btDbFileName.Location = new System.Drawing.Point(473, 51);
            this.btDbFileName.Name = "btDbFileName";
            this.btDbFileName.Size = new System.Drawing.Size(29, 23);
            this.btDbFileName.TabIndex = 17;
            this.btDbFileName.Text = "...";
            this.btDbFileName.UseVisualStyleBackColor = true;
            this.btDbFileName.Click += new System.EventHandler(this.btDbFileName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "DB file";
            // 
            // cbDbFileName
            // 
            this.cbDbFileName.FormattingEnabled = true;
            this.cbDbFileName.Location = new System.Drawing.Point(266, 53);
            this.cbDbFileName.Name = "cbDbFileName";
            this.cbDbFileName.Size = new System.Drawing.Size(201, 21);
            this.cbDbFileName.TabIndex = 0;
            // 
            // rbDesktop
            // 
            this.rbDesktop.AutoSize = true;
            this.rbDesktop.Location = new System.Drawing.Point(276, 24);
            this.rbDesktop.Name = "rbDesktop";
            this.rbDesktop.Size = new System.Drawing.Size(82, 17);
            this.rbDesktop.TabIndex = 0;
            this.rbDesktop.TabStop = true;
            this.rbDesktop.Text = "On Desktop";
            this.rbDesktop.UseVisualStyleBackColor = true;
            this.rbDesktop.CheckedChanged += new System.EventHandler(this.rbDesktop_CheckedChanged);
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Location = new System.Drawing.Point(75, 22);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(71, 17);
            this.rbServer.TabIndex = 0;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "On server";
            this.rbServer.UseVisualStyleBackColor = true;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // ViewLogin
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(594, 230);
            this.Controls.Add(this.gbServerOrDesktop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.gbServerOrDesktop.ResumeLayout(false);
            this.gbServerOrDesktop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.ComboBox cbServerName;
        private System.Windows.Forms.ComboBox cbDbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbServerOrDesktop;
        private System.Windows.Forms.RadioButton rbDesktop;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDbFileName;
        private System.Windows.Forms.Button btDbFileName;
    }
}