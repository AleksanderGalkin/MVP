using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Security.Principal;
using System.Threading;
using System.IO;
using GeoDbUserInterface.View;
using System.Deployment.Application;


namespace GeoDBWinForms
{
    public partial class ViewMainForm : Form,IViewMainForm
    {

        private NavigatorMenu navMenu;

        ToolStripContainer mainToolStripContainer;
        ToolStrip mainToolStrip;



        public ViewMainForm()
        {
            InitializeComponent();
            this.SetToolMenu();
            this.Controls.Add(this.navMenu);
        }
        public Image logo { set; private get; }
        public List<IPopup> navigatorMenuSettings 
        {
            set
            {
                this.navMenu = new NavigatorMenu(value, logo);
                this.Controls.Add(this.navMenu);
            }
        }

        public void addChildMenu(IPopup childMenuSettings)
        {

            ToolStrip childToolMenu = GetChildToolMenu(childMenuSettings, MergeAction.Append);

            ToolStripManager.Merge(childToolMenu, mainToolStrip);
        }
        public void removeAllChildMenu()
        {
                ToolStripManager.RevertMerge(mainToolStrip);
        }


        private void SetToolMenu()
        {
            mainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            mainToolStrip = new System.Windows.Forms.ToolStrip();
            mainToolStrip.RenderMode = ToolStripRenderMode.Professional;
            mainToolStrip.Renderer = new MyToolStripRenderer();
            mainToolStrip.CanOverflow = false;
            mainToolStrip.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
            mainToolStrip.GripStyle = ToolStripGripStyle.Visible; // перемещение
            mainToolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            mainToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            mainToolStrip.Visible = false;
            mainToolStrip.AllowMerge = true;
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.ItemAdded += (s, e) => { mainToolStrip.Visible = true; };
            mainToolStrip.ItemRemoved += (s, e) => {
                if (mainToolStrip.Items.Count == 0)
                {
                    mainToolStrip.Visible = false; 
                }
            };

            mainToolStripContainer.TopToolStripPanel.Controls.Add(mainToolStrip);
            
            Controls.Add(mainToolStripContainer);

            mainToolStripContainer.Dock = DockStyle.Top;
            mainToolStripContainer.Height = 50;
        }

        private ToolStrip GetChildToolMenu(IPopup childMenuSettings, MergeAction mergeAction)
        {

            ToolStrip toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.CanOverflow = false;
            toolStrip1.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
            toolStrip1.GripStyle = ToolStripGripStyle.Visible; // перемещение
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            toolStrip1.Name = childMenuSettings.tittle;
            toolStrip1.AllowMerge = true;
            for (int i = 0; i < childMenuSettings.items.Count; i++)
            {

                ToolStripButton toolStripButton = new ToolStripButton();
                toolStripButton.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                toolStripButton.Image = childMenuSettings.items[i].image;
                toolStripButton.AutoSize = true;
                toolStripButton.ToolTipText = childMenuSettings.items[i].tittle;
                toolStripButton.Margin = new Padding(1, 1, 1, 3);
                toolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                toolStripButton.MergeAction = mergeAction;
                toolStripButton.Tag = childMenuSettings.items[i];
                toolStripButton.Click += (t, e) => {
                    IItem button = ((t as ToolStripButton).Tag) as IItem;
                    button.sendClickItem();
                };
                toolStripButton.Name = childMenuSettings.tittle + i.ToString();
                toolStrip1.Items.Add(toolStripButton);
                
            }


            return toolStrip1;
        }

        public new void Show()
        {
            Application.Run(this);
        }
    }

    


    

}
