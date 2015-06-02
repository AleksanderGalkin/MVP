using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GeoDbUserInterface.ServiceInterfaces
{
    public interface ICollar2VmFull  : IViewModel
    {
        int id { get; set; }
        string bhid { get; set; }
        int gorizont { get; set; }
        string blast { get; set; }
        int hole { get; set; }
        double xcollar { get; set; }
        double ycollar { get; set; }
        double zcollar { get; set; }
        double enddepth { get; set; }
        string drillType { get; set; }
        int domen { get; set; }
      //  string lastUserID { get; set; }
      //  DateTime? lastDT { get; set; }

      //  static  List<IDGVHeader> header { get; }
    }

    
}
