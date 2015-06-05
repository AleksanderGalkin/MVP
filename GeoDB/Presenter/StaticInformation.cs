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
            ninjectKernel.Bind<IViewDrillHoles2PrintSet>().To<ViewDrillHoles2PrintSet>();

            ninjectKernel.Bind<PLogin>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<PException>().ToSelf();
            ninjectKernel.Bind<PCollar2Crud>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<PAssays2Crud>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<PDrillHoles>().ToSelf().InSingletonScope().WithConstructorArgument("rowsToBuffer",20);
            ninjectKernel.Bind<PDrillHoles2PrintSet>().ToSelf();


            ninjectKernel.Bind<IPopup>().To<Popup>();
            ninjectKernel.Bind<IItem>().To<Item>();

            ninjectKernel.Bind<IBaseService<COLLAR2>>().To<CollarEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<ASSAYS2>>().To<AssaysEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<GEOLOGIST>>().To<GeologistEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<GORIZONT>>().To<GorizontEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<RL_EXPLO2>>().To<BlastEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<DRILLING_TYPE>>().To<DrillingTypeEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<DOMEN>>().To<DomenEntityService>().InSingletonScope();

            ninjectKernel.Bind<IBaseService<BLOCK_ZAPASOV>>().To<ZblockEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<LITOLOGY>>().To<LitoEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<RANG>>().To<RangEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<REESTR_VEDOMOSTEI>>().To<BlankEntityService>().InSingletonScope();
            ninjectKernel.Bind<IBaseService<JOURNAL>>().To<JournalEntityService>().InSingletonScope();
        }
           
    }
}
