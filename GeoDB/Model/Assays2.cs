using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model.Interface;
using GeoDB.Extensions;
using GeoDbUserInterface.View;
using GeoDbUserInterface.ServiceInterfaces;

namespace GeoDB.Model
{
    public partial class ASSAYS2:IBase
    {
       
    }

    public class Assays2VmFull : IAssays2VmFull
    {
        
        public int bhid { get; set; }
        public string sample { get; set; }
        public double from_ { get; set; }
        public double to { get; set; }
        public double length { get; set; }
        public string zblock { get; set; }
        public string lito { get; set; }
        public string rang { get; set; }
        public double? ves { get; set; }
        public double? au { get; set; }
        public double? au_cut { get; set; }
        public double? as_ { get; set; }
        public double? sb { get; set; }
        public double? s { get; set; }
        public double? ca { get; set; }
        public double? fe { get; set; }
        public double? ag { get; set; }
        public double? c { get; set; }
        public DateTime end_date { get; set; }
        public string blank { get; set; }
        public string journal { get; set; }
        public string geologist { get; set; }
        public string pit { get; set; }
        public string lastUserID { get; set; }
        public DateTime? lastDT { get; set; }
        public int id { get; set; }

        static public List<IDGVHeader> header {
            get
            {
                List<IDGVHeader> _header = new List<IDGVHeader>();
                
                _header.Add(new DGVHeader { fieldName = "sample", fieldHeader = "Проба" });
                _header.Add(new DGVHeader { fieldName = "from_", fieldHeader = "От" });
                _header.Add(new DGVHeader { fieldName = "to", fieldHeader = "До" });
                _header.Add(new DGVHeader { fieldName = "length", fieldHeader = "Длина" });
                _header.Add(new DGVHeader { fieldName = "zblock", fieldHeader = "З.Блок" });
                _header.Add(new DGVHeader { fieldName = "lito", fieldHeader = "Литология" });
                _header.Add(new DGVHeader { fieldName = "rang", fieldHeader = "Ранг" });
                _header.Add(new DGVHeader { fieldName = "ves", fieldHeader = "Вес" });
                _header.Add(new DGVHeader { fieldName = "au", fieldHeader = "Au" });
                _header.Add(new DGVHeader { fieldName = "au_cut", fieldHeader = "Au.Огр." });
                _header.Add(new DGVHeader { fieldName = "as_", fieldHeader = "As" });
                _header.Add(new DGVHeader { fieldName = "sb", fieldHeader = "Sb" });
                _header.Add(new DGVHeader { fieldName = "s", fieldHeader = "S" });
                _header.Add(new DGVHeader { fieldName = "ca", fieldHeader = "Ca" });
                _header.Add(new DGVHeader { fieldName = "fe", fieldHeader = "Fe" });
                _header.Add(new DGVHeader { fieldName = "ag", fieldHeader = "Ag" });
                _header.Add(new DGVHeader { fieldName = "c", fieldHeader = "C" });
                _header.Add(new DGVHeader { fieldName = "end_date", fieldHeader = "Дата пробы" });
                _header.Add(new DGVHeader { fieldName = "blank", fieldHeader = "Ведом." });
                _header.Add(new DGVHeader { fieldName = "journal", fieldHeader = "Журнал" });
                _header.Add(new DGVHeader { fieldName = "geologist", fieldHeader = "Геолог" });
                _header.Add(new DGVHeader { fieldName = "pit", fieldHeader = "Карьер" });
                _header.Add(new DGVHeader { fieldName = "lastUserID", fieldHeader = "Крайний" });
                _header.Add(new DGVHeader { fieldName = "lastDT", fieldHeader = "Крайняя дата" });
                _header.Add(new DGVHeader { fieldName = "id", fieldHeader = "ID" });
                return _header;
            }
        }

        static public LinqExtensionSorterCriterion DefaultSortedField
        {
            get
            {
                LinqExtensionSorterCriterion temp = new LinqExtensionSorterCriterion();
                temp.Set(
                                new DGVHeader { fieldName = "lastDT", fieldHeader = "Крайняя дата" }
                               , SortererTypeCriterion.Descending);
                return temp;
            }
        }


    }


}
