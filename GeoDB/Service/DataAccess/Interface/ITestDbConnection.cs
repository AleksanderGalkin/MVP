using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDB.Service.DataAccess.Interface
{
    public interface ITestDbConnection
    {
        string TestAndGetConString(string userName, string password, string serverName, string dbName);
    }
}
