using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;
using GeoDB.Presenter;
using GeoDB.View;

namespace GeoDB.Service.DataAccess
{
    public static class SecurityContext
    {
        static string _userName;
        static string _password;
        static string _serverName;
        static string _dbName;
        static string _connectionString;
        static IViewLogin _vLogin;
        static int attempt;
        static PLogin preLogin;
        public static event EventHandler<EventArgs> SuccsessAuthorization;
        public static event EventHandler<EventArgs> FailureAuthorization;

        static  SecurityContext()
        {
            attempt = 0;
        }

         private static  bool Login()
        {
            if (preLogin == null)
            {
                preLogin = new PLogin(_vLogin);
                preLogin.NewDataInputed += new EventHandler<EventArgs>(TestConnectionString);
                preLogin.Canceled += new EventHandler<EventArgs>(CancelAuthorization);
            }
            
            preLogin.Show();
            return true;
        }
         private static void TestConnectionString(object send, EventArgs e)
         {
            _userName = preLogin.GetUserName();
            _password = preLogin.GetPassword();
            _serverName = preLogin.GetServerName();
            _dbName = preLogin.GetDbName();
            var stringTest = String.Format(
             @"data source={0}; Initial Catalog={1}; integrated security={2}; connect timeout=30; multipleactiveresultsets=True; User ID = {3}; Password = {4}; App=EntityFramework"
             , _serverName
             , _dbName
             , "False"
             , _userName
             , _password);

            try
            {
                SqlConnection conntest = new SqlConnection(stringTest);
                conntest.Open();
                conntest.Close();
            }
            catch
            {
                _connectionString = string.Empty;
                StartAuthorization();
                return;
            }
            var entityConnectionString = new EntityConnectionStringBuilder()
            {
                Metadata = @"res://*/Model.Model1.csdl|res://*/Model.Model1.ssdl|res://*/Model.Model1.msl",
                Provider = @"System.Data.SqlClient",
                ProviderConnectionString = stringTest
            };

            _connectionString = entityConnectionString.ConnectionString;
            StartAuthorization();
            
         }
        public static void StartAuthorization()
        {
            if (attempt < 3 &&   String.IsNullOrEmpty(_connectionString))
            {
                Login();
                attempt++;
            }
            else if (_connectionString != string.Empty)
            {
                var ev = SuccsessAuthorization;
                if (ev != null)
                {
                    ev(null, EventArgs.Empty);
                }
                attempt = 0;
               // preLogin.NewDataInputed -= new EventHandler<EventArgs>(TestConnectionString);
            }
            else if (_connectionString == string.Empty)
            {
                var ev = FailureAuthorization;
                if (ev != null)
                {
                    ev(null, EventArgs.Empty);
                }
                attempt = 0;
               // preLogin.NewDataInputed -= new EventHandler<EventArgs>(TestConnectionString);
            }
            
        }
        public static void SetLoginForm (IViewLogin vLogin)
        {
            _vLogin = vLogin;
        }

        public static string  GetConnectionString()
        {
            return _connectionString;
        }

        private static void CancelAuthorization(object sender, EventArgs e)
        {
            var ev = FailureAuthorization;
            if (ev != null)
            {
                ev(null, EventArgs.Empty);
            }
            attempt = 0;
        }
    }
}
