using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;

namespace GeoDB.Service.DataAccess
{
    public class AssaysEntityService : IBaseService<ASSAYS2>
    {
        ModelDB db = new ModelDB();

        public IEnumerable<ASSAYS2> Get()
        {
            IEnumerable<ASSAYS2> result = (from a in db.ASSAYS2
                              select a).ToList();

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
