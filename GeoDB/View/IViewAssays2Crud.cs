using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Extensions;
using System.Windows.Forms;
using System.Drawing;

namespace GeoDB.View
{
    public interface IViewAssays2Crud
    {
         
         string Tittle { set; }
         int id { get; set; }
         int bhid { get; set; }
         string sample { get; set; }
         double from_ { get; set; }
         double to { get; set; }
         double length { get; set; }

         int zblock { get; set; }
         Dictionary<int, string> zblokList { set; }
         int lito { get; set; }
         Dictionary<int, string> litoList { set; }
         int rang { get; set; }
         Dictionary<int, string> rangList { set; }

         double? ves { get; set; }
         double? au { get; set; }
         double? au_cut { get; set; }
         double? as_ { get; set; }
         double? sb { get; set; }
         double? s { get; set; }
         double? ca { get; set; }
         double? fe { get; set; }
         double? ag { get; set; }
         double? c { get; set; }

         DateTime end_date { get; set; }

         int blank { get; set; }
         Dictionary<int, string> blankList { set; }

         int journal { get; set; }
         Dictionary<int, string> journalList { set; }

         int geologist { get; set; }
         Dictionary<int, string> geologistList { set; }

         int pit { get; set; }
         Dictionary<int, string> pitList { set; }

         string lastUserID { get; set; }
         DateTime? lastDT { get; set; }

        void Show(bool ReadOnly = false);
        void Refresh();
        void Close();
        event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickOk;
        event EventHandler<EventArgs> clickCloseForm;


    }
}


      