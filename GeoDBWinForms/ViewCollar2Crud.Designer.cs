namespace GeoDBWinForms
{
    partial class ViewCollar2Crud
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
            this.cbGorizont = new System.Windows.Forms.ComboBox();
            this.cbBlast = new System.Windows.Forms.ComboBox();
            this.tbHole = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbEndDepth = new System.Windows.Forms.TextBox();
            this.cbDrillType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDomen = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorProviderWarn = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWarn)).BeginInit();
            this.SuspendLayout();
            // 
            // cbGorizont
            // 
            this.cbGorizont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGorizont.FormattingEnabled = true;
            this.cbGorizont.Location = new System.Drawing.Point(30, 49);
            this.cbGorizont.Name = "cbGorizont";
            this.cbGorizont.Size = new System.Drawing.Size(61, 21);
            this.cbGorizont.TabIndex = 1;
            this.cbGorizont.Validating += new System.ComponentModel.CancelEventHandler(this.cbGorizont_Validating);
            // 
            // cbBlast
            // 
            this.cbBlast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlast.FormattingEnabled = true;
            this.cbBlast.Location = new System.Drawing.Point(117, 49);
            this.cbBlast.Name = "cbBlast";
            this.cbBlast.Size = new System.Drawing.Size(66, 21);
            this.cbBlast.TabIndex = 2;
            this.cbBlast.Validating += new System.ComponentModel.CancelEventHandler(this.cbGorizont_Validating);
            // 
            // tbHole
            // 
            this.tbHole.Location = new System.Drawing.Point(212, 49);
            this.tbHole.Name = "tbHole";
            this.tbHole.Size = new System.Drawing.Size(44, 20);
            this.tbHole.TabIndex = 3;
            this.tbHole.Validating += new System.ComponentModel.CancelEventHandler(this.tbHole_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Горизонт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Блок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Скважина";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(30, 96);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(67, 20);
            this.tbX.TabIndex = 8;
            this.tbX.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(117, 96);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(67, 20);
            this.tbY.TabIndex = 9;
            this.tbY.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(212, 96);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(67, 20);
            this.tbZ.TabIndex = 10;
            this.tbZ.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Z";
            // 
            // tbEndDepth
            // 
            this.tbEndDepth.Location = new System.Drawing.Point(30, 149);
            this.tbEndDepth.Name = "tbEndDepth";
            this.tbEndDepth.Size = new System.Drawing.Size(100, 20);
            this.tbEndDepth.TabIndex = 14;
            this.tbEndDepth.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // cbDrillType
            // 
            this.cbDrillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrillType.FormattingEnabled = true;
            this.cbDrillType.Location = new System.Drawing.Point(164, 148);
            this.cbDrillType.Name = "cbDrillType";
            this.cbDrillType.Size = new System.Drawing.Size(88, 21);
            this.cbDrillType.TabIndex = 15;
            this.cbDrillType.Validating += new System.ComponentModel.CancelEventHandler(this.cbGorizont_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Глубина скважины";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Станок";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(216, 236);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 18;
            this.btOk.Text = "ОК";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(297, 236);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 19;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Домен";
            // 
            // cbDomen
            // 
            this.cbDomen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDomen.FormattingEnabled = true;
            this.cbDomen.Location = new System.Drawing.Point(285, 148);
            this.cbDomen.Name = "cbDomen";
            this.cbDomen.Size = new System.Drawing.Size(88, 21);
            this.cbDomen.TabIndex = 20;
            this.cbDomen.Validating += new System.ComponentModel.CancelEventHandler(this.cbGorizont_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGorizont);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbBlast);
            this.groupBox1.Controls.Add(this.cbDomen);
            this.groupBox1.Controls.Add(this.tbHole);
            this.groupBox1.Controls.Add(this.btClose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btOk);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Controls.Add(this.cbDrillType);
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.tbEndDepth);
            this.groupBox1.Controls.Add(this.tbZ);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 278);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Устья скважин";
            // 
            // errorProviderWarn
            // 
            this.errorProviderWarn.ContainerControl = this;
            // 
            // ViewCollar2Crud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 278);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 316);
            this.MinimizeBox = false;
            this.Name = "ViewCollar2Crud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewCollar2Crud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewCollar2Crud_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWarn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGorizont;
        private System.Windows.Forms.ComboBox cbBlast;
        private System.Windows.Forms.TextBox tbHole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbEndDepth;
        private System.Windows.Forms.ComboBox cbDrillType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbDomen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProviderWarn;
    }
}