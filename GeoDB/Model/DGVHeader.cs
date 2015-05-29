using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDBWinForms.ServiceInterfaces;

namespace GeoDB.Model
{
    public class DGVHeader : IDGVHeader
    {
        public string fieldName { get; set; }
        public string fieldHeader { get; set; }
    }

    public class DGVHeaderComparer : IEqualityComparer<DGVHeader>
    {
        public bool Equals(DGVHeader a, DGVHeader b)
        {
            return a.fieldHeader == b.fieldHeader && a.fieldName == b.fieldName;
        }
        public int GetHashCode(DGVHeader a)
        {
            return a.fieldHeader.GetHashCode() + a.fieldName.GetHashCode();
        }
    }
}
