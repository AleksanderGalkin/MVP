using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDBWinForms;

namespace GeoDB.Presenter
{
    public class PDrillHoles
    {
        ModelDB db = new ModelDB();
        private COLLAR2 _model;
        private IViewCollar2 _view;

        public PDrillHoles(IViewCollar2 viewCollar2)
        {
            _view = viewCollar2;
            _model = new COLLAR2();
            _view.showData += new EventHandler<EventArgs>(OnShowData);  
            RefreshView();
        }

        public void RefreshView()
        {
            Show();
        }
        public void Show()
        {
            _view.Show();
        }

        private void OnShowData(object sender, EventArgs e)
        {
            _view.CollarList = (from a in db.COLLAR2
                                   select a).ToList();
            RefreshView();
        }


    }
}
