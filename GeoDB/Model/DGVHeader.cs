using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.ServiceInterfaces;


namespace GeoDB.Model
{
    public class DGVHeader : IDGVHeader
    {
        public string fieldName { get; set; }
        public string fieldHeader { get; set; }
    }

    public class DGVHeaderComparer : IEqualityComparer<IDGVHeader>
    {
        public bool Equals(IDGVHeader a, IDGVHeader b)
        {
            return a.fieldHeader == b.fieldHeader && a.fieldName == b.fieldName;
        }
        public int GetHashCode(IDGVHeader a)
        {
            return a.fieldHeader.GetHashCode() + a.fieldName.GetHashCode();
        }
    }
}
