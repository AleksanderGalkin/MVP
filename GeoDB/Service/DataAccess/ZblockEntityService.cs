using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;

namespace GeoDB.Service.DataAccess
{
    public class ZblockEntityService : IBaseService<BLOCK_ZAPASOV>
    {
        ModelDB db;

        public ZblockEntityService()
        {
            string connectionString= SecurityContext.GetConnectionString_All_In_One();
            if (SecurityContext.errorLevel != 0)
            {
                throw new UnauthorizedAccessException(SecurityContext.textError, SecurityContext.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(BLOCK_ZAPASOV obj)
        {
                db.AddToBLOCK_ZAPASOV(obj);
                db.SaveChanges();
        }
        public void Modify(BLOCK_ZAPASOV obj)
        {
                db.SaveChanges();
        }
        public void Delete(BLOCK_ZAPASOV obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(BLOCK_ZAPASOV obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<BLOCK_ZAPASOV> Get()
        {
            IEnumerable<BLOCK_ZAPASOV> result = (from a in db.BLOCK_ZAPASOV
                              select a).ToList();

            return result;
        }

        public BLOCK_ZAPASOV Get(int id)
        {
            BLOCK_ZAPASOV result = (from a in db.BLOCK_ZAPASOV
                                    where a.RESERVERS_BLOCK == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<BLOCK_ZAPASOV> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.BLOCK_ZAPASOV
                              select a).Count();
            return result;
        }
    }
}
