using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;

namespace GeoDB.Service.DataAccess
{
    public class GorizontEntityService : IBaseService<GORIZONT>
    {
        ModelDB db = new ModelDB();

        public int Create(GORIZONT obj)
        {
            try
            {
                db.AddToGORIZONT(obj);
            }
            catch
            {
                return 1;
            }
            return 0;
        }

        public IEnumerable<GORIZONT> Get()
        {
            IEnumerable<GORIZONT> result = (from a in db.GORIZONT
                              select a).ToList();

            return result;
        }

        public GORIZONT Get(int id)
        {
            GORIZONT result = (from a in db.GORIZONT
                                    where a.BENCH_ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<GORIZONT> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.GORIZONT
                              select a).Count();
            return result;
        }
    }
}
