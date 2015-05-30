using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GeoDbUserInterface.View
{
    public interface IPopup
    {
        string tittle { get; set; }
        int heigth { get; }
        int numRow { get; set; }
        List<IItem> items { get; set; }

    }

    public interface  IItem
    {
        string tittle { get; set; }
        Image image { get; set; }
        event EventHandler<EventArgs> clickItem;
        void sendClickItem();
        
    }
}
