using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;

namespace GeoDB.View
{
    public interface IViewCollar2
    {
        List<DGVHeader> CollarHeader { set;  }
        Dictionary<int,Collar2VmFull> CollarList { set; get; }
        int minShowedRow { set; get; }
        int maxShowedRow { set; get; }
        int rowCount { set; get; }

        void Show();
        void Close();


        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickCollarList;
        event EventHandler<EventArgs> showPrevScreen;
        event EventHandler<EventArgs> showNextScreen;
        event EventHandler<NumRowEventArgs> showAnyScreen;
        event EventHandler<EventArgs> clickFilters;
        event EventHandler<EventArgs> clickHeader;
        event EventHandler<EventArgs> clickCloseForm;


    }
}
