using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;

namespace GeoDB.Presenter
{
    public class PLogin
    {
        private IViewLogin _view;
        private ITestDbConnection _testMsSqlConnection;
        private bool isShowed;

        private string _userName;
        private string _password;
        private string _serverName;
        private string _dbName;
        private string _connectionString;

        public event EventHandler<EventArgs> NewDataInputed;
        public event EventHandler<EventArgs> Canceled;

        public PLogin (
                        IViewLogin View
                        )
        {
            _view = View;
            _connectionString = "";
            _view.clickOk +=new EventHandler<EventArgs>(On_view_clickOk);
            _view.clickCancel += new EventHandler<EventArgs>(On_view_clickCancel);
            isShowed = false;
        }

        private void On_view_clickOk(object sender, EventArgs e)
        {
            _view.propVisible = false;
            _userName = _view.userName;
            _password = _view.password;
            _serverName = _view.serverName;
            _dbName = _view.dbName;
            
            var ev = NewDataInputed;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
            
        }
        private void On_view_clickCancel(object sender, EventArgs e)
        {
            _view.propVisible = false;
            var ev = Canceled;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
            _view.Close();
        }
        public string GetConnectionString()
        {
            if (_connectionString != string.Empty)
            {
                return _connectionString;
            }
            else
            {
                throw new UnauthorizedAccessException("Connection not exist");
            }
        }

        public void Show()
        {
            if (!isShowed)
            {
                isShowed = true;
                _view.Show();
            }
            else
            {
                _view.propVisible = true;
            }
        }

        public void Close()
        {
            _view.Close();
        }


        public string GetUserName()
        {
            return _userName;
        }
        public string GetPassword()
        {
            return _password;
        }
        public string GetServerName()
        {
            return _serverName;
        }
        public string GetDbName()
        {
            return _dbName;
        }
    }
}
