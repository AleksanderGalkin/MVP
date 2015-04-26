using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.View;
using GeoDB.Service.DataAccess;
using GeoDB.Service.DataAccess.Interface;
using log4net;

namespace GeoDB.Presenter
{
    public class PDrillHoles
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");
        private IViewCollar2 _view;
        private IBaseService<COLLAR2> _model;
        private int _rowsToPage;
        private int _currentFirsItemInForm;
        private int _totalItems;

        public PDrillHoles(IViewCollar2 viewCollar2, IBaseService<COLLAR2> model, int rowsToPage)
        {
            _view = viewCollar2;
            _view.showNextScreen += new EventHandler<EventArgs>(OnShowNextScreen);
            _view.showPrevScreen += new EventHandler<EventArgs>(OnShowPrevScreen);
            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);
            _model = model;
            _rowsToPage = rowsToPage;
            _currentFirsItemInForm = 0;
            _totalItems = _model.Count();
        }

        public void ShowPage()
        {
            _view.CollarList =
                (from a in _model.Get()
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
                 }) .Skip(_currentFirsItemInForm)
                    .Take(_rowsToPage)
                    .ToList();
        }

        public void Show()
        {
            ShowPage();
            _view.Show();
        }

  
        private void OnShowNextScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsToPage);


            _currentFirsItemInForm = _currentFirsItemInForm + _rowsToPage - 1;
            if (_currentFirsItemInForm + (_rowsToPage-1) > _model.Count()-1)
            {
                _currentFirsItemInForm = (_model.Count() - 1) - (_rowsToPage - 1);
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentFirsItemInForm);
            ShowPage();
            
            
        }

        private void OnShowPrevScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsToPage);


            _currentFirsItemInForm = _currentFirsItemInForm - (_rowsToPage - 1);
            if (_currentFirsItemInForm - (_rowsToPage-1) < 0)
            {
                _currentFirsItemInForm = 0;
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentFirsItemInForm);
            ShowPage();
        }

        private void OnClickCloseForm(object sender, EventArgs e)
        {
            _view.Close();
        }

    }
}
