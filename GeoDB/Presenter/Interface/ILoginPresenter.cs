using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDB.Presenter.Interface
{
    public interface ILoginPresenter : IPresenter
    {
        event EventHandler<EventArgs> NewDataInputed;
        event EventHandler<EventArgs> Canceled;

        string GetConnectionString();
        void Show();
        void Close();
        void SaveParams();
        string GetUserName();
        string GetPassword();
        string GetServerName();
        string GetDbName();
        string GetDbFileName();
        bool GetLocationServerDb();
        bool isWindowsAuthentication();
    }
}
