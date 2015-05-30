using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GeoDbUserInterface.View;


namespace GeoDBWinForms
{
    class NavigatorMenu:TableLayoutPanel
    {
        private List<IPopup> _popups;
        public NavigatorMenu(List<IPopup> PopupsList, Image Logotype)
            : base()
        {
            int row = 0;
            _popups = PopupsList;
            this.AutoScroll = false;
           // this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          //  this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            Label tittleNavigator = new Label();
            tittleNavigator.Text = "логотип";
            tittleNavigator.TextAlign = ContentAlignment.TopCenter;
            tittleNavigator.TextAlign = ContentAlignment.MiddleCenter;
            PictureBox logotype = new PictureBox();
            logotype.Dock = DockStyle.Fill;
            logotype.Image =  Logotype;
            logotype.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(logotype, 0, row);
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 25));
            

            row = row + 1;
            for (int i = 0; i < _popups.Count; i++ )
            {
                Button newButton = new Button();
                newButton.Text = _popups[i].tittle;
                newButton.Dock = System.Windows.Forms.DockStyle.Fill;
                newButton.FlatStyle = FlatStyle.Popup;
                newButton.MouseClick += new MouseEventHandler(OnPopupButton_MouseClick);
                newButton.Tag = i;
                this.Controls.Add(newButton, 0, row);
                this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                _popups[i].numRow = row;
                row = row + 1;

                TableLayoutPanel new2LevelTable = new TableLayoutPanel();
                new2LevelTable.AutoScroll = false;
                new2LevelTable.BackColor = System.Drawing.SystemColors.ActiveBorder;
                new2LevelTable.ColumnCount = 2;
                new2LevelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                new2LevelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
                new2LevelTable.Dock = System.Windows.Forms.DockStyle.Fill;
                new2LevelTable.Location = new System.Drawing.Point(3, 53);
                new2LevelTable.Name = "t2l" + row.ToString();
                new2LevelTable.RowCount = _popups[i].items.Count;
                new2LevelTable.AutoSize = false;
                

                new2LevelTable.Size = new System.Drawing.Size(114, 193);
                new2LevelTable.TabIndex = row;
                this.Controls.Add(new2LevelTable, 0, row);
                if (i == 0)
                {
                    this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, _popups[i].heigth));
                }
                else
                {
                    this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
                }

                row = row + 1;
                int row2level = 0;
                for (int j = 0; j < _popups[i].items.Count; j++ )
                {

                    Button new2LevelButton = new Button();
                    new2LevelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                    new2LevelButton.Dock = System.Windows.Forms.DockStyle.Fill;
                    new2LevelButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
                    new2LevelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                    new2LevelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                    new2LevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    new2LevelButton.Image = _popups[i].items[j].image;
                    new2LevelButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    new2LevelButton.Location = new System.Drawing.Point(3, 3);
                    new2LevelButton.Name = "b2l" + row.ToString();
                    new2LevelButton.MinimumSize = new System.Drawing.Size(100, 60);
                    new2LevelButton.MaximumSize = new System.Drawing.Size(100, 60);
                    new2LevelButton.TabIndex = 2;
                    new2LevelButton.Text = _popups[i].items[j].tittle;
                    new2LevelButton.Font = new Font(this.Font.FontFamily,8F);
                    new2LevelButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    new2LevelButton.UseVisualStyleBackColor = false;
                    new2LevelButton.Tag = _popups[i].items[j];
                    new2LevelButton.MouseClick += (t, e) => {
                        IItem item = (t as Button).Tag as IItem;
                        item.sendClickItem();
                    };

                   

                    new2LevelTable.Controls.Add(new2LevelButton, 0, row2level);
                    new2LevelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
                    row2level = row2level + 1;

                }
                OnPopupButton_MouseClick(this.Controls[1], MouseEventArgs.Empty as MouseEventArgs);
                this.ParentChanged += (t, e) => { 
                    this.Height = this.Parent.Height; 
                };
            }

            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "navMenu";
            this.RowCount = _popups.Count;
            this.Size = new System.Drawing.Size(135, 442);
            this.TabIndex = 1;
        }

        private void OnPopupButton_MouseClick(object sender, MouseEventArgs e)
        {
            int clickedNumPopup= (int)(sender as Button).Tag;
            for (int i = 1; i < this.RowStyles.Count; i++)
            {
                if (i == _popups[clickedNumPopup].numRow)
                {
                    this.RowStyles[i + 1].SizeType = SizeType.Percent;
                    this.RowStyles[i + 1].Height = 100F;
                    this.Controls[i + 1].Visible = true;

                    
                    this.Controls[i+1].Refresh();
                }
                else if (i % 2 != 0)
                {
                    this.RowStyles[i + 1].Height = 0;
                    this.Controls[i + 1].Visible = false;
                }
            }
        }

    }



  
}
