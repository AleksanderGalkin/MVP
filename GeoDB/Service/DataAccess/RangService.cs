using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;
using GeoDB.Service.Security;

namespace GeoDB.Service.DataAccess
{
    public class RangEntityService : IBaseService<RANG>
    {
        ModelDB db;

        public RangEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(RANG obj)
        {
                db.AddToRANG(obj);
                db.SaveChanges();
        }
        public void Modify(RANG obj)
        {
                db.SaveChanges();
        }
        public void Delete(RANG obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(RANG obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<RANG> Get()
        {
            IEnumerable<RANG> result = from a in db.RANG
                              select a;

            return result;
        }

        public RANG Get(int id)
        {
            RANG result = (from a in db.RANG
                                    where a.ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<RANG> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.RANG
                              select a).Count();
            return result;
        }
    }
}
