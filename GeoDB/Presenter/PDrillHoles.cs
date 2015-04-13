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
        private COLLAR2 _model;
        private IViewCollar2 _viewCollar2;

        public PDrillHoles(IViewCollar2 viewCollar2)
        {
            _viewCollar2 = viewCollar2;
            _model = new COLLAR2();
          //  RefreshView();
        }

        public void RefreshView()
        {

        }
        public void Show()
        {
            _viewCollar2.Show();
        }


    }
}
