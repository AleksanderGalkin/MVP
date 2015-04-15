using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;

namespace GeoDB.Service.DataAccess
{
    public class CollarEntityService: IBaseService<COLLAR2>
    {
        ModelDB db = new ModelDB();

        public IEnumerable<COLLAR2> Get()
        {
            var result = from a in db.COLLAR2
                             select a;
            return result;
        }

        public COLLAR2 Get(int id)
        {
            var result = (from a in db.COLLAR2
                              where a.ID == id
                              select a).FirstOrDefault();
            return result;
        }
    }
}
