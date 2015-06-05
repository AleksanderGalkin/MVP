using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public class AFilterParamsEventArgs:EventArgs
    {
        public int numField { get; set; }
        public ILinqExtensionFilterCriterion criterion { get; set; }
        public AFilterParamsEventArgs(int NumField, ILinqExtensionFilterCriterion Criterion)
            : base()
        {
            numField = NumField;
            criterion = Criterion;
        }
    }
}
