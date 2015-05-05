using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Extensions;

namespace GeoDB.Model
{
   public  class NumSortedFieldEventArgs : EventArgs
    {
        public int numField { get; set; }
        public LinqExtensionSorterCriterion.TypeCriterion order { get; set; }
        public NumSortedFieldEventArgs(int NumField, LinqExtensionSorterCriterion.TypeCriterion Order):base()
        {
            numField = NumField;
            order = Order;
        }
    }
}
