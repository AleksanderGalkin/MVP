namespace GeoDBWinForms
{
    partial class ViewException
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
            this.rtbError = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbError
            // 
            this.rtbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbError.Location = new System.Drawing.Point(0, 0);
            this.rtbError.Name = "rtbError";
            this.rtbError.Size = new System.Drawing.Size(539, 263);
            this.rtbError.TabIndex = 0;
            this.rtbError.Text = "";
            // 
            // ViewException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 263);
            this.Controls.Add(this.rtbError);
            this.Name = "ViewException";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewException_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbError;
    }
}