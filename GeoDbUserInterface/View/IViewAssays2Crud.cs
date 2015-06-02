using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GeoDbUserInterface.View
{
    public interface IViewAssays2Crud
    {
         
         string Tittle { set; }
         int bhid { get; set; }
         string sample { get; set; }
         double? from_ { get; set; }
         double? to { get; set; }
         double? length { get; set; }

         int? zblock { get; set; }
         Dictionary<int, string> zblokList { set; }
         int? lito { get; set; }
         Dictionary<int, string> litoList { set; }
         int? rang { get; set; }
         Dictionary<int, string> rangList { set; }

         DateTime end_date { get; set; }

         int? blank { get; set; }
         Dictionary<int, string> blankList { set; }

         int? journal { get; set; }
         Dictionary<int, string> journalList { set; }

         int? geologist { get; set; }
         Dictionary<int, string> geologistList { set; }

         string pit { get; set; }
         Dictionary<string, string> pitList { set; }

         //string lastUserID { get; set; }
         //DateTime? lastDT { get; set; }

        IView mdiParent { set; }
        IView OwnerForm { set; }
        void Show(bool ReadOnly = false);
        void Refresh();
        void Hide();
        void Close();
        event EventHandler<EventArgs> clickOk;
        event EventHandler<EventArgs> clickCloseForm;


    }
}


      