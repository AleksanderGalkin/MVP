using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.View
{
    public interface IViewDrillHoles2PrintSet
    {
        List<string> benchList { set; }
        string bench { get; set; }
        List<string> blastList { set; }
        string blast { get; set; }



        event EventHandler<EventArgs> _selectBench;
        event EventHandler<EventArgs> _clickOk;
        event EventHandler<EventArgs> _clickCancel;
        event EventHandler<EventArgs> _formClosing;

        IView _MdiParent { set; }
        IView OwnerForm { get; set; }
        void Show();
        void Close();
    }
}
