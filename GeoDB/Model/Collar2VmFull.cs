using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model.Interface;

namespace GeoDB.Model
{
    public class Collar2VmFull:IViewModel
    {
        public int id { get; set; }
        public string bhid { get; set; }
        public int gorizont { get; set; }
        public string blast { get; set; }
        public int hole { get; set; }
        public double xcollar { get; set; }
        public double ycollar { get; set; }
        public double zcollar { get; set; }
        public double enddepth { get; set; }
        public string drillType { get; set; }
        public int? lastUserID { get; set; }
        public DateTime? lastDT { get; set; }

    }
}
