using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;

namespace GeoDB.View
{
    public interface IViewDrillHoles2
    {
        List<DGVHeader> CollarHeader { set;  }
        Dictionary<int, Collar2VmFull> CollarList { set; get; }
        int minCollarRow { set; get; }
        int maxCollarRow { set; get; }
        int rowCollarCount { set; get; }
        event EventHandler<EventArgs> clickCollarData;
        event EventHandler<EventArgs> showPrevCollarScreen;
        event EventHandler<EventArgs> showNextCollarScreen;
        event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        event EventHandler<EventArgs> clickCollarFilters;
        event EventHandler<EventArgs> clickCollarHeader;
        event EventHandler<NumRowEventArgs> setCurrentRow;

        List<DGVHeader> AssaysHeader { set; }
        Dictionary<int, Assays2VmFull> AssaysList { set; get; }
        int minAssaysRow { set; get; }
        int maxAssaysRow { set; get; }
        int rowAssaysCount { set; get; }
        event EventHandler<EventArgs> clickAssaysData;
        event EventHandler<EventArgs> showPrevAssaysScreen;
        event EventHandler<EventArgs> showNextAssaysScreen;
        event EventHandler<NumRowEventArgs> showAnyAssaysScreen;
        event EventHandler<EventArgs> clickAssaysFilters;
        event EventHandler<EventArgs> clickAssaysHeader;

        void Show();
        void Close();
        void RefreshCollar();
        void RefreshAssays();
        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickCloseForm;


    }
}
