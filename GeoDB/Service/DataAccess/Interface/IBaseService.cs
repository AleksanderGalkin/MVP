using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model.Interface;

namespace GeoDB.Service.DataAccess.Interface
{
    public interface IBaseService<T> where T:IBase,new()
    {

        IEnumerable<T> Get();
        IEnumerable<T> GetByBhid(int bhid);
        T Get(int id);
        int Count();
    }
}
