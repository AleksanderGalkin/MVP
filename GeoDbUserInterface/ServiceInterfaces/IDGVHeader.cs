using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public interface IDGVHeader
    {
         string fieldName { get; set; }
         string fieldHeader { get; set; }
    }
}
