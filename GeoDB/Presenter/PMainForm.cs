using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDbUserInterface.View;
using System.Drawing;
using GeoDBWinForms;
using GeoDB.Service.DataAccess;
using GeoDB.Service.Security;
using GeoDB.Presenter.Interface;
using Ninject.Parameters;

namespace GeoDB.Presenter
{
    public class PMainForm
    {
        IViewMainForm _mainView;

        PCollar2Crud preCollar2Crud;
        PAssays2Crud preAssays2Crud;
        PDrillHoles preDrillHoles;

        List<IPresenter> ChildForms;

        public PMainForm(
            IViewMainForm MainView
            )
        {
            ChildForms = new List<IPresenter>();
            _mainView = MainView;
            StaticInformation.MdiParentForm = MainView;
            MySecurity.GetAuthorisation();
        }
        private List<IPopup> CreateMenu()
        {
            List<IPopup> popups = new List<IPopup>();
            IPopup popup1 = StaticInformation.ninjectKernel.Get<IPopup>();
            IItem item1 = StaticInformation.ninjectKernel.Get<IItem>();
            item1.tittle = "Скважины";
            item1.image = global::GeoDB.Resources.drillhole;
            item1.clickItem += (t, e) =>
            {
                try
                {
                    preCollar2Crud = StaticInformation.ninjectKernel.Get<PCollar2Crud>();
                    preAssays2Crud = StaticInformation.ninjectKernel.Get<PAssays2Crud>();
                    preDrillHoles = StaticInformation.ninjectKernel.Get<PDrillHoles>();
                    preDrillHoles.Show(_mainView);
                    ShowingChildForm(preDrillHoles);
                    EventHandler<EventArgs> removeChildMenu = delegate 
                    {
                        this.HidingChildForm(preDrillHoles);
                    };
                    preDrillHoles._FormClosing -= removeChildMenu;
                    preDrillHoles._FormClosing += removeChildMenu;
                    
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message, ex.InnerException );
                }
            };
            IItem item2 = StaticInformation.ninjectKernel.Get<IItem>();
            item2.tittle = "Контроль";
            item2.image = global::GeoDB.Resources.Control;
            item2.clickItem += (t, e) => {
                MessageBox("Sorry. Form under construction");
            };
            popup1.tittle = "Геология";
            popup1.items.Add(item1);
            popup1.items.Add(item2);
            IPopup popup2 = StaticInformation.ninjectKernel.Get<IPopup>();
            IItem item3 = StaticInformation.ninjectKernel.Get<IItem>();
            item3.tittle = "Пробы склада";
            item3.image = global::GeoDB.Resources.test;
            item3.clickItem += (t, e) =>
            {
                MessageBox("Sorry. Form under construction");
            };
            IItem item4 = StaticInformation.ninjectKernel.Get<IItem>();
            item4.tittle = "Движение руды";
            item4.image = global::GeoDB.Resources.vaicle;
            item4.clickItem += (t, e) => { MessageBox("Sorry. Form under construction"); };
            IItem item5 = StaticInformation.ninjectKernel.Get<IItem>();
            item5.tittle = "Пробы забоев";
            item5.image = global::GeoDB.Resources.test;
            item5.clickItem += (t, e) => { MessageBox("Sorry. Form under construction"); };
            popup2.tittle = "Склад";
            popup2.items.Add(item3);
            popup2.items.Add(item4);
            popup2.items.Add(item5);

            IPopup popup3 = StaticInformation.ninjectKernel.Get<IPopup>();
            IItem item6 = StaticInformation.ninjectKernel.Get<IItem>();
            item6.tittle = "Пользователи";
            item6.image = global::GeoDB.Resources.user;
            item6.clickItem += (t, e) => { MessageBox("Sorry. Form under construction"); };
            IItem item7 = StaticInformation.ninjectKernel.Get<IItem>();
            item7.tittle = "Роли";
            item7.image = global::GeoDB.Resources.role;
            item7.clickItem += (t, e) => { MessageBox("Sorry. Form under construction"); };
            IItem item8 = StaticInformation.ninjectKernel.Get<IItem>();
            item8.tittle = "Ведомости";
            item8.image = global::GeoDB.Resources.blank;
            item8.clickItem += (t, e) => { MessageBox("Sorry. Form under construction"); };
            popup3.tittle = "Настройки";
            popup3.items.Add(item6);
            popup3.items.Add(item7);
            popup3.items.Add(item8);

            popups.Add(popup1);
            popups.Add(popup2);
            popups.Add(popup3);

            return popups;
        }

        private void MessageBox(string message)
        {
            PException pexception = StaticInformation.ninjectKernel.Get<PException>(new ConstructorArgument("MessageText", message, false));
            pexception.Show();
        }


        public void Show()
        {
            _mainView.logo = GeoDB.Resources.logo;
            _mainView.navigatorMenuSettings = this.CreateMenu();
            try
            {
            _mainView.Show();
            }   
            catch (Exception ex)
            {
                string messageInner = ex.InnerException != null ? ex.InnerException.ToString() : "";
                string message = ex.Message + Environment.NewLine + messageInner;
                PException pexception = StaticInformation.ninjectKernel.Get<PException>(new ConstructorArgument("MessageText", message, false));
                pexception.Show();
            }
        }

        void ShowingChildForm(IPresenter presenter)
        {
            if (ChildForms.Find(x=>x.Equals(presenter)) == null)
            {
                ChildForms.Add(presenter);
            }
            this._mainView.removeAllChildMenu();
            ChildForms.ForEach(X => this._mainView.addChildMenu(X.GetToolMenu()));
        }
        void HidingChildForm(IPresenter presenter)
        {
            if (ChildForms.Find(x => x.Equals(presenter)) != null)
            {
                ChildForms.Remove(presenter);
            }
            this._mainView.removeAllChildMenu();
            ChildForms.ForEach(X => this._mainView.addChildMenu(X.GetToolMenu()));
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
