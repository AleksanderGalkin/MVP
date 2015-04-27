﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;

namespace GeoDB.Service.DataAccess
{
    public class CollarEntityService : IBaseService<COLLAR2>
    {
        ModelDB db = new ModelDB();

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

        public int Count()
        {
            int result = (from a in db.COLLAR2
                              select a).Count();
            return result;
        }
    }
}
