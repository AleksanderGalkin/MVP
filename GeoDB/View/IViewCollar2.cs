using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;

namespace GeoDB.View
{
    public interface IViewCollar2
    {
        List<Collar2VmFull> CollarList { set; }

        void Show();
        void Close();

        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickCollarList;
        event EventHandler<EventArgs> showPrevScreen;
        event EventHandler<EventArgs> showNextScreen;
        event EventHandler<EventArgs> clickFilters;
        event EventHandler<EventArgs> clickHeader;
        event EventHandler<EventArgs> clickCloseForm;
    }
}
