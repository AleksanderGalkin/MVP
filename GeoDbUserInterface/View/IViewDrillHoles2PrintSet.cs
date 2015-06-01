using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.View;

namespace ClassLibrary1.View
{
    public interface IViewDrillHoles2PrintSet
    {
        List<string> benchList { set; }
        string bench { get;  }
        List<string> blastList { set; }
        string blast { get;  }



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
