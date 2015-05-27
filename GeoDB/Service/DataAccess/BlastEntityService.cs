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
    public class BlastEntityService : IBaseService<RL_EXPLO2>
    {
        ModelDB db;

        public BlastEntityService()
        {
            string connectionString= MySecurity.GetAuthorisation();
            if (MySecurity.state != MySecurity.MySecurityState.success)
            {
                throw new UnauthorizedAccessException(MySecurity.textError, MySecurity.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(RL_EXPLO2 obj)
        {
                db.AddToRL_EXPLO2(obj);
                db.SaveChanges();
        }
        public void Modify(RL_EXPLO2 obj)
        {
                db.SaveChanges();
        }
        public void Delete(RL_EXPLO2 obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(RL_EXPLO2 obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<RL_EXPLO2> Get()
        {
            IEnumerable<RL_EXPLO2> result = from a in db.RL_EXPLO2
                              select a;

            return result;
        }

        public RL_EXPLO2 Get(int id)
        {
            RL_EXPLO2 result = (from a in db.RL_EXPLO2
                                    where a.EX_LINE_COD == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<RL_EXPLO2> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.RL_EXPLO2
                              select a).Count();
            return result;
        }
    }
}
