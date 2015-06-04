using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDbUserInterface.View;
using GeoDB.Presenter.Interface;

namespace GeoDB.Presenter
{
    public class PLogin : ILoginPresenter
    {
        private IViewLogin _view;
        private bool isShowed;

        private string _userName;
        private string _password;
        private string _serverName;
        private string _dbName;
        private string _dbFileName;
        private string _connectionString;
        private bool _locationServerDb;
        private bool _isWindowsAuthentication;

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
            _dbFileName = _view.dbFileName;
            _locationServerDb = _view.locationServerDb;
            _isWindowsAuthentication = _view.isWindowsAuthentication;

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
                if (Properties.Settings.Default.userNames != null)
                {
                    string[] tArray_userNames = new string[Properties.Settings.Default.userNames.Count];
                    Properties.Settings.Default.userNames.CopyTo(tArray_userNames, 0);
                    _view.userNames = new List<string>(tArray_userNames as IEnumerable<string>);
                    _view.userName = Properties.Settings.Default.userName ?? "";
                }
                if (Properties.Settings.Default.serverNames != null)
                {
                    string[] tArray_serverNames = new string[Properties.Settings.Default.serverNames.Count];
                    Properties.Settings.Default.serverNames.CopyTo(tArray_serverNames, 0);
                    _view.serverNames = new List<string>(tArray_serverNames as IEnumerable<string>);
                    _view.serverName = Properties.Settings.Default.serverName ?? "";
                }
                if (Properties.Settings.Default.dbNames != null)
                {
                    string[] tArray_dbNames = new string[Properties.Settings.Default.dbNames.Count];
                    Properties.Settings.Default.dbNames.CopyTo(tArray_dbNames, 0);
                    _view.dbNames = new List<string>(tArray_dbNames as IEnumerable<string>);
                    _view.dbName = Properties.Settings.Default.dbName ?? "";
                }
                if (Properties.Settings.Default.dbFileNames != null)
                {
                    string[] tArray_dbFileNames = new string[Properties.Settings.Default.dbFileNames.Count];
                    Properties.Settings.Default.dbFileNames.CopyTo(tArray_dbFileNames, 0);
                    _view.dbFileNames = new List<string>(tArray_dbFileNames as IEnumerable<string>);
                    _view.dbFileName = Properties.Settings.Default.dbFileName ?? "";
                }
                _view.locationServerDb = Properties.Settings.Default.locationServerDb;
                _view.isWindowsAuthentication = Properties.Settings.Default.isWindowsAuthentication;

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

        public void SaveParams()
        {
            string currentUserName = _userName;
            Properties.Settings.Default.userName = currentUserName;
            if (Properties.Settings.Default.userNames == null)
            {
                Properties.Settings.Default.userNames = new System.Collections.Specialized.StringCollection();
            }
            if (!Properties.Settings.Default.userNames.Contains(currentUserName))
            {
                Properties.Settings.Default.userNames.Add(currentUserName);
            }
            string currentServerName = _serverName;
            Properties.Settings.Default.serverName = currentServerName;
            if (Properties.Settings.Default.serverNames == null)
            {
                Properties.Settings.Default.serverNames = new System.Collections.Specialized.StringCollection();
            }
            if ( !Properties.Settings.Default.serverNames.Contains(currentServerName) )
            {
                Properties.Settings.Default.serverNames.Add(currentServerName);
            }
            string currentDbName = _dbName;
            Properties.Settings.Default.dbName = currentDbName;
            if (Properties.Settings.Default.dbNames == null)
            {
                Properties.Settings.Default.dbNames = new System.Collections.Specialized.StringCollection();
            }
            if (!Properties.Settings.Default.dbNames.Contains(currentDbName))
            {
                Properties.Settings.Default.dbNames.Add(currentDbName);
            }
            string currentdbFileName = _dbFileName;
            Properties.Settings.Default.dbFileName = currentdbFileName;
            if (Properties.Settings.Default.dbFileNames == null)
            {
                Properties.Settings.Default.dbFileNames = new System.Collections.Specialized.StringCollection();
            }
            if (!Properties.Settings.Default.dbFileNames.Contains(currentdbFileName))
            {
                Properties.Settings.Default.dbFileNames.Add(currentdbFileName);
            }
            bool currentLocationServerDb = _locationServerDb;
            if (Properties.Settings.Default.locationServerDb != currentLocationServerDb)
            {
                Properties.Settings.Default.locationServerDb = currentLocationServerDb;
            }
            bool current_isWindowsAuthentication = _isWindowsAuthentication;
            if (Properties.Settings.Default.isWindowsAuthentication != current_isWindowsAuthentication)
            {
                Properties.Settings.Default.isWindowsAuthentication = current_isWindowsAuthentication;
            }

            Properties.Settings.Default.Save();
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
        public string GetDbFileName()
        {
            return _dbFileName;
        }
        public bool GetLocationServerDb()
        {
            return _locationServerDb;
        }
        public bool isWindowsAuthentication()
        {
            return _isWindowsAuthentication;
        }

        public IPopup GetToolMenu()
        { throw new NotImplementedException(); }

    }
}
