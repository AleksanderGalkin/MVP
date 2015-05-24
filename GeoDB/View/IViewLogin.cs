using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDB.View
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

        event EventHandler<EventArgs> clickOk;
        event EventHandler<EventArgs> clickCancel;
        bool propVisible {get;set;}
        void Show();
        void Close();
    }
}
