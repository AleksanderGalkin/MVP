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
            this.dataGVCollar2 = new System.Windows.Forms.DataGridView();
            this.btShowData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVCollar2
            // 
            this.dataGVCollar2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVCollar2.Location = new System.Drawing.Point(42, 12);
            this.dataGVCollar2.Name = "dataGVCollar2";
            this.dataGVCollar2.Size = new System.Drawing.Size(676, 327);
            this.dataGVCollar2.TabIndex = 0;
            // 
            // btShowData
            // 
            this.btShowData.Location = new System.Drawing.Point(360, 369);
            this.btShowData.Name = "btShowData";
            this.btShowData.Size = new System.Drawing.Size(75, 23);
            this.btShowData.TabIndex = 1;
            this.btShowData.Text = "button1";
            this.btShowData.UseVisualStyleBackColor = true;
            this.btShowData.Click += new System.EventHandler(this.btShowData_Click);
            // 
            // ViewCollar2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 404);
            this.Controls.Add(this.btShowData);
            this.Controls.Add(this.dataGVCollar2);
            this.Name = "ViewCollar2";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVCollar2;
        private System.Windows.Forms.Button btShowData;
    }
}