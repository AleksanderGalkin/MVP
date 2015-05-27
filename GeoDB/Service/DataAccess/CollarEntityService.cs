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
using GeoDB.Service.Security;
using GeoDB.Extensions;


namespace GeoDB.Service.DataAccess
{
    public class CollarEntityService : IBaseService<COLLAR2>
    {
        

        ModelDB db;

        public CollarEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
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
            IEnumerable<COLLAR2> result = from a in db.COLLAR2
                              select a;

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
