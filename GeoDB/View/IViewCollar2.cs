using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;

namespace GeoDBWinForms
{
    public interface IViewCollar2
    {
        List<COLLAR2> CollarList {set;}

        void Show();


        event EventHandler<EventArgs> clickCollarList;
        event EventHandler<EventArgs> showData;
    }
}
