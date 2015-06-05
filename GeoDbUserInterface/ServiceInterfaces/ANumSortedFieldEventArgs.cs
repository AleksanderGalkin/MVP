using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public class ANumSortedFieldEventArgs: EventArgs
    {
        public int numField { get; set; }
        public SortererTypeCriterion order { get; set; }
        public ANumSortedFieldEventArgs(int NumField, SortererTypeCriterion Order)
            : base()
        {
            numField = NumField;
            order = Order;
        }
    }
}
