using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public enum SortererTypeCriterion { Ascending, Descending }
    public interface ILinqExtensionSorterCriterion
    {
         
         IDGVHeader _firstField { get;  }
         SortererTypeCriterion _firstTypeCriterion { get;  }
         IDGVHeader _secondField { get;  }
         SortererTypeCriterion _secondTypeCriterion { get;  }
         void Set(IDGVHeader Field, SortererTypeCriterion TypeCriterion);
    }
}
