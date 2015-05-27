using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;
using GeoDB.Service.Security;
using GeoDB.Extensions;

namespace GeoDB.Service.DataAccess
{
    public class AssaysEntityService : IBaseService<ASSAYS2>
    {
        ModelDB db;
        public AssaysEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(ASSAYS2 obj)
        {
                db.AddToASSAYS2(obj);
                db.SaveChanges();
        }
        public void Modify(ASSAYS2 obj)
        {
                db.SaveChanges();
        }

        public void Delete(ASSAYS2 obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(ASSAYS2 obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<ASSAYS2> Get()
        {
            IEnumerable<ASSAYS2> result = from a in db.ASSAYS2
                              select a;

            return result;
        }
        public ASSAYS2 Get(int id)
        {
            ASSAYS2 result = (from a in db.ASSAYS2
                                    where a.ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<ASSAYS2> GetByBhid(int bhid)
        {
            IEnumerable<ASSAYS2> result = (from a in db.ASSAYS2
                                           where a.BHID==bhid
                                           select a).ToList();

            return result;
        }

        public int Count()
        {
            int result = (from a in db.ASSAYS2
                              select a).Count();
            return result;
        }
    }
}
