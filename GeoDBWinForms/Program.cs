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
            ninjectKernel.Bind<IViewDrillHoles2>().To<ViewCollar2>();
            ninjectKernel.Bind<IBaseService<COLLAR2>>().To<CollarEntityService>();
            ninjectKernel.Bind<IBaseService<ASSAYS2>>().To<AssaysEntityService>();
            ninjectKernel.Bind<IBaseService<GEOLOGIST>>().To<GeologistEntityService>();
            IViewDrillHoles2 view =  ninjectKernel.Get<IViewDrillHoles2>();
            IBaseService<COLLAR2> modelCollar = ninjectKernel.Get<IBaseService<COLLAR2>>();
            IBaseService<ASSAYS2> modelAssays = ninjectKernel.Get<IBaseService<ASSAYS2>>();
            IBaseService<GEOLOGIST> modelGeologist = ninjectKernel.Get<IBaseService<GEOLOGIST>>();
            PDrillHoles presenter = new PDrillHoles(view, modelCollar,modelAssays,modelGeologist,20);
            presenter.Show();
        }
    }
}
