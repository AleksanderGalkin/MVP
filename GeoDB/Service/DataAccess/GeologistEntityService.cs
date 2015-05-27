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
    public class GeologistEntityService : IBaseService<GEOLOGIST>
    {
        ModelDB db;

        public GeologistEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
        }
        public void Create(GEOLOGIST obj)
        {
                db.AddToGEOLOGIST(obj);
                db.SaveChanges();
        }
        public void Modify(GEOLOGIST obj)
        {
                db.SaveChanges();
        }
        public void Delete(GEOLOGIST obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(GEOLOGIST obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<GEOLOGIST> Get()
        {
            IEnumerable<GEOLOGIST> result = from a in db.GEOLOGIST
                              select a;

            return result;
        }

        public GEOLOGIST Get(int id)
        {
            GEOLOGIST result = (from a in db.GEOLOGIST
                                    where a.GEOLOGIST_ID == id
                                    select a).FirstOrDefault();
            return result;
        }
        public IEnumerable<GEOLOGIST> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }
        public int Count()
        {
            int result = (from a in db.GEOLOGIST
                              select a).Count();
            return result;
        }
    }
}
