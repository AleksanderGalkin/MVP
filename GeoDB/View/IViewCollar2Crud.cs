using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Extensions;
using System.Windows.Forms;

namespace GeoDB.View
{
    public interface IViewCollar2Crud
    {
         string Tittle { set; }
         int id { get; set; }
         string bhid { get; set; }
         Dictionary<int, string> gorizontList { set; }
         int gorizontID { get; set; }
         Dictionary<int, string> blastList { set; }
         int blast { get; set; }
         int hole { get; set; }
         double xcollar { get; set; }
         double ycollar { get; set; }
         double zcollar { get; set; }
         double enddepth { get; set; }
         Dictionary<int, string> drillTypeList { set; }
         int drillType { get; set; }
        // Dictionary<int, string> geologistList { set; }
        // string lastUserID { get; set; }
        // DateTime? lastDT { get; set; }

        void Show();
        void Refresh();
        void Close();
        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickOk;
        event EventHandler<EventArgs> clickCloseForm;


    }
}
