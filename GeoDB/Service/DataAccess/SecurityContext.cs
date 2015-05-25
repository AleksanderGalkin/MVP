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
        static string _dbFileName;
        static bool _locationServerDb;
        static string _connectionString;
        static IViewLogin _vLogin;
        static int attempt;
        static PLogin preLogin;
        static public int errorLevel;
        static public Exception Exception;
        static public string textError;

        static  SecurityContext()
        {
            attempt = 0;
            errorLevel = 0;
        }

         private static  void Login()
        {
            if (preLogin == null)
            {
                preLogin = new PLogin(_vLogin);
                preLogin.NewDataInputed += new EventHandler<EventArgs>(TestConnectionString);
                preLogin.Canceled += new EventHandler<EventArgs>(CancelAuthorization);
            }
            preLogin.Show();
        }
         private static void TestConnectionString(object send, EventArgs e)
         {
            _userName = preLogin.GetUserName();
            _password = preLogin.GetPassword();
            _serverName = preLogin.GetServerName();
            _dbName = preLogin.GetDbName();
            _dbFileName = preLogin.GetDbFileName();
            _locationServerDb = preLogin.GetLocationServerDb();
            string stringTest;
            if (_locationServerDb)
            {
                stringTest = String.Format(
                     @"data source={0}; Initial Catalog={1}; integrated security={2}; connect timeout=30; multipleactiveresultsets=True; User ID = {3}; Password = {4}; App=EntityFramework"
                     , _serverName
                     , _dbName
                     , "False"
                     , _userName
                     , _password);
            }
            else
            {
                stringTest = String.Format(
                    @"data source={0};attachdbfilename={1};integrated security={2};connect timeout=30; User ID = {3}; Password = {4};multipleactiveresultsets=True;App=EntityFramework"
                     , _serverName
                     , _dbFileName
                     , "False"
                     , _userName
                     , _password);    
            }

            try
            {
                SqlConnection conntest = new SqlConnection(stringTest);
                conntest.Open();
                conntest.Close();
            }
            catch (Exception ex)
            {
                Exception = ex;
                textError = "Не удачная попытка соединения с БД";
                errorLevel = 1;
                _connectionString = string.Empty;
                NewAuthorizationAttempt();
                return;
            }
            var entityConnectionString = new EntityConnectionStringBuilder()
            {
                Metadata = @"res://*/Model.Model1.csdl|res://*/Model.Model1.ssdl|res://*/Model.Model1.msl",
                Provider = @"System.Data.SqlClient",
                ProviderConnectionString = stringTest
            };

            _connectionString = entityConnectionString.ConnectionString;
            NewAuthorizationAttempt();
            
         }
        private static void NewAuthorizationAttempt()
        {
            if (attempt < 3 &&   String.IsNullOrEmpty(_connectionString))
            {
                Login();
                attempt++;
            }
            else 
            {
                attempt = 0;
            }
            
        }
        public static void SetLoginForm (IViewLogin vLogin)
        {
            _vLogin = vLogin;
        }

        public static string GetConnectionString_All_In_One()
        {
            errorLevel = 0;
            SecurityContext.NewAuthorizationAttempt();
            SaveTrueAutorizationParams(errorLevel);
            return _connectionString;
        }

        private static void CancelAuthorization(object sender, EventArgs e)
        {
            textError = "Отмена авторизации";
            attempt = 0;
            errorLevel = 2;
        }
        private static void SaveTrueAutorizationParams(int ErrorLevel)
        {
            if (ErrorLevel !=0)
                return;

            preLogin.SaveParams();
        }
    }
}
