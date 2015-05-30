using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Windows.Forms;
using GeoDbUserInterface.View;
using System.Drawing;
using GeoDBWinForms;
using GeoDB.Service.DataAccess;
using GeoDB.Service.Security;

namespace GeoDB.Presenter
{
    public class PMainForm
    {
        IViewMainForm _mainView;

        PCollar2Crud preCollar2Crud;
        PAssays2Crud preAssays2Crud;
        PDrillHoles preDrillHoles;

        IKernel ninjectKernel;

        IViewDrillHoles2 view;
        IViewCollar2Crud vCollarCrud;
        IViewAssays2Crud vAssaysCrud;
        IViewLogin vLogin;


        IBaseService<COLLAR2> modelCollar;
        IBaseService<ASSAYS2> modelAssays;
        IBaseService<GEOLOGIST> modelGeologist;
        IBaseService<GORIZONT> modelGorizont;
        IBaseService<RL_EXPLO2> modelBlast;
        IBaseService<DRILLING_TYPE> modelDrillType;
        IBaseService<DOMEN> modelDomen;

        IBaseService<BLOCK_ZAPASOV> modelZblock;
        IBaseService<LITOLOGY> modelLito;
        IBaseService<RANG> modelRang;
        IBaseService<REESTR_VEDOMOSTEI> modelBlank;
        IBaseService<JOURNAL> modelJournal;



        public PMainForm(
            IViewMainForm MainView
            )
        {
            _mainView = MainView;
            this.Factory();
        }

        private List<IPopup> CreateMenu()
        {
            List<IPopup> popups = new List<IPopup>();
            IPopup popup1 = new Popup();
            IItem item1 = new Item();
            item1.tittle = "Скважины";
            item1.image = global::GeoDB.Resources.drillhole;
            item1.clickItem += (t, e) =>
            {
                try
                {
                    preCollar2Crud = preCollar2Crud !=null ? preCollar2Crud : new PCollar2Crud(vCollarCrud, modelCollar, modelGorizont, modelBlast, modelDrillType, modelDomen);
                    preAssays2Crud = preAssays2Crud !=null ? preAssays2Crud : new PAssays2Crud(vAssaysCrud, modelAssays, modelZblock, modelLito, modelRang, modelBlank, modelJournal, modelGeologist);
                    preDrillHoles = preDrillHoles != null ? preDrillHoles : new PDrillHoles(view, modelCollar, modelAssays, modelGeologist, 20, preCollar2Crud, preAssays2Crud);
                    preDrillHoles.Show(_mainView);
                    IPopup p = new Popup();
                    p.tittle = "preDrillHoles";
                    IItem i1 = new Item();
                    i1.image = GeoDB.Resources.report;
                    i1.tittle = "Печать";
                    i1.clickItem += (s, e2) => { MessageBox.Show("ok"); };
                    p.items.Add(i1);

                    this._mainView.addChildMenu(p);
                    preDrillHoles._FormClosing += (s, e2) => {
                        this._mainView.removeChildMenu(p); 
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : ""), ex.Message);
                }
            };
            Item item2 = new Item();
            item2.tittle = "Контроль";
            item2.image = global::GeoDB.Resources.Control;
            item2.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            popup1.tittle = "Геология";
            popup1.items.Add(item1);
            popup1.items.Add(item2);
            Popup popup2 = new Popup();
            Item item3 = new Item();
            item3.tittle = "Пробы склада";
            item3.image = global::GeoDB.Resources.test;
            item3.clickItem += (t, e) =>
            {
                MessageBox.Show("Sorry. Form under construction");
            };
            Item item4 = new Item();
            item4.tittle = "Движение руды";
            item4.image = global::GeoDB.Resources.vaicle;
            item4.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item5 = new Item();
            item5.tittle = "Пробы забоев";
            item5.image = global::GeoDB.Resources.test;
            item5.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            popup2.tittle = "Склад";
            popup2.items.Add(item3);
            popup2.items.Add(item4);
            popup2.items.Add(item5);

            Popup popup3 = new Popup();
            Item item6 = new Item();
            item6.tittle = "Пользователи";
            item6.image = global::GeoDB.Resources.user;
            item6.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item7 = new Item();
            item7.tittle = "Роли";
            item7.image = global::GeoDB.Resources.role;
            item7.clickItem += (t, e) => { MessageBox.Show("Sorry. Form under construction"); };
            Item item8 = new Item();
            item8.tittle = "Ведомости";
            item8.image = global::GeoDB.Resources.blank;
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

                ninjectKernel = new StandardKernel();
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


                view = ninjectKernel.Get<IViewDrillHoles2>();
                vCollarCrud = ninjectKernel.Get<IViewCollar2Crud>();
                vAssaysCrud = ninjectKernel.Get<IViewAssays2Crud>();
                vLogin = ninjectKernel.Get<ViewLogin>();

                MySecurity.SetLoginForm(vLogin);


                modelCollar = ninjectKernel.Get<IBaseService<COLLAR2>>();
                modelAssays = ninjectKernel.Get<IBaseService<ASSAYS2>>();
                modelGeologist = ninjectKernel.Get<IBaseService<GEOLOGIST>>();
                modelGorizont = ninjectKernel.Get<IBaseService<GORIZONT>>();
                modelBlast = ninjectKernel.Get<IBaseService<RL_EXPLO2>>();
                modelDrillType = ninjectKernel.Get<IBaseService<DRILLING_TYPE>>();
                modelDomen = ninjectKernel.Get<IBaseService<DOMEN>>();

                modelZblock = ninjectKernel.Get<IBaseService<BLOCK_ZAPASOV>>();
                modelLito = ninjectKernel.Get<IBaseService<LITOLOGY>>();
                modelRang = ninjectKernel.Get<IBaseService<RANG>>();
                modelBlank = ninjectKernel.Get<IBaseService<REESTR_VEDOMOSTEI>>();
                modelJournal = ninjectKernel.Get<IBaseService<JOURNAL>>();



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : ""), ex.Message);
                //this.mustClosed = true;
                //this.Close();
            }


        }

        public void Show()
        {
            //_mainView.Show();
            _mainView.logo = GeoDB.Resources.logo;
            _mainView.navigatorMenuSettings = this.CreateMenu();
            Application.Run(_mainView as Form);
        }

    }

    public class Item : IItem
    {
        public string tittle { get; set; }
        public Image image { get; set; }
        public event EventHandler<EventArgs> clickItem;
        public void sendClickItem()
        {
            var ev = clickItem;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }
    }

    public class Popup : IPopup
    {
        public string tittle { get; set; }
        public List<IItem> items { get; set; }
        public int numRow { get; set; }
        public Popup()
        {
            items = new List<IItem>();
        }

        public int heigth
        {
            get
            {
                return items.Count * 60 + items.Count * 10;
            }
        }

    }
}
