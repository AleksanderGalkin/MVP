namespace GeoDBWinForms
{
    partial class ViewDrillHoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDrillHoles));
            this.dataGVCollar2 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGVAssays2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVAssays2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVCollar2
            // 
            this.dataGVCollar2.AllowUserToAddRows = false;
            this.dataGVCollar2.AllowUserToDeleteRows = false;
            this.dataGVCollar2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVCollar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGVCollar2.Location = new System.Drawing.Point(0, 0);
            this.dataGVCollar2.MultiSelect = false;
            this.dataGVCollar2.Name = "dataGVCollar2";
            this.dataGVCollar2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVCollar2.Size = new System.Drawing.Size(624, 302);
            this.dataGVCollar2.TabIndex = 0;
            this.dataGVCollar2.VirtualMode = true;
            this.dataGVCollar2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGVCollar2_CellMouseClick);
            this.dataGVCollar2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGVCollar2_CellPainting);
            this.dataGVCollar2.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGVCollar2_CellValueNeeded);
            this.dataGVCollar2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGVCollar2_ColumnHeaderMouseClick);
            this.dataGVCollar2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVCollar2_RowEnter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2MinSize = 30;
            this.splitContainer1.Size = new System.Drawing.Size(624, 442);
            this.splitContainer1.SplitterDistance = 407;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGVCollar2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGVAssays2);
            this.splitContainer2.Size = new System.Drawing.Size(624, 407);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGVAssays2
            // 
            this.dataGVAssays2.AllowUserToAddRows = false;
            this.dataGVAssays2.AllowUserToDeleteRows = false;
            this.dataGVAssays2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVAssays2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGVAssays2.Location = new System.Drawing.Point(0, 0);
            this.dataGVAssays2.MultiSelect = false;
            this.dataGVAssays2.Name = "dataGVAssays2";
            this.dataGVAssays2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVAssays2.Size = new System.Drawing.Size(624, 101);
            this.dataGVAssays2.TabIndex = 0;
            this.dataGVAssays2.VirtualMode = true;
            this.dataGVAssays2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGVAssays2_CellMouseClick);
            this.dataGVAssays2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGVAssays2_CellPainting);
            this.dataGVAssays2.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGVAssays2_CellValueNeeded);
            this.dataGVAssays2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGVAssays2_ColumnHeaderMouseClick);
            // 
            // ViewDrillHoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "ViewDrillHoles";
            this.Text = "Скважины и Пробы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewDrillHoles_FormClosing);
            this.Resize += new System.EventHandler(this.ViewDrillHoles_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVAssays2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVCollar2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGVAssays2;
    }
}