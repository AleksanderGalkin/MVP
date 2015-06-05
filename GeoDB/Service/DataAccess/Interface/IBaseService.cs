using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model.Interface;
using GeoDB.Model;
using GeoDB.Extensions;

namespace GeoDB.Service.DataAccess.Interface
{
    public interface IBaseService<T> where T:IBase,new()
    {
        void Create(T obj);
        void Modify(T obj);
        void Delete(T obj);
        void Refresh(T obj);
        IEnumerable<T> Get ();
        IEnumerable<T> GetByBhid (int bhid);
        T Get (int id);
        int Count ();
    }
}
