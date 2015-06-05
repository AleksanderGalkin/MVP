using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.View
{
    public interface IViewLogin
    {
        List<string> userNames { set;}
        string userName { get; set; }
        string password { get; set; }
        List<string> serverNames { set; }
        string serverName { get; set; }
        List<string> dbNames { set; }
        string dbName { get; set; }
        List<string> dbFileNames { set; }
        string dbFileName { get; set; }
        bool isWindowsAuthentication { get; set; }
        bool locationServerDb { get; set; }

        event EventHandler<EventArgs> clickOk;
        event EventHandler<EventArgs> clickCancel;
        bool propVisible {get;set;}
        void Show();
        void Close();
    }
}
