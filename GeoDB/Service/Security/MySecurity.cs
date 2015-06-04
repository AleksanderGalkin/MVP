using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;
using GeoDB.Presenter;
using System.Security.Principal;
using System.Security;
using System.Threading;
using System.Security.Permissions;
using GeoDbUserInterface.View;
using Ninject;
using Ninject.Parameters;

namespace GeoDB.Service.Security
{
    public static class MySecurity
    {
        static public Exception Exception;
        static public string textError;
        public enum MySecurityState { success, empty, dbAccessFailure, userCancelAuthorisation };
        static public MySecurityState state;
        
        static private string _userName;
        static private string _password;
        static private string _serverName;
        static private string _dbName;
        static private string _dbFileName;
        static private bool _locationServerDb;
        static private bool _isWindowsAuthentication;
        static private string _connectionString;
        static private IViewLogin _vLogin;
        static private int attemptCounter;
        static private PLogin preLogin;
        

        static  MySecurity()
        {
            attemptCounter = 0;
            state = MySecurityState.empty;
        }

        private static  void Login()
        {
            if (preLogin == null)
            {
                preLogin = StaticInformation.ninjectKernel.Get<PLogin>();
                preLogin.NewDataInputed += new EventHandler<EventArgs>(TestAccount);
                preLogin.Canceled += new EventHandler<EventArgs>(CancelAuthorization);
            }
            preLogin.Show();
        }
        private static void TestAccount(object send, EventArgs e)
         {
            _userName = preLogin.GetUserName();
            _password = preLogin.GetPassword();
            _serverName = preLogin.GetServerName();
            _dbName = preLogin.GetDbName();
            _dbFileName = preLogin.GetDbFileName();
            _locationServerDb = preLogin.GetLocationServerDb();
            _isWindowsAuthentication = preLogin.isWindowsAuthentication();
            string stringTest;
            if (_locationServerDb)
            {
                stringTest = String.Format(
                     @"data source={0}; Initial Catalog={1}; integrated security={2}; connect timeout=30; multipleactiveresultsets=True; User ID = {3}; Password = {4}; App=EntityFramework"
                     , _serverName
                     , _dbName
                     , _isWindowsAuthentication
                     , _userName
                     , _password);
            }
            else
            {
                stringTest = String.Format(
                    @"data source={0};attachdbfilename={1};User Instance={2};integrated security={2};connect timeout=30; User ID = {3}; Password = {4};multipleactiveresultsets=True;App=EntityFramework"
                     , _serverName
                     , _dbFileName
                     , _isWindowsAuthentication
                     , _userName
                     , _password);    
            }
 
            try
            {
                SqlConnection conntest = new SqlConnection(stringTest);
                conntest.Open();
                conntest.Close();
            }
            catch (SqlException ex)
            {
                Exception = ex;
                if (ex.Number == 5120)
                {
                    textError = "В случае SQL авторизации, для учётной записи под которой работает SQL2008 EXPRESS должны быть предоставлены полные права для файлов данных MDF и LDF";
                }
                else
                {
                    textError = "Не удачная попытка соединения с БД";
                }
                state = MySecurityState.dbAccessFailure;
                string message = textError + Environment.NewLine + ex.Message;
                PException pexception = StaticInformation.ninjectKernel.Get<PException>(new ConstructorArgument("MessageText", message, false));
                pexception.Show();

                _connectionString = string.Empty;
                NewAuthorizationAttempt();
                return;
            }
            state = MySecurityState.success;
            var entityConnectionString = new EntityConnectionStringBuilder()
            {
                Metadata = @"res://*/Model.Model1.csdl|res://*/Model.Model1.ssdl|res://*/Model.Model1.msl",
                Provider = @"System.Data.SqlClient",
                ProviderConnectionString = stringTest
            };
            _connectionString = entityConnectionString.ConnectionString;
            SetCurrentPrincipal(stringTest);
         }
        private static void NewAuthorizationAttempt()
        {
            if (attemptCounter < 3 && state != MySecurityState.success)
            {
                Login();
                attemptCounter++;
            }
        }
        public static void SetLoginForm (IViewLogin vLogin)
        {
            _vLogin = vLogin;
        }
        public static string GetAuthorisation()
        {
            if (state != MySecurityState.success)
            {
                attemptCounter = 0;
                MySecurity.NewAuthorizationAttempt();
                SaveTrueAutorizationParams();
            }
            return _connectionString;
        }

        private static void CancelAuthorization(object sender, EventArgs e)
        {
            preLogin.NewDataInputed -= new EventHandler<EventArgs>(TestAccount);
            preLogin.Canceled -= new EventHandler<EventArgs>(CancelAuthorization);
            textError = "Отмена авторизации";
            attemptCounter = 0;
            state = MySecurityState.userCancelAuthorisation;
        }
        private static void SaveTrueAutorizationParams()
        {
            if (state != MySecurityState.success)
                return;

            preLogin.SaveParams();
            preLogin.NewDataInputed -= new EventHandler<EventArgs>(TestAccount);
            preLogin.Canceled -= new EventHandler<EventArgs>(CancelAuthorization);
        }
        private static void SetCurrentPrincipal(string ConnecrionString)
        {
            using (SqlConnection con = new SqlConnection(ConnecrionString))
            {
                con.Open();
                List<string> rolesArray = new List<string>();
                string strSelect = String.Format("select rp.name as database_role" +
                        " from sys.database_role_members drm" +
                        " join sys.database_principals rp on (drm.role_principal_id = rp.principal_id)" +
                        " join sys.database_principals mp on (drm.member_principal_id = mp.principal_id) " +
                                                            " and (mp.name like '{0}')",_userName);
                using (SqlCommand cmd = new SqlCommand(strSelect, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            rolesArray.Add(reader.GetString(0));
                        }
                        IIdentity userIdentity = new GenericIdentity(_userName);
                        Thread.CurrentPrincipal = new GenericPrincipal(userIdentity, rolesArray.ToArray());
                    }
                con.Close();
            }
        }
    }
}
