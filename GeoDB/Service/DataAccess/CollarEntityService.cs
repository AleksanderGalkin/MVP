using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;

namespace GeoDB.Service.DataAccess
{
    public class CollarEntityService : IBaseService<COLLAR2>
    {
        ModelDB db = new ModelDB();

        public int Create(COLLAR2 obj)
        {
            try
            {
                db.AddToCOLLAR2(obj);
                db.SaveChanges();
            }
            catch
            {
                return 1;
            }
            return 0;
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
