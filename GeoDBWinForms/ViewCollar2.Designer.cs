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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGVAssays2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Example = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btCloseForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCollar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVAssays2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVCollar2
            // 
            this.dataGVCollar2.AllowUserToAddRows = false;
            this.dataGVCollar2.AllowUserToDeleteRows = false;
            this.dataGVCollar2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVCollar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGVCollar2.Location = new System.Drawing.Point(0, 0);
            this.dataGVCollar2.Name = "dataGVCollar2";
            this.dataGVCollar2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVCollar2.Size = new System.Drawing.Size(624, 169);
            this.dataGVCollar2.TabIndex = 0;
            this.dataGVCollar2.VirtualMode = true;
            this.dataGVCollar2.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGVCollar2_CellValueNeeded);
            this.dataGVCollar2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVCollar2_RowEnter);
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.btCloseForm);
            this.splitContainer1.Panel2.Controls.Add(this.btShowData);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(624, 442);
            this.splitContainer1.SplitterDistance = 338;
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
            this.splitContainer2.Size = new System.Drawing.Size(624, 338);
            this.splitContainer2.SplitterDistance = 169;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGVAssays2
            // 
            this.dataGVAssays2.AllowUserToAddRows = false;
            this.dataGVAssays2.AllowUserToDeleteRows = false;
            this.dataGVAssays2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVAssays2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGVAssays2.Location = new System.Drawing.Point(0, 0);
            this.dataGVAssays2.Name = "dataGVAssays2";
            this.dataGVAssays2.Size = new System.Drawing.Size(624, 165);
            this.dataGVAssays2.TabIndex = 0;
            this.dataGVAssays2.VirtualMode = true;
            this.dataGVAssays2.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGVAssays2_CellValueNeeded);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Example});
            this.dataGridView1.Location = new System.Drawing.Point(42, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(216, 76);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Example
            // 
            this.Example.HeaderText = "Пример";
            this.Example.Name = "Example";
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
            this.btCloseForm.Click += new System.EventHandler(this.btCloseForm_Click);
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVAssays2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVCollar2;
        private System.Windows.Forms.Button btShowData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btCloseForm;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGVAssays2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Example;
    }
}