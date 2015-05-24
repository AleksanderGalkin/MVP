using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using System.Data.SqlClient;
using System.Data.EntityClient;


namespace GeoDB.Service.DataAccess
{
    public class TestMsSqlConnection:ITestDbConnection
    {
       public  string TestAndGetConString(string userName, string password, string serverName, string dbName)
        {
            var newConnectionTest = String.Format(
              @"data source={0}; Initial Catalog={1}; integrated security={2}; connect timeout=30; multipleactiveresultsets=True; User ID = {3}; Password = {4}; App=EntityFramework"
              , serverName
              , dbName
              , "False"
              , userName
              , password);

            SqlConnection conntest = new SqlConnection(newConnectionTest);
            conntest.Open();
            conntest.Close();

            var new2Connection = new EntityConnectionStringBuilder()
            {
                Metadata = @"res://*/Model.Model1.csdl|res://*/Model.Model1.ssdl|res://*/Model.Model1.msl",
                Provider = @"System.Data.SqlClient",
                ProviderConnectionString = newConnectionTest
            };

            return new2Connection.ConnectionString;
        }
    }
}
