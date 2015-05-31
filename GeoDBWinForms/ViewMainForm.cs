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
using FastReport;
using FastReport.Utils;
using System.IO;
using GeoDbUserInterface.View;


namespace GeoDBWinForms
{
    public partial class ViewMainForm : Form,IViewMainForm
    {

        private NavigatorMenu navMenu;
        //private PCollar2Crud preCollar2Crud ;
        //private PAssays2Crud preAssays2Crud;
        //private PDrillHoles preDrillHoles;
        public bool mustClosed;


       // IKernel ninjectKernel;

        IViewDrillHoles2 view ;
        IViewCollar2Crud vCollarCrud ;
        IViewAssays2Crud vAssaysCrud ;
        IViewLogin vLogin;


        //IBaseService<COLLAR2> modelCollar ;
        //IBaseService<ASSAYS2> modelAssays ;
        //IBaseService<GEOLOGIST> modelGeologist ;
        //IBaseService<GORIZONT> modelGorizont ;
        //IBaseService<RL_EXPLO2> modelBlast ;
        //IBaseService<DRILLING_TYPE> modelDrillType ;
        //IBaseService<DOMEN> modelDomen ;

        //IBaseService<BLOCK_ZAPASOV> modelZblock ;
        //IBaseService<LITOLOGY> modelLito ;
        //IBaseService<RANG> modelRang ;
        //IBaseService<REESTR_VEDOMOSTEI> modelBlank ;
        //IBaseService<JOURNAL> modelJournal;

       

        ToolStripContainer mainToolStripContainer;
        ToolStrip mainToolStrip;

        public event EventHandler<EventArgs> FormClosed;

        public ViewMainForm()
        {
            InitializeComponent();

            this.SetToolMenu();

            this.mustClosed = false;
            
            this.Controls.Add(this.navMenu);
         //   this.Factory();
        
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


        //private void Factory()
        //{
        //    try
        //    {

        //         ninjectKernel = new StandardKernel();
        //        ninjectKernel.Bind<IViewDrillHoles2>().To<ViewDrillHoles>();
        //        ninjectKernel.Bind<IViewCollar2Crud>().To<ViewCollar2Crud>();
        //        ninjectKernel.Bind<IViewAssays2Crud>().To<ViewAssays2Crud>();
        //        ninjectKernel.Bind<IViewLogin>().To<ViewLogin>();

        //        ninjectKernel.Bind<IBaseService<COLLAR2>>().To<CollarEntityService>();
        //        ninjectKernel.Bind<IBaseService<ASSAYS2>>().To<AssaysEntityService>();
        //        ninjectKernel.Bind<IBaseService<GEOLOGIST>>().To<GeologistEntityService>();
        //        ninjectKernel.Bind<IBaseService<GORIZONT>>().To<GorizontEntityService>();
        //        ninjectKernel.Bind<IBaseService<RL_EXPLO2>>().To<BlastEntityService>();
        //        ninjectKernel.Bind<IBaseService<DRILLING_TYPE>>().To<DrillingTypeEntityService>();
        //        ninjectKernel.Bind<IBaseService<DOMEN>>().To<DomenEntityService>();

        //        ninjectKernel.Bind<IBaseService<BLOCK_ZAPASOV>>().To<ZblockEntityService>();
        //        ninjectKernel.Bind<IBaseService<LITOLOGY>>().To<LitoEntityService>();
        //        ninjectKernel.Bind<IBaseService<RANG>>().To<RangEntityService>();
        //        ninjectKernel.Bind<IBaseService<REESTR_VEDOMOSTEI>>().To<BlankEntityService>();
        //        ninjectKernel.Bind<IBaseService<JOURNAL>>().To<JournalEntityService>();


        //         view = ninjectKernel.Get<IViewDrillHoles2>();
        //         vCollarCrud = ninjectKernel.Get<IViewCollar2Crud>();
        //         vAssaysCrud = ninjectKernel.Get<IViewAssays2Crud>();
        //         vLogin = ninjectKernel.Get<ViewLogin>();

        //        MySecurity.SetLoginForm(vLogin);


        //        modelCollar = ninjectKernel.Get<IBaseService<COLLAR2>>();
        //         modelAssays = ninjectKernel.Get<IBaseService<ASSAYS2>>();
        //         modelGeologist = ninjectKernel.Get<IBaseService<GEOLOGIST>>();
        //         modelGorizont = ninjectKernel.Get<IBaseService<GORIZONT>>();
        //         modelBlast = ninjectKernel.Get<IBaseService<RL_EXPLO2>>();
        //         modelDrillType = ninjectKernel.Get<IBaseService<DRILLING_TYPE>>();
        //         modelDomen = ninjectKernel.Get<IBaseService<DOMEN>>();

        //         modelZblock = ninjectKernel.Get<IBaseService<BLOCK_ZAPASOV>>();
        //         modelLito = ninjectKernel.Get<IBaseService<LITOLOGY>>();
        //         modelRang = ninjectKernel.Get<IBaseService<RANG>>();
        //         modelBlank = ninjectKernel.Get<IBaseService<REESTR_VEDOMOSTEI>>();
        //         modelJournal = ninjectKernel.Get<IBaseService<JOURNAL>>();



        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show( ex.Message+" "+(ex.InnerException != null ? ex.InnerException.Message : "") ,ex.Message );
        //        this.mustClosed = true;
        //        this.Close();
        //    }
     

        //}

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
            base.Show();
        }
    }

    


    

}
