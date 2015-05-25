using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ninject;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Service.DataAccess;
using GeoDB.Presenter;

namespace GeoDBWinForms
{
    public partial class ViewMainForm : Form
    {

        private NavigatorMenu navMenu;
        private PCollar2Crud preCollar2Crud ;
        private PAssays2Crud preAssays2Crud;
        private PDrillHoles preDrillHoles;
        public bool mustClosed;
        public ViewMainForm()
        {
            InitializeComponent();
            this.mustClosed = false;
            this.navMenu = new NavigatorMenu(CreateMenu());
            this.Controls.Add(this.navMenu);
            this.Factory();



        }

        private List<IPopup> CreateMenu()
        {
            List<IPopup> popups = new List<IPopup>();
            Popup popup1 = new Popup();
            Item item1 = new Item();
            item1.tittle = "Скважины";
            item1.image = global::GeoDBWinForms.Properties.Resources.drillhole;
            item1.clickItem += (t, e) =>
            {
                preDrillHoles.Show(this);
            };
            Item item2 = new Item();
            item2.tittle = "Контроль";
            item2.image = global::GeoDBWinForms.Properties.Resources.Control;
            item2.clickItem += (t,e) => {MessageBox.Show("Sorry. Form under construction");};
            popup1.tittle = "Геология";
            popup1.items.Add(item1);
            popup1.items.Add(item2);
            Popup popup2 = new Popup();
            Item item3 = new Item();
            item3.tittle = "Пробы склада";
            item3.image = global::GeoDBWinForms.Properties.Resources.test;
            item3.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item4 = new Item();
            item4.tittle = "Движение руды";
            item4.image = global::GeoDBWinForms.Properties.Resources.vaicle;
            item4.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item5 = new Item();
            item5.tittle = "Пробы забоев";
            item5.image = global::GeoDBWinForms.Properties.Resources.test;
            item5.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            popup2.tittle = "Склад";
            popup2.items.Add(item3);
            popup2.items.Add(item4);
            popup2.items.Add(item5);

            Popup popup3 = new Popup();
            Item item6 = new Item();
            item6.tittle = "Пользователи";
            item6.image = global::GeoDBWinForms.Properties.Resources.user;
            item6.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item7 = new Item();
            item7.tittle = "Роли";
            item7.image = global::GeoDBWinForms.Properties.Resources.role;
            item7.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item8 = new Item();
            item8.tittle = "Ведомости";
            item8.image = global::GeoDBWinForms.Properties.Resources.blank;
            item8.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            popup3.tittle = "Настройки";
            popup3.items.Add(item6);
            popup3.items.Add(item7);
            popup3.items.Add(item8);

            popups.Add(popup1);
            popups.Add(popup2);
            popups.Add(popup3);

            return popups;
        }


        private void Factory()
        {
            try
            {

                IKernel ninjectKernel = new StandardKernel();
                ninjectKernel.Bind<IViewDrillHoles2>().To<ViewDrillHoles>();
                ninjectKernel.Bind<IViewCollar2Crud>().To<ViewCollar2Crud>();
                ninjectKernel.Bind<IViewAssays2Crud>().To<ViewAssays2Crud>();
                ninjectKernel.Bind<IViewLogin>().To<ViewLogin>();

                ninjectKernel.Bind<IBaseService<COLLAR2>>().To<CollarEntityService>();
                ninjectKernel.Bind<IBaseService<ASSAYS2>>().To<AssaysEntityService>();
                ninjectKernel.Bind<IBaseService<GEOLOGIST>>().To<GeologistEntityService>();
                ninjectKernel.Bind<IBaseService<GORIZONT>>().To<GorizontEntityService>();
                ninjectKernel.Bind<IBaseService<RL_EXPLO2>>().To<BlastEntityService>();
                ninjectKernel.Bind<IBaseService<DRILLING_TYPE>>().To<DrillingTypeEntityService>();
                ninjectKernel.Bind<IBaseService<DOMEN>>().To<DomenEntityService>();

                ninjectKernel.Bind<IBaseService<BLOCK_ZAPASOV>>().To<ZblockEntityService>();
                ninjectKernel.Bind<IBaseService<LITOLOGY>>().To<LitoEntityService>();
                ninjectKernel.Bind<IBaseService<RANG>>().To<RangEntityService>();
                ninjectKernel.Bind<IBaseService<REESTR_VEDOMOSTEI>>().To<BlankEntityService>();
                ninjectKernel.Bind<IBaseService<JOURNAL>>().To<JournalEntityService>();


                IViewDrillHoles2 view = ninjectKernel.Get<IViewDrillHoles2>();
                IViewCollar2Crud vCollarCrud = ninjectKernel.Get<IViewCollar2Crud>();
                IViewAssays2Crud vAssaysCrud = ninjectKernel.Get<IViewAssays2Crud>();
                IViewLogin vLogin = ninjectKernel.Get<ViewLogin>();

                SecurityContext.SetLoginForm(vLogin);


                IBaseService<COLLAR2> modelCollar = ninjectKernel.Get<IBaseService<COLLAR2>>();
                IBaseService<ASSAYS2> modelAssays = ninjectKernel.Get<IBaseService<ASSAYS2>>();
                IBaseService<GEOLOGIST> modelGeologist = ninjectKernel.Get<IBaseService<GEOLOGIST>>();
                IBaseService<GORIZONT> modelGorizont = ninjectKernel.Get<IBaseService<GORIZONT>>();
                IBaseService<RL_EXPLO2> modelBlast = ninjectKernel.Get<IBaseService<RL_EXPLO2>>();
                IBaseService<DRILLING_TYPE> modelDrillType = ninjectKernel.Get<IBaseService<DRILLING_TYPE>>();
                IBaseService<DOMEN> modelDomen = ninjectKernel.Get<IBaseService<DOMEN>>();

                IBaseService<BLOCK_ZAPASOV> modelZblock = ninjectKernel.Get<IBaseService<BLOCK_ZAPASOV>>();
                IBaseService<LITOLOGY> modelLito = ninjectKernel.Get<IBaseService<LITOLOGY>>();
                IBaseService<RANG> modelRang = ninjectKernel.Get<IBaseService<RANG>>();
                IBaseService<REESTR_VEDOMOSTEI> modelBlank = ninjectKernel.Get<IBaseService<REESTR_VEDOMOSTEI>>();
                IBaseService<JOURNAL> modelJournal = ninjectKernel.Get<IBaseService<JOURNAL>>();

                preCollar2Crud = new PCollar2Crud(vCollarCrud, modelCollar, modelGorizont, modelBlast, modelDrillType, modelDomen);
                preAssays2Crud = new PAssays2Crud(vAssaysCrud, modelAssays, modelZblock, modelLito, modelRang, modelBlank, modelJournal, modelGeologist);
                preDrillHoles = new PDrillHoles(view, modelCollar, modelAssays, modelGeologist, 20, preCollar2Crud, preAssays2Crud);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException != null ? ex.InnerException.Message : "");
                this.mustClosed = true;
                this.Close();
            }
     

        }

    }
}
