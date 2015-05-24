using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;

namespace GeoDB.Service.DataAccess
{
    public class CollarEntityService : IBaseService<COLLAR2>
    {
        

        ModelDB db;

        public CollarEntityService()
        {
            var newConnectionTest = String.Format(
                @"data source={0}; Initial Catalog={1}; integrated security={2}; connect timeout=30; multipleactiveresultsets=True; User ID = {3}; Password = {4}; App=EntityFramework"
                , "OGK-S-APPMINE01\\MINESQL"
                , "bl_TEST"
                , "False"
                , "test"
                , "1641642eE");

            SqlConnection conntest = new SqlConnection(newConnectionTest);
            conntest.Open();
            conntest.Close();

            var new2Connection = new EntityConnectionStringBuilder()
            {
                Metadata = @"res://*/Model.Model1.csdl|res://*/Model.Model1.ssdl|res://*/Model.Model1.msl",
                Provider = @"System.Data.SqlClient",
                ProviderConnectionString = newConnectionTest
            };
            

            db = new ModelDB(new2Connection.ConnectionString);
        }

        public void Create(COLLAR2 obj)
        {
                db.AddToCOLLAR2(obj);
                db.SaveChanges();
        }

        public void Modify(COLLAR2 obj)
        {
                db.SaveChanges();
        }
        public void Delete(COLLAR2 obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(COLLAR2 obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<COLLAR2> Get()
        {
            IEnumerable<COLLAR2> result = (from a in db.COLLAR2
                              select a).ToList();

            return result;
        }

        public COLLAR2 Get(int id)
        {
            COLLAR2 result = (from a in db.COLLAR2
                                    where a.ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<COLLAR2> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.COLLAR2
                              select a).Count();
            return result;
        }
    }
}
