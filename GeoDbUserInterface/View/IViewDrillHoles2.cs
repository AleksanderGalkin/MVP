using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.ServiceInterfaces;


namespace GeoDbUserInterface.View
{
    public interface IViewDrillHoles2 : IView
    {
        List<IDGVHeader> CollarHeader { set;  }
        Dictionary<int, ICollar2VmFull> CollarList { set;}
        int rowCollarCount { set;  }
        int sortedCollarNumField { set;  }
        SortererTypeCriterion
            SortedCollarCriterion { set;  }
        bool[] filteredCollarNumField { set;  }


        event EventHandler<ANumRowEventArgs> showAnyCollarScreen;
        event EventHandler<AFilterParamsEventArgs> settedCollarFilter;
        event EventHandler<ANumSortedFieldEventArgs> clickCollarHeader;
        event EventHandler<ANumRowEventArgs> setCurrentRow;
        event EventHandler<EventArgs> clickCollarCreateData;
        event EventHandler<ANumRowEventArgs> clickCollarEditData;
        event EventHandler<ANumRowEventArgs> clickCollarDeleteData;
        
        

        List<IDGVHeader> AssaysHeader { set; }
        Dictionary<int, IAssays2VmFull> AssaysList { set;  }
        int rowAssaysCount { set;  }
        int sortedAssaysNumField { set;  }
        SortererTypeCriterion
            SortedAssaysCriterion { set;  }
        bool[] filteredAssaysNumField { set; }



        event EventHandler<ANumRowEventArgs> showAnyAssaysScreen;
        event EventHandler<AFilterParamsEventArgs> settedAssaysFilter;
        event EventHandler<ANumSortedFieldEventArgs> clickAssaysHeader;
        event EventHandler<EventArgs> clickAssaysCreateData;
        event EventHandler<ANumRowEventArgs> clickAssaysEditData;
        event EventHandler<ANumRowEventArgs> clickAssaysDeleteData;

        IView mdiParent { set; }
        bool Enabled { set; }
        void Show();
        void Close();
        void Hide();
        void RefreshCollar();
        void RefreshAssays();

        event EventHandler<EventArgs> clickCloseForm;
        event EventHandler<EventArgs> _FormClosing;

    }
}
