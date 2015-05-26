﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;

namespace GeoDB.Service.DataAccess
{
    public class DrillingTypeEntityService : IBaseService<DRILLING_TYPE>
    {
        ModelDB db;

        public DrillingTypeEntityService()
        {
            string connectionString= SecurityContext.GetConnectionString_All_In_One();
            if (SecurityContext.errorLevel != 0)
            {
                throw new UnauthorizedAccessException(SecurityContext.textError, SecurityContext.Exception);
            }
            db = new ModelDB(connectionString);
        }
        public void Create(DRILLING_TYPE obj)
        {
                db.AddToDRILLING_TYPE(obj);
                db.SaveChanges();
        }
        public void Modify(DRILLING_TYPE obj)
        {
                db.SaveChanges();
        }
        public void Delete(DRILLING_TYPE obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(DRILLING_TYPE obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
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
