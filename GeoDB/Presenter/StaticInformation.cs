using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.View;
using Ninject;
using GeoDBWinForms;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Service.DataAccess;

namespace GeoDB.Presenter
{
    static class StaticInformation
    {
        public static IView MdiParentForm { get; set; }
        public static IKernel ninjectKernel;

        static  StaticInformation ()
        {
            ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IViewDrillHoles2>().To<ViewDrillHoles>();
            ninjectKernel.Bind<IViewCollar2Crud>().To<ViewCollar2Crud>();
            ninjectKernel.Bind<IViewAssays2Crud>().To<ViewAssays2Crud>();
            ninjectKernel.Bind<IViewLogin>().To<ViewLogin>();
            ninjectKernel.Bind<IViewException>().To<ViewException>();

            ninjectKernel.Bind<PException>().To<PException>().WithConstructorArgument("MessageText", "test");
            ninjectKernel.Bind<PCollar2Crud>().To<PCollar2Crud>();
            

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
        }
           
    }
}
