namespace GeoDBWinForms
{
    partial class ViewAssays2Crud
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
            this.tbSample = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbZblok = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLito = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Дата = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGeologist = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPit = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbJournal = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbBlank = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRang = new System.Windows.Forms.ComboBox();
            this.errorProviderWarn = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWarn)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSample
            // 
            this.tbSample.Location = new System.Drawing.Point(30, 49);
            this.tbSample.Name = "tbSample";
            this.tbSample.Size = new System.Drawing.Size(67, 20);
            this.tbSample.TabIndex = 3;
            this.tbSample.Validating += new System.ComponentModel.CancelEventHandler(this.tbHole_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "№ Пробы";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(121, 48);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(67, 20);
            this.tbFrom.TabIndex = 8;
            this.tbFrom.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(212, 48);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(67, 20);
            this.tbTo.TabIndex = 9;
            this.tbTo.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(303, 48);
            this.tbLength.Name = "tbLength";
            this.tbLength.Size = new System.Drawing.Size(67, 20);
            this.tbLength.TabIndex = 10;
            this.tbLength.Validating += new System.ComponentModel.CancelEventHandler(this.tbX_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "От";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "До";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Длина";
            // 
            // cbZblok
            // 
            this.cbZblok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZblok.FormattingEnabled = true;
            this.cbZblok.Location = new System.Drawing.Point(30, 103);
            this.cbZblok.Name = "cbZblok";
            this.cbZblok.Size = new System.Drawing.Size(88, 21);
            this.cbZblok.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Блокировка";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(216, 271);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 18;
            this.btOk.Text = "ОК";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(297, 271);
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
            this.label10.Location = new System.Drawing.Point(148, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Литология";
            // 
            // cbLito
            // 
            this.cbLito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLito.FormattingEnabled = true;
            this.cbLito.Location = new System.Drawing.Point(151, 103);
            this.cbLito.Name = "cbLito";
            this.cbLito.Size = new System.Drawing.Size(88, 21);
            this.cbLito.TabIndex = 20;
            this.cbLito.Validating += new System.ComponentModel.CancelEventHandler(this.cbGorizont_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Дата);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbGeologist);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbPit);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbJournal);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbBlank);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbRang);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbLito);
            this.groupBox1.Controls.Add(this.tbSample);
            this.groupBox1.Controls.Add(this.btClose);
            this.groupBox1.Controls.Add(this.btOk);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbFrom);
            this.groupBox1.Controls.Add(this.cbZblok);
            this.groupBox1.Controls.Add(this.tbTo);
            this.groupBox1.Controls.Add(this.tbLength);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 312);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пробы взрывных скважин";
            // 
            // Дата
            // 
            this.Дата.AutoSize = true;
            this.Дата.Location = new System.Drawing.Point(148, 195);
            this.Дата.Name = "Дата";
            this.Дата.Size = new System.Drawing.Size(42, 13);
            this.Дата.TabIndex = 33;
            this.Дата.Text = "Геолог";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(151, 216);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(128, 20);
            this.dtpEndDate.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Геолог";
            // 
            // cbGeologist
            // 
            this.cbGeologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGeologist.FormattingEnabled = true;
            this.cbGeologist.Location = new System.Drawing.Point(30, 216);
            this.cbGeologist.Name = "cbGeologist";
            this.cbGeologist.Size = new System.Drawing.Size(88, 21);
            this.cbGeologist.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Карьер";
            // 
            // cbPit
            // 
            this.cbPit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPit.FormattingEnabled = true;
            this.cbPit.Location = new System.Drawing.Point(285, 160);
            this.cbPit.Name = "cbPit";
            this.cbPit.Size = new System.Drawing.Size(88, 21);
            this.cbPit.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Журнал";
            // 
            // cbJournal
            // 
            this.cbJournal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJournal.FormattingEnabled = true;
            this.cbJournal.Location = new System.Drawing.Point(151, 160);
            this.cbJournal.Name = "cbJournal";
            this.cbJournal.Size = new System.Drawing.Size(88, 21);
            this.cbJournal.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Ведомость";
            // 
            // cbBlank
            // 
            this.cbBlank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlank.FormattingEnabled = true;
            this.cbBlank.Location = new System.Drawing.Point(30, 160);
            this.cbBlank.Name = "cbBlank";
            this.cbBlank.Size = new System.Drawing.Size(88, 21);
            this.cbBlank.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ранг";
            // 
            // cbRang
            // 
            this.cbRang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRang.FormattingEnabled = true;
            this.cbRang.Location = new System.Drawing.Point(285, 103);
            this.cbRang.Name = "cbRang";
            this.cbRang.Size = new System.Drawing.Size(88, 21);
            this.cbRang.TabIndex = 22;
            // 
            // errorProviderWarn
            // 
            this.errorProviderWarn.ContainerControl = this;
            // 
            // ViewAssays2Crud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 312);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ViewAssays2Crud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewCollar2Crud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewAssays2Crud_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWarn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbSample;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbZblok;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLito;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProviderWarn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbJournal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbBlank;
        private System.Windows.Forms.Label Дата;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGeologist;
    }
}