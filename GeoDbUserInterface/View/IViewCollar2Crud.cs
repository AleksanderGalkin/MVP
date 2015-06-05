using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GeoDbUserInterface.View
{
    public interface IViewCollar2Crud 
    {
         
         string Tittle { set; }
         int id { get; set; }
         Dictionary<int, string> gorizontList { set; }
         int? gorizontID { get; set; }
         Dictionary<int, string> blastList { set; }
         int? blast { get; set; }
         int? hole { get; set; }
         double? xcollar { get; set; }
         double? ycollar { get; set; }
         double? zcollar { get; set; }
         double? enddepth { get; set; }
         Dictionary<int, string> drillTypeList { set; }
         int? drillType { get; set; }
         int? domenId { get; set; }
         Dictionary<int, string> domenList { set; }
        // Dictionary<int, string> geologistList { set; }
        // string lastUserID { get; set; }
        // DateTime? lastDT { get; set; }

        IView mdiParent {  set; }
        IView OwnerForm { set; }
        void Show(bool ReadOnly = false);
        void Refresh();
        void Hide();
        void Close();
        event EventHandler<EventArgs> clickOk;
        event EventHandler<EventArgs> clickCloseForm;


    }
}
