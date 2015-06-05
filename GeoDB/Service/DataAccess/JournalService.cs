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
    public class JournalEntityService : IBaseService<JOURNAL>
    {
        ModelDB db;

        public JournalEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(JOURNAL obj)
        {
                db.AddToJOURNAL(obj);
                db.SaveChanges();
        }
        public void Modify(JOURNAL obj)
        {
                db.SaveChanges();
        }
        public void Delete(JOURNAL obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(JOURNAL obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<JOURNAL> Get()
        {
            IEnumerable<JOURNAL> result = from a in db.JOURNAL
                              select a;

            return result;
        }

        public JOURNAL Get(int id)
        {
            JOURNAL result = (from a in db.JOURNAL
                                    where a.JOURNAL_ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<JOURNAL> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.JOURNAL
                              select a).Count();
            return result;
        }
    }
}
