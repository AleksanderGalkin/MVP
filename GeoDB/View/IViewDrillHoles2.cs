using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Extensions;

namespace GeoDB.View
{
    public interface IViewDrillHoles2
    {
        List<DGVHeader> CollarHeader { set;  }
        Dictionary<int, Collar2VmFull> CollarList { set;}
        int rowCollarCount { set;  }
        int sortedCollarNumField { set;  }
        LinqExtensionSorterCriterion.TypeCriterion
            SortedCollarCriterion { set;  }
        bool[] filteredCollarNumField { set;  }
        event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        event EventHandler<FilterParamsEventArgs> settedCollarFilter;
        event EventHandler<NumSortedFieldEventArgs> clickCollarHeader;
        event EventHandler<NumRowEventArgs> setCurrentRow;
        event EventHandler<EventArgs> clickCollarCreateData;
        event EventHandler<NumRowEventArgs> clickCollarEditData;
        event EventHandler<NumRowEventArgs> clickCollarDeleteData;

        List<DGVHeader> AssaysHeader { set; }
        Dictionary<int, Assays2VmFull> AssaysList { set;  }
        int rowAssaysCount { set;  }
        int sortedAssaysNumField { set;  }
        LinqExtensionSorterCriterion.TypeCriterion
            SortedAssaysCriterion { set;  }
        bool[] filteredAssaysNumField { set; }
        event EventHandler<NumRowEventArgs> showAnyAssaysScreen;
        event EventHandler<FilterParamsEventArgs> settedAssaysFilter;
        event EventHandler<NumSortedFieldEventArgs> clickAssaysHeader;
        event EventHandler<EventArgs> clickAssaysCreateData;
        event EventHandler<NumRowEventArgs> clickAssaysEditData;
        event EventHandler<NumRowEventArgs> clickAssaysDeleteData;

        void Show();
        void Close();
        void RefreshCollar();
        void RefreshAssays();

        event EventHandler<EventArgs> clickCloseForm;


    }
}
