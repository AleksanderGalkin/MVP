using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Presenter;
using GeoDB.Service.DataAccess;



namespace GeoDBWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IViewCollar2>().To<ViewCollar2>();
            ninjectKernel.Bind<IBaseService<COLLAR2>>().To<CollarEntityService>();
            IViewCollar2 view =  ninjectKernel.Get<IViewCollar2>();
            IBaseService<COLLAR2> model = ninjectKernel.Get<IBaseService<COLLAR2>>();
            PDrillHoles presenter = new PDrillHoles(view, model,20);
            presenter.Show();
        }
    }
}
