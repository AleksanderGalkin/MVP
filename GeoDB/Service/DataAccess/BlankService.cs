﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;

namespace GeoDB.Service.DataAccess
{
    public class BlankEntityService : IBaseService<REESTR_VEDOMOSTEI>
    {
        ModelDB db;
        public BlankEntityService()
        {
            string connectionString= SecurityContext.GetConnectionString_All_In_One();
            if (SecurityContext.errorLevel != 0)
            {
                throw new UnauthorizedAccessException(SecurityContext.textError, SecurityContext.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(REESTR_VEDOMOSTEI obj)
        {
                db.AddToREESTR_VEDOMOSTEI(obj);
                db.SaveChanges();
        }
        public void Modify(REESTR_VEDOMOSTEI obj)
        {
                db.SaveChanges();
        }
        public void Delete(REESTR_VEDOMOSTEI obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(REESTR_VEDOMOSTEI obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<REESTR_VEDOMOSTEI> Get()
        {
            IEnumerable<REESTR_VEDOMOSTEI> result = (from a in db.REESTR_VEDOMOSTEI
                              select a).ToList();

            return result;
        }

        public REESTR_VEDOMOSTEI Get(int id)
        {
            REESTR_VEDOMOSTEI result = (from a in db.REESTR_VEDOMOSTEI
                                    where a.ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<REESTR_VEDOMOSTEI> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.REESTR_VEDOMOSTEI
                              select a).Count();
            return result;
        }
    }
}
