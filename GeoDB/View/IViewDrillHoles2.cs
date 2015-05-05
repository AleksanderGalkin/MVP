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
        Dictionary<int, Collar2VmFull> CollarList { set; get; }
        int minCollarRow { set; get; }
        int maxCollarRow { set; get; }
        int rowCollarCount { set; get; }
        int sortedCollarNumField { set; get; }
        LinqExtensionSorterCriterion.TypeCriterion
            SortedCollarCriterion { set; get; }
        bool[] filteredCollarNumField { set; get; }
        event EventHandler<EventArgs> clickCollarData;
        event EventHandler<EventArgs> showPrevCollarScreen;
        event EventHandler<EventArgs> showNextCollarScreen;
        event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        event EventHandler<EventArgs> clickCollarFilters;
        event EventHandler<NumSortedFieldEventArgs> clickCollarHeader;
        event EventHandler<NumRowEventArgs> setCurrentRow;
        
        List<DGVHeader> AssaysHeader { set; }
        Dictionary<int, Assays2VmFull> AssaysList { set; get; }
        int minAssaysRow { set; get; }
        int maxAssaysRow { set; get; }
        int rowAssaysCount { set; get; }
        int sortedAssaysNumfield { set; get; }
        LinqExtensionSorterCriterion.TypeCriterion
            SortedAssaysCriterion { set; get; }
        event EventHandler<EventArgs> clickAssaysData;
        event EventHandler<EventArgs> showPrevAssaysScreen;
        event EventHandler<EventArgs> showNextAssaysScreen;
        event EventHandler<NumRowEventArgs> showAnyAssaysScreen;
        event EventHandler<EventArgs> clickAssaysFilters;
        event EventHandler<NumSortedFieldEventArgs> clickAssaysHeader;

        void Show();
        void Close();
        void RefreshCollar();
        void UpdateCollarHeaderState();
        void RefreshAssays();
        void UpdateAssaysHeaderState();
        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickCloseForm;


    }
}
