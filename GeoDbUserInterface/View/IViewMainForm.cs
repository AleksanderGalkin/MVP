using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace GeoDbUserInterface.View
{
    public interface IViewMainForm:IView
    {
       // private NavigatorMenu navMenu;
        //PCollar2Crud preCollar2Crud { set; }
        //PAssays2Crud preAssays2Crud { set; }
        //PDrillHoles preDrillHoles { set; }
        //bool mustClosed  { set; }


        //IKernel ninjectKernel;

        //IViewDrillHoles2 view;
        //IViewCollar2Crud vCollarCrud;
        //IViewAssays2Crud vAssaysCrud;
        //IViewLogin vLogin;


        //IBaseService<COLLAR2> modelCollar;
        //IBaseService<ASSAYS2> modelAssays;
        //IBaseService<GEOLOGIST> modelGeologist;
        //IBaseService<GORIZONT> modelGorizont;
        //IBaseService<RL_EXPLO2> modelBlast;
        //IBaseService<DRILLING_TYPE> modelDrillType;
        //IBaseService<DOMEN> modelDomen;

        //IBaseService<BLOCK_ZAPASOV> modelZblock;
        //IBaseService<LITOLOGY> modelLito;
        //IBaseService<RANG> modelRang;
        //IBaseService<REESTR_VEDOMOSTEI> modelBlank;
        //IBaseService<JOURNAL> modelJournal;

        List<IPopup> navigatorMenuSettings {  set; }
        Image logo { set; }

        void addChildMenu(IPopup childMenuSettings);
        void removeChildMenu(IPopup childMenuSettings);

        event EventHandler<EventArgs> FormClosed;

        bool Enabled { set; }
        void Show();
        void Close();
        void Hide();

    }
}
