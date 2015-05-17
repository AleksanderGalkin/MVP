using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using GeoDB.Model.Interface;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Extensions;
using GeoDB.View;


namespace GeoDB.Presenter
{
    abstract public class AbsBrowser<T,S> 
        where T:class,IBase,new()
        where S:class,IViewModel
    {

        private List<DGVHeader> _header = typeof(S).GetProperty("header").GetValue(typeof(S), null) as List<DGVHeader>;
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
        protected  LinqExtensionSorterCriterion _sorter;
        protected int _bhid_Collar_id; // foreign key for Assays
        public event EventHandler<EventArgs> generatedNewPartOfBuffer;
        public event EventHandler<EventArgs> refreshedViewModel;
        public event EventHandler<EventArgs> sortedViewModel;
        public event EventHandler<EventArgs> filteredViewModel;
        

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
            _sorter = typeof(S).GetProperty("DefaultSortedField").GetValue(typeof(S), null) as LinqExtensionSorterCriterion; 
            CreateFilteredModel();
            GeneratePage();
        }

#region Public
        public List<DGVHeader> GetHeader()
        {
            return _header;
        }
        public Dictionary<int, S> GetBuffer()
        {
            return _buffer;
        }
        public int GetWholeModelRowCount()
        {
            return _wholeModelRowCount;
        }
        public bool[] GetFilteredNumField()
        {
            List<DGVHeader> header = GetHeader();
            bool[] result = new bool[header.Count];
            LinqExtensionFilterCriterion locCriterion;
            for (int i = 0; i < header.Count; i++)
            {
                result[i] = false;
                if (_filter.TryGetValue(header[i], out locCriterion))
                {
                    if (locCriterion.GetTypeCriterion() != LinqExtensionFilterCriterion.TypeCriterion.resetArgs)
                    {
                        result[i] = true;
                    }
                }
                
            }
          return result;
        }
        public void ChangeFilter(DGVHeader Column, LinqExtensionFilterCriterion Criterion)
        {
            LinqExtensionFilterCriterion locCriterion;
            if (_filter.TryGetValue(Column, out locCriterion))
            {
                locCriterion.Set(Criterion);
            }
            else
            {
                _filter.Add(Column, Criterion);
            }
            CreateFilteredModel();
            if (filteredViewModel != null)
            {
                filteredViewModel(this, EventArgs.Empty);
            }
        }
        public void OnShowAnyScreen(object sender, NumRowEventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentFirstRowInForm);

            log.DebugFormat("_rowsToPage: {0}", _bufferRowCount);


            if (e.numRow == (_currentFirstRowInForm + _bufferRowCount))
            {
                _currentFirstRowInForm = e.numRow + _bufferRowCount <= _wholeModelRowCount ? e.numRow-1 : _wholeModelRowCount - _bufferRowCount;
                
            }
            else if (e.numRow == _currentFirstRowInForm - 1)
            {
                _currentFirstRowInForm = e.numRow - _bufferRowCount >= 0 ? e.numRow - _bufferRowCount + 1 : 0;
            }
            else
            {
                _currentFirstRowInForm = e.numRow - (_bufferRowCount / 2) < 0 ? 0 : e.numRow - (_bufferRowCount / 2);
            }
            GeneratePage();
        }

        public void OnClickFilters(object sender, FilterParamsEventArgs e)
        {
            DGVHeader headerColumn = _header[e.numField];
            ChangeFilter(headerColumn , e.criterion);
            GeneratePage();
            if (refreshedViewModel != null)
            {
                refreshedViewModel(this, EventArgs.Empty);
            }
        }

        public void OnSetSortedField(object sender, NumSortedFieldEventArgs e)
        {
            _sorter.Set(_header.ElementAt(e.numField), e.order);
            CreateFilteredModel();
            GeneratePage();
            if (sortedViewModel != null)
            {
                sortedViewModel(this, EventArgs.Empty);
            }
            if (refreshedViewModel != null)
            {
                refreshedViewModel(this, EventArgs.Empty);
            }

        }
        public int GetSortedNumField()
        {
            List<DGVHeader> header = GetHeader();
            int i = header.FindIndex(x => x.fieldName.Equals(_sorter._firstField.fieldName));
            return i;
        }
        public LinqExtensionSorterCriterion.TypeCriterion
                   GetSortedCriterion()
        {
            return _sorter._firstTypeCriterion;
        }
        public void Refresh()
        {
            CreateFilteredModel();
            GeneratePage();
            var ev = refreshedViewModel;
            if (ev != null)
            {
                ev (this, EventArgs.Empty);
            }
        }


 #endregion Public

  #region Absract
  
        abstract public void CreateFilteredModel();

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

            if (generatedNewPartOfBuffer != null)
            {
                generatedNewPartOfBuffer(this, EventArgs.Empty);
            }
        }
#endregion protected
#region Virtual
        public virtual void OnSetRowMasterTable(object sender, EventArgs e)
        {
            if (refreshedViewModel != null)
            {
                refreshedViewModel(this, EventArgs.Empty);
            }
        }

#endregion Virtual
    }
}
