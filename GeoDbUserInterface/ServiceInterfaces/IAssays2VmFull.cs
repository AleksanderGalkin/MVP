using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public interface IAssays2VmFull : IViewModel
    {
        int bhid { get; set; }
        string sample { get; set; }
        double from_ { get; set; }
        double to { get; set; }
        double length { get; set; }
        string zblock { get; set; }
        string lito { get; set; }
        string rang { get; set; }
        double? ves { get; set; }
        double? au { get; set; }
        double? au_cut { get; set; }
        double? as_ { get; set; }
        double? sb { get; set; }
        double? s { get; set; }
        double? ca { get; set; }
        double? fe { get; set; }
        double? ag { get; set; }
        double? c { get; set; }
        DateTime end_date { get; set; }
        string blank { get; set; }
        string journal { get; set; }
        string geologist { get; set; }
        string pit { get; set; }
       // string lastUserID { get; set; }
       // DateTime? lastDT { get; set; }
        int id { get; set; }
    }
}
