﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model.Interface;
using GeoDB.Extensions;

namespace GeoDB.Model
{
    public partial class GORIZONT:IBase
    {
       
    }

    //public class Collar2VmFull : IViewModel
    //{
    //    public int id { get; set; }
    //    public string bhid { get; set; }
    //    public int gorizont { get; set; }
    //    public string blast { get; set; }
    //    public int hole { get; set; }
    //    public double xcollar { get; set; }
    //    public double ycollar { get; set; }
    //    public double zcollar { get; set; }
    //    public double enddepth { get; set; }
    //    public string drillType { get; set; }
    //    public string lastUserID { get; set; }
    //    public DateTime? lastDT { get; set; }

    //    static public List<DGVHeader> header {
    //        get
    //        {
    //            List<DGVHeader> _header = new List<DGVHeader>();
                
               
    //            _header.Add(new DGVHeader { fieldName = "bhid", fieldHeader = "BHID" });
    //            _header.Add(new DGVHeader { fieldName = "gorizont", fieldHeader = "Гор." });
    //            _header.Add(new DGVHeader { fieldName = "blast", fieldHeader = "Блок" });
    //            _header.Add(new DGVHeader { fieldName = "hole", fieldHeader = "Скв." });
    //            _header.Add(new DGVHeader { fieldName = "xcollar", fieldHeader = "X" });
    //            _header.Add(new DGVHeader { fieldName = "ycollar", fieldHeader = "Y" });
    //            _header.Add(new DGVHeader { fieldName = "zcollar", fieldHeader = "Z" });
    //            _header.Add(new DGVHeader { fieldName = "enddepth", fieldHeader = "Длина" });
    //            _header.Add(new DGVHeader { fieldName = "drillType", fieldHeader = "Станок" });
    //            _header.Add(new DGVHeader { fieldName = "lastUserID", fieldHeader = "Крайний" });
    //            _header.Add(new DGVHeader { fieldName = "lastDT", fieldHeader = "Крайняя дата" });
    //            _header.Add(new DGVHeader { fieldName = "id", fieldHeader = "ID" });
    //            return _header;
    //        }
    //    }
    //    static public LinqExtensionSorterCriterion DefaultSortedField
    //    {
    //        get 
    //        {
    //            LinqExtensionSorterCriterion temp = new LinqExtensionSorterCriterion();
    //             temp.Set(
    //                             new DGVHeader{ fieldName = "lastDT", fieldHeader = "Крайняя дата" }
    //                            ,LinqExtensionSorterCriterion.TypeCriterion.Descending);
    //             return temp;
    //        }
    //    }


    //}


}
