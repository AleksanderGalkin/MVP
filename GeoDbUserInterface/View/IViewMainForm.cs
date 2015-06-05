using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace GeoDbUserInterface.View
{
    public interface IViewMainForm:IView
    {

        List<IPopup> navigatorMenuSettings {  set; }
        Image logo { set; }

        void addChildMenu(IPopup childMenuSettings);
        void removeAllChildMenu();


        bool Enabled { set; }
        void Show();
        void Close();
        void Hide();

    }
}
