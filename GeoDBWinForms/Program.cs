using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeoDB.Presenter;
using Ninject;

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
            PDrillHoles presenter = new PDrillHoles(view);
            presenter.Show();
        }
    }
}
