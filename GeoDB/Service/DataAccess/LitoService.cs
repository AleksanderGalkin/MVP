﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Data.Objects;

namespace GeoDB.Service.DataAccess
{
    public class LitoEntityService : IBaseService<LITOLOGY>
    {
        ModelDB db;

        public LitoEntityService()
        {
            string connectionString= SecurityContext.GetConnectionString_All_In_One();
            if (SecurityContext.errorLevel != 0)
            {
                throw new UnauthorizedAccessException(SecurityContext.textError, SecurityContext.Exception);
            }
            db = new ModelDB(connectionString);
        }

        public void Create(LITOLOGY obj)
        {
                db.AddToLITOLOGY(obj);
                db.SaveChanges();
        }
        public void Modify(LITOLOGY obj)
        {
                db.SaveChanges();
        }
        public void Delete(LITOLOGY obj)
        {
                db.DeleteObject(obj);
                db.SaveChanges();
        }
        public void Refresh(LITOLOGY obj)
        {
            db.Refresh(RefreshMode.StoreWins, obj);
        }
        public IEnumerable<LITOLOGY> Get()
        {
            IEnumerable<LITOLOGY> result = (from a in db.LITOLOGY
                              select a).ToList();

            return result;
        }

        public LITOLOGY Get(int id)
        {
            LITOLOGY result = (from a in db.LITOLOGY
                                    where a.LITO_ID == id
                                    select a).FirstOrDefault();
            return result;
        }

        public IEnumerable<LITOLOGY> GetByBhid(int bhid)
        {
            throw new InvalidOperationException("Not implement operation");
        }

        public int Count()
        {
            int result = (from a in db.LITOLOGY
                              select a).Count();
            return result;
        }
    }
}
