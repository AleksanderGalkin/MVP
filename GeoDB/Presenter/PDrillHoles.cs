using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDBWinForms;
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
            _view.showData += new EventHandler<EventArgs>(OnShowData);
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
                                select new
                                {
                                     a.ID
                                    ,a.BHID
                                    ,a.XCOLLAR
                                    ,a.YCOLLAR
                                    ,a.ZCOLLAR
                                    ,a.GORIZONT
                                }
                                   ).ToList();
            RefreshView();
        }


    }
}
