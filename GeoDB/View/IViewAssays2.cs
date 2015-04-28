using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;

namespace GeoDB.View
{
    public interface IViewAssays2
    {
        
        List<DGVHeader> AssaysHeader { set; }
        Dictionary<int, Assays2VmFull> AssaysList { set; get; }
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
