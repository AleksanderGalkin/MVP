using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using GeoDB.Model.Interface;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Extensions;

namespace GeoDB.Presenter
{
    abstract public class AbsBrowser<T,S> 
        where T:class,IBase,new()
        where S:class,IViewModel
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");

        protected IBaseService<T> _model;
        protected IBaseService<GEOLOGIST> _modelGeologist;
        protected IEnumerable<S> _filteredViewModel;
        private int _bufferRowCount;
        protected int _wholeModelRowCount;
        private int _currentFirstRowInForm;
        private Dictionary<int, S> _buffer;

        private DGVHeaderComparer _myDGVHeaderComparer;
        protected Dictionary<DGVHeader, LinqExtensionFilterCriterion> _filter;
        protected int _bhid_Collar_id;
        public event EventHandler<EventArgs> generatedNewPartOfBuffer;
        public event EventHandler<EventArgs> refreshedViewModel;


        public AbsBrowser
            (
                          IBaseService<T> modelCollar
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer
            )
        {
            _buffer = new Dictionary<int, S>();
            _model = modelCollar;
            _bufferRowCount = rowsToBuffer;
            _currentFirstRowInForm = 0;
            _myDGVHeaderComparer = new DGVHeaderComparer();
            _filter = new Dictionary<DGVHeader, LinqExtensionFilterCriterion>(_myDGVHeaderComparer);
            _modelGeologist = modelGeologist;
            CreateFilteredModel();
            GeneratePage();
        }

#region Public
        public List<DGVHeader> GetHeader()
        {
            return typeof(S).GetProperty("header").GetValue(typeof(S),null) as List<DGVHeader>;
        }
        public Dictionary<int, S> GetNewBuffer()
        {
            return _buffer;
        }
        public int GetWholeModelRowCount()
        {
            return _wholeModelRowCount;
        }

        public void AddFilter(DGVHeader Column, LinqExtensionFilterCriterion Criterion)
        {
            _filter.Add(Column, Criterion);
            CreateFilteredModel();
        }
        public void OnShowNextScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentFirstRowInForm);

            log.DebugFormat("_rowsToPage: {0}", _bufferRowCount);


            _currentFirstRowInForm = _currentFirstRowInForm + _bufferRowCount - 1;
            if (_currentFirstRowInForm + (_bufferRowCount - 1) > _model.Count() - 1)
            {
                _currentFirstRowInForm = (_model.Count() - 1) - (_bufferRowCount - 1);
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentFirstRowInForm);
            GeneratePage();
            if (generatedNewPartOfBuffer != null)
            {
                generatedNewPartOfBuffer(this, EventArgs.Empty);
            }

        }

        public void OnShowPrevScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentFirstRowInForm);

            log.DebugFormat("_rowsToPage: {0}", _bufferRowCount);


            _currentFirstRowInForm = _currentFirstRowInForm - (_bufferRowCount - 1);
            if (_currentFirstRowInForm - (_bufferRowCount - 1) < 0)
            {
                _currentFirstRowInForm = 0;
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentFirstRowInForm);
            GeneratePage();
            if (generatedNewPartOfBuffer != null)
            {
                generatedNewPartOfBuffer(this, EventArgs.Empty);
            }
        }

        public void OnShowAnyScreen(object sender, NumRowEventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentFirstRowInForm);

            log.DebugFormat("_rowsToPage: {0}", _bufferRowCount);


            if (e.numRow == (_currentFirstRowInForm + _bufferRowCount))
            {
                _currentFirstRowInForm = e.numRow + _bufferRowCount <= _wholeModelRowCount ? e.numRow : _wholeModelRowCount - _bufferRowCount;
            }
            else if (e.numRow == _currentFirstRowInForm - 1)
            {
                _currentFirstRowInForm = e.numRow - _bufferRowCount >= 0 ? e.numRow - _bufferRowCount + 1 : 0;
            }
            else
            {
                _currentFirstRowInForm = e.numRow - (_bufferRowCount / 2) < 0 ? 0 : e.numRow - (_bufferRowCount / 2);
            }

            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentFirstRowInForm);
            GeneratePage();
            if (generatedNewPartOfBuffer != null)
            {
                generatedNewPartOfBuffer(this, EventArgs.Empty);
            }
        }

        public void OnClickCollarFilters(object sender, EventArgs e)
        {
            AddFilter(new DGVHeader { fieldHeader = "gorizont", fieldName = "gorizont" }
                                        , new LinqExtensionFilterCriterion(200, 350));

            GeneratePage();
            if (generatedNewPartOfBuffer != null)
            {
                generatedNewPartOfBuffer(this, EventArgs.Empty);
            }
            if (refreshedViewModel != null)
            {
                refreshedViewModel(this, EventArgs.Empty);
            }
        }

     

 #endregion Public

  #region Absract
  
        abstract public void CreateFilteredModel();
       // {
            //var temp =
            //     (from a in _model.Get()
            //      join b in _modelGeologist.Get()
            //      on a.LastUserID equals b.GEOLOGIST_ID
            //      into louter
            //      from item in louter.DefaultIfEmpty(new GEOLOGIST { GEOLOGIST_NAME = String.Empty })

            //      select new S
            //      {
            //          id = a.ID,
            //          bhid = a.BHID,
            //          gorizont = a.GORIZONT.BENCH_NAME,
            //          blast = a.RL_EXPLO2.EXPL_LINE_NAME,
            //          hole = a.HOLE_ID,
            //          xcollar = a.XCOLLAR,
            //          ycollar = a.YCOLLAR,
            //          zcollar = a.ZCOLLAR,
            //          enddepth = a.ENDDEPTH,
            //          drillType = a.DRILLING_TYPE.DRILL_TYPE,
            //          lastUserID = item.GEOLOGIST_NAME,
            //          lastDT = a.LastDT
            //      });

            //_filteredViewModel = temp.FilteredBy(_filter);

            //_wholeModelRowCount = _filteredViewModel.Count();
       // }
#endregion Abstract
#region protected
        protected void GeneratePage()
        {
            var bufferMod =
                    _filteredViewModel.Skip(_currentFirstRowInForm)
                   .Take(_bufferRowCount)
                   .ToList();

            int numerator = _currentFirstRowInForm;
            _buffer.Clear();
            foreach (var i in bufferMod)
            {
                _buffer.Add(numerator++, i);
            }


        }
 #endregion Private
#region Virtual
        public virtual void OnSetRowMasterTable(object sender, EventArgs e)
        {

            if (generatedNewPartOfBuffer != null)
            {
                generatedNewPartOfBuffer(this, EventArgs.Empty);
            }
            if (refreshedViewModel != null)
            {
                refreshedViewModel(this, EventArgs.Empty);
            }
        }

#endregion Virtual
    }
}
