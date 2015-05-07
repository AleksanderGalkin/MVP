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
        event EventHandler<EventArgs> clickCollarData;
        event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        event EventHandler<EventArgs> clickCollarFilters;
        event EventHandler<NumSortedFieldEventArgs> clickCollarHeader;
        event EventHandler<NumRowEventArgs> setCurrentRow;
        
        List<DGVHeader> AssaysHeader { set; }
        Dictionary<int, Assays2VmFull> AssaysList { set;  }
        int rowAssaysCount { set;  }
        int sortedAssaysNumfield { set;  }
        LinqExtensionSorterCriterion.TypeCriterion
            SortedAssaysCriterion { set;  }
        event EventHandler<EventArgs> clickAssaysData;
        event EventHandler<NumRowEventArgs> showAnyAssaysScreen;
        event EventHandler<EventArgs> clickAssaysFilters;
        event EventHandler<NumSortedFieldEventArgs> clickAssaysHeader;

        void Show();
        void Close();
        void RefreshCollar();
        void RefreshAssays();
        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickCloseForm;


    }
}
