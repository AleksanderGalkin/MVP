using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using testForms;



namespace testForms
{
    public partial class FormView : Form, IView
    {
        private Label label1;
        private Label label2;
        private Label _degreeFarenheitBox;
        private Label _degreeCelsiusBox;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton isFarenheitCb;
        private RadioButton isCelsiusCb; // 
        private TextBox _inputBox;
        private Label label6;
        private Label label7; 
        private Button _celsiusButton;
        #region Реализация IView

        public event EventHandler<EventArgs> SetDegreeEvent;

        /// <summary>
        /// Вывод градусов Фаренгейта
        /// </summary>
        public double Farenheit
        {
            set { _degreeFarenheitBox.Text = value.ToString("N2"); }
        }

        // <summary>
        /// Вывод градусов Цельсия
        /// </summary>
        public double Celsius
        {
            set { _degreeCelsiusBox.Text = value.ToString("N2"); }
        }

        /// <summary>
        /// флаг что значение градусы по цельсию
        /// </summary>
        public bool isInputDegreeIsCelsius
        {
            get { return isCelsiusCb.Checked; }
        }

        /// <summary>
        /// флаг что значение градусы по фаренгейту
        /// </summary>
        public bool isInputDegreeIsFarenheit
        {
            get { return isFarenheitCb.Checked; }
        }

        /// <summary>
        /// Ввод нового значения градусов
        /// </summary>
        public double InputDegree
        {
            get { return Convert.ToDouble(_inputBox.Text); }
        }

        #endregion

        /// <summary>
        /// Обработка событий тоже примитивна, они просто пробрасываются
        /// в соответствующие события Presenter-а
        /// </summary>
        private void _celsiusButton_Click(object sender, EventArgs e)
        {
            if (SetDegreeEvent != null)
                SetDegreeEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Показываем форму
        /// </summary>
        public new void Show()
        {
            Application.Run(this);
        }


        public FormView()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._degreeFarenheitBox = new System.Windows.Forms.Label();
            this._degreeCelsiusBox = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isCelsiusCb = new System.Windows.Forms.RadioButton();
            this.isFarenheitCb = new System.Windows.Forms.RadioButton();
            this._inputBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._celsiusButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(67, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "градусы по Фарингейту";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(253, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "градусы по Цельсию";
            // 
            // _degreeFarenheitBox
            // 
            this._degreeFarenheitBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._degreeFarenheitBox.Location = new System.Drawing.Point(67, 58);
            this._degreeFarenheitBox.Name = "_degreeFarenheitBox";
            this._degreeFarenheitBox.Size = new System.Drawing.Size(100, 23);
            this._degreeFarenheitBox.TabIndex = 2;
            // 
            // _degreeCelsiusBox
            // 
            this._degreeCelsiusBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._degreeCelsiusBox.Location = new System.Drawing.Point(256, 59);
            this._degreeCelsiusBox.Name = "_degreeCelsiusBox";
            this._degreeCelsiusBox.Size = new System.Drawing.Size(100, 23);
            this._degreeCelsiusBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(64, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Установить температуру на ...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isCelsiusCb);
            this.groupBox1.Controls.Add(this.isFarenheitCb);
            this.groupBox1.Location = new System.Drawing.Point(431, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.isCelsiusCb.AutoSize = true;
            this.isCelsiusCb.Location = new System.Drawing.Point(7, 44);
            this.isCelsiusCb.Name = "radioButton2";
            this.isCelsiusCb.Size = new System.Drawing.Size(69, 17);
            this.isCelsiusCb.TabIndex = 1;
            this.isCelsiusCb.TabStop = true;
            this.isCelsiusCb.Text = "цельсию";
            this.isCelsiusCb.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.isFarenheitCb.AutoSize = true;
            this.isFarenheitCb.Location = new System.Drawing.Point(7, 19);
            this.isFarenheitCb.Name = "radioButton1";
            this.isFarenheitCb.Size = new System.Drawing.Size(84, 17);
            this.isFarenheitCb.TabIndex = 0;
            this.isFarenheitCb.TabStop = true;
            this.isFarenheitCb.Text = "фарингейту";
            this.isFarenheitCb.UseVisualStyleBackColor = true;
            // 
            // _inputBox
            // 
            this._inputBox.Location = new System.Drawing.Point(245, 102);
            this._inputBox.Name = "_inputBox";
            this._inputBox.Size = new System.Drawing.Size(71, 20);
            this._inputBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(125, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Температура на объекте";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(322, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "... градусов по ..";
            // 
            // _celsiusButton
            // 
            this._celsiusButton.Location = new System.Drawing.Point(67, 150);
            this._celsiusButton.Name = "_celsiusButton";
            this._celsiusButton.Size = new System.Drawing.Size(289, 23);
            this._celsiusButton.TabIndex = 9;
            this._celsiusButton.Text = "Ок";
            this._celsiusButton.UseVisualStyleBackColor = true;
            this._celsiusButton.Click += new System.EventHandler(this._celsiusButton_Click);
            // 
            // FormView
            // 
            this.ClientSize = new System.Drawing.Size(541, 262);
            this.Controls.Add(this._celsiusButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._inputBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._degreeCelsiusBox);
            this.Controls.Add(this._degreeFarenheitBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }

}
