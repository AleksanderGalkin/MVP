using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public interface IViewModel
    {
        string lastUserID { get; set; }
        DateTime? lastDT { get; set; }
    }
}
