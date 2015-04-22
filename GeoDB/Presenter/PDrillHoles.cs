using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
//using GeoDBWinForms;
using GeoDB.View;
using GeoDB.Service.DataAccess;

namespace GeoDB.Presenter
{
    public class PDrillHoles
    {
        ModelDB db = new ModelDB();
        private COLLAR2 _model;
        private IViewCollar2 _view;
        private CollarEntityService _collar2;

        public PDrillHoles(IViewCollar2 viewCollar2)
        {
            _view = viewCollar2;
            _model = new COLLAR2();
           // _view.showData += new EventHandler<EventArgs>(OnShowData);
            _collar2 = new CollarEntityService();
            RefreshView();
        }

        public void RefreshView()
        {
           
        }
        public void Show()
        {
            _view.Show();
        }

        private void OnShowData(object sender, EventArgs e)
        {
               _view.CollarList = (from a in _collar2.Get()
                                     select new Collar2VmFull
                                    {
                                        id = a.ID,
                                        bhid = a.BHID,
                                        gorizont = a.GORIZONT.BENCH_NAME,
                                        blast = a.RL_EXPLO2.EXPL_LINE_NAME,
                                        hole = a.HOLE_ID,
                                        xcollar = a.XCOLLAR,
                                        ycollar = a.YCOLLAR,
                                        zcollar = a.ZCOLLAR,
                                        enddepth = a.ENDDEPTH,
                                        drillType = a.DRILLING_TYPE.DRILL_TYPE,
                                        lastUserID = a.LastUserID,
                                        lastDT = a.LastDT
                                    }).ToList();
            RefreshView();
        }


    }
}
