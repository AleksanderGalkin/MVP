using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;

namespace GeoDB.Service.DataAccess
{
    public class GeologistEntityService : IBaseService<GEOLOGIST>
    {
        ModelDB db = new ModelDB();

        public IEnumerable<GEOLOGIST> Get()
        {
            IEnumerable<GEOLOGIST> result = (from a in db.GEOLOGIST
                              select a).ToList();

            return result;
        }

        public GEOLOGIST Get(int id)
        {
            GEOLOGIST result = (from a in db.GEOLOGIST
                                    where a.GEOLOGIST_ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public int Count()
        {
            int result = (from a in db.GEOLOGIST
                              select a).Count();
            return result;
        }
    }
}
