using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeoDB.Presenter;
using Ninject;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;

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
            IViewCollar2 view =  ninjectKernel.Get<IViewCollar2>();
            IBaseService<COLLAR2> model = ninjectKernel.Get<IBaseService<COLLAR2>>();
            PDrillHoles presenter = new PDrillHoles(view, model,10);
            presenter.Show();
        }
    }
}
