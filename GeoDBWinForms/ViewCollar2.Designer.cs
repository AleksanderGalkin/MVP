namespace GeoDBWinForms
{
    partial class ViewCollar2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCollar2));
            this.dataGVCollar2 = new System.Windows.Forms.DataGridView();
            this.btShowData = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btCloseForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGVCollar2
            // 
            this.dataGVCollar2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVCollar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGVCollar2.Location = new System.Drawing.Point(0, 0);
            this.dataGVCollar2.Name = "dataGVCollar2";
            this.dataGVCollar2.Size = new System.Drawing.Size(624, 338);
            this.dataGVCollar2.TabIndex = 0;
            // 
            // btShowData
            // 
            this.btShowData.Location = new System.Drawing.Point(368, 21);
            this.btShowData.Name = "btShowData";
            this.btShowData.Size = new System.Drawing.Size(75, 23);
            this.btShowData.TabIndex = 1;
            this.btShowData.Text = "button1";
            this.btShowData.UseVisualStyleBackColor = true;
            this.btShowData.Click += new System.EventHandler(this.btShowData_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGVCollar2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.btCloseForm);
            this.splitContainer1.Panel2.Controls.Add(this.btShowData);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(624, 442);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 2;
            // 
            // btCloseForm
            // 
            this.btCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCloseForm.Location = new System.Drawing.Point(509, 21);
            this.btCloseForm.Name = "btCloseForm";
            this.btCloseForm.Size = new System.Drawing.Size(75, 23);
            this.btCloseForm.TabIndex = 2;
            this.btCloseForm.Text = "Закрыть";
            this.btCloseForm.UseVisualStyleBackColor = true;
            // 
            // ViewCollar2
            // 
            this.AcceptButton = this.btShowData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCloseForm;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "ViewCollar2";
            this.Text = "Скважины и Пробы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVCollar2;
        private System.Windows.Forms.Button btShowData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btCloseForm;
    }
}