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
            ninjectKernel.Bind<IViewCollar2Crud>().To<ViewCollar2Crud>();
            ninjectKernel.Bind<IBaseService<COLLAR2>>().To<CollarEntityService>();
            ninjectKernel.Bind<IBaseService<ASSAYS2>>().To<AssaysEntityService>();
            ninjectKernel.Bind<IBaseService<GEOLOGIST>>().To<GeologistEntityService>();
            ninjectKernel.Bind<IBaseService<GORIZONT>>().To<GorizontEntityService>();
            ninjectKernel.Bind<IBaseService<RL_EXPLO2>>().To<BlastEntityService>();
            ninjectKernel.Bind<IBaseService<DRILLING_TYPE>>().To<DrillingTypeEntityService>();
            IViewDrillHoles2 view =  ninjectKernel.Get<IViewDrillHoles2>();
            IViewCollar2Crud vCollarCrud = ninjectKernel.Get<IViewCollar2Crud>();
            IBaseService<COLLAR2> modelCollar = ninjectKernel.Get<IBaseService<COLLAR2>>();
            IBaseService<ASSAYS2> modelAssays = ninjectKernel.Get<IBaseService<ASSAYS2>>();
            IBaseService<GEOLOGIST> modelGeologist = ninjectKernel.Get<IBaseService<GEOLOGIST>>();
            IBaseService<GORIZONT> modelGorizont = ninjectKernel.Get<IBaseService<GORIZONT>>();
            IBaseService<RL_EXPLO2> modelBlast = ninjectKernel.Get<IBaseService<RL_EXPLO2>>();
            IBaseService<DRILLING_TYPE> modelDrillType = ninjectKernel.Get<IBaseService<DRILLING_TYPE>>();
            PCollar2Crud preCollar2Crud = new PCollar2Crud(vCollarCrud, modelCollar,modelGorizont,modelBlast,modelDrillType);
            PDrillHoles presenter = new PDrillHoles(view, modelCollar, modelAssays, modelGeologist, 20, preCollar2Crud);
            presenter.Show();
  

        }
    }
}
