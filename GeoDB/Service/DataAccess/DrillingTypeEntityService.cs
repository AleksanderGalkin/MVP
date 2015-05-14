using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;

namespace GeoDB.Service.DataAccess
{
    public class DrillingTypeEntityService : IBaseService<DRILLING_TYPE>
    {
        ModelDB db = new ModelDB();
        public int Create(DRILLING_TYPE obj)
        {
            try
            {
                db.AddToDRILLING_TYPE(obj);
            }
            catch
            {
                return 1;
            }
            return 0;
        }
        public IEnumerable<DRILLING_TYPE> Get()
        {
            IEnumerable<DRILLING_TYPE> result = (from a in db.DRILLING_TYPE
                              select a).ToList();

            return result;
        }

        public DRILLING_TYPE Get(int id)
        {
            DRILLING_TYPE result = (from a in db.DRILLING_TYPE
                                    where a.DRILL_ID == id
                                    select a).FirstOrDefault();
            return result;
        }
        public IEnumerable<DRILLING_TYPE> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }
        public int Count()
        {
            int result = (from a in db.DRILLING_TYPE
                              select a).Count();
            return result;
        }
    }
}
