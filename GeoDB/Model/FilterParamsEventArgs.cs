using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Extensions;

namespace GeoDB.Model
{
   public  class FilterParamsEventArgs : EventArgs
    {
        public int numField { get; set; }
        public LinqExtensionFilterCriterion criterion { get; set; }
        public FilterParamsEventArgs(int NumField, LinqExtensionFilterCriterion Criterion)
            : base()
        {
            numField = NumField;
            criterion = Criterion;
        }
    }
}
