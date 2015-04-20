using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDB.Model.Interface
{
    interface IViewModel
    {
        int? lastUserID { get; set; }
        DateTime? lastDT { get; set; }
    }
}
