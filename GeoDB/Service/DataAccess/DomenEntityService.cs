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
    public class DomenEntityService : IBaseService<DOMEN>
    {
        ModelDB db;

        public DomenEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(DOMEN obj)
        {
                db.AddToDOMEN(obj);
                db.SaveChanges();
        }
        public void Modify(DOMEN obj)
        {
                db.SaveChanges();
        }
        public void Delete(DOMEN obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(DOMEN obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<DOMEN> Get()
        {
            IEnumerable<DOMEN> result = from a in db.DOMEN
                              select a;

            return result;
        }

        public DOMEN Get(int id)
        {
            DOMEN result = (from a in db.DOMEN
                                    where a.ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<DOMEN> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.DOMEN
                              select a).Count();
            return result;
        }
    }
}
