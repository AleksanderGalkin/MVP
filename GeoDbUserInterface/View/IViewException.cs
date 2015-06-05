using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.View;

namespace GeoDbUserInterface.View
{
    public interface IViewException
    {
        string message { set; }

        event EventHandler<EventArgs> _formClosing;

        void ShowDialog();
        

        

    }
}
