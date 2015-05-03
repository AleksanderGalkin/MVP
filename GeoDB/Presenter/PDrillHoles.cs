using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.View;
using GeoDB.Service.DataAccess;
using GeoDB.Service.DataAccess.Interface;
using log4net;
using GeoDB.Model.Interface;
using GeoDB.Extensions;

namespace GeoDB.Presenter
{
    public class BrowseCollar
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");

        private IBaseService<COLLAR2> _model;
        private IBaseService<GEOLOGIST> _modelGeologist;
        private IEnumerable<Collar2VmFull> _filteredViewModel;
        private int _bufferRowCount;
        private int _wholeModelRowCount;
        private int _currentFirstRowInForm;
        private Dictionary<int, Collar2VmFull> _buffer;

        private DGVHeaderComparer _myDGVHeaderComparer;
        private Dictionary<DGVHeader, LinqExtensionFilterCriterion> _filter;

        public event EventHandler<EventArgs> generatedNewPartOfBuffer;
        public event EventHandler<EventArgs> refreshedViewModel;
        public BrowseCollar
            (
                          IBaseService<COLLAR2> modelCollar
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer
            )
        {
            _buffer = new Dictionary<int, Collar2VmFull>();
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
        public List<DGVHeader> GetCollarHeader()
        {
            return Collar2VmFull.header;
        }
        public Dictionary<int, Collar2VmFull> GetNewBuffer()
        {
            return _buffer;
        }
        public int GetWholeModelRowCount()
        {
            return _wholeModelRowCount;
        }

        public void AddFilter(DGVHeader Column, LinqExtensionFilterCriterion Criterion)
        {
            _filter.Add(Column,Criterion);
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
                _currentFirstRowInForm = e.numRow - (_bufferRowCount / 2);
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
        #region Private
        private void CreateFilteredModel()
        {
            var temp =
                 (from a in _model.Get()
                  join b in _modelGeologist.Get()
                  on a.LastUserID equals b.GEOLOGIST_ID
                  into louter
                  from item in louter.DefaultIfEmpty(new GEOLOGIST { GEOLOGIST_NAME = String.Empty })

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
                      lastUserID = item.GEOLOGIST_NAME,
                      lastDT = a.LastDT
                  });

            _filteredViewModel = temp.FilteredBy(_filter);

            _wholeModelRowCount = _filteredViewModel.Count();
        }

        private void GeneratePage()
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

    }

    public class BrowseAssay
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");

        private IBaseService<ASSAYS2> _model;
        private IBaseService<GEOLOGIST> _modelGeologist;
        private IEnumerable<Assays2VmFull> _filteredViewModel;
        private int _bufferRowCount;
        private int _wholeModelRowCount;
        private int _currentFirstRowInForm;
        private Dictionary<int, Assays2VmFull> _buffer;

        private DGVHeaderComparer _myDGVHeaderComparer;
        private Dictionary<DGVHeader, LinqExtensionFilterCriterion> _filter;

        public event EventHandler<EventArgs> generatedNewPartOfBuffer;
        public event EventHandler<EventArgs> refreshedViewModel;

        private int _bhid_Collar_id;

        public BrowseAssay
            (
                          IBaseService<ASSAYS2> modelAssays
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer
            )
        {
            _buffer = new Dictionary<int, Assays2VmFull>();
            _model = modelAssays;
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
            return Assays2VmFull.header;
        }
        public Dictionary<int, Assays2VmFull> GetNewBuffer()
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
            if (_currentFirstRowInForm + (_bufferRowCount - 1) > _wholeModelRowCount - 1)
            {
                _currentFirstRowInForm = (_wholeModelRowCount - 1) - (_bufferRowCount - 1);
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
                _currentFirstRowInForm = e.numRow - (_bufferRowCount / 2);
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
            CreateFilteredModel();
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

        public void OnSetRowMasterTable(object sender, NumRowEventArgs e)
        {
            _bhid_Collar_id = e.numRow;

            CreateFilteredModel();
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
        #region Private
        private void CreateFilteredModel()
        {
            var temp =
                 (from a in _model.GetByBhid(_bhid_Collar_id)
                  join b in _modelGeologist.Get()
                  on a.LastUserID equals b.GEOLOGIST_ID
                  into louter
                  from item in louter.DefaultIfEmpty(new GEOLOGIST { GEOLOGIST_NAME = String.Empty })

                  select new Assays2VmFull
                  {
                      id = a.ID,
                      bhid = a.BHID,
                      sample = a.SAMPLE,
                      from_ = a.FROM,
                      to = a.TO,
                      length = a.LENGTH,
                      zblock = a.BLOCK_ZAPASOV != null ? a.BLOCK_ZAPASOV.CATEGORY : "не определено",
                      lito = a.LITOLOGY.LITO_COD ?? "не определено",
                      rang = a.RANG1 != null ? a.RANG1.TYPE_RANG : "не определено",
                      ves = a.VES_SAMPLE,
                      au = a.Au,
                      au_cut = a.Au_cut,
                      as_ = a.As,
                      sb = a.Sb,
                      s = a.S,
                      ca = a.Ca,
                      fe = a.Fe,
                      ag = a.Ag,
                      c = a.C,
                      end_date = a.END_DATE,
                      blank = a.REESTR_VEDOMOSTEI.BLANK_ID ?? "не определено",
                      journal = a.JOURNAL1.JOURNAL_NAME ?? "не определено",
                      geologist = a.GEOLOGIST1.GEOLOGIST_NAME ?? "не определено",
                      pit = a.PIT,
                      lastUserID = item.GEOLOGIST_NAME,
                      lastDT = a.LastDT
                  });

            _filteredViewModel = temp.FilteredBy(_filter);

            _wholeModelRowCount = _filteredViewModel.Count();
        }

        private void GeneratePage()
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

    }
    public class PDrillHoles
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");
        private IViewDrillHoles2 _view;
        private BrowseCollar _broCollar;
        private BrowseAssay _broAssays;

        public PDrillHoles
            (IViewDrillHoles2 viewCollar2
                        , IBaseService<COLLAR2> modelCollar
                        , IBaseService<ASSAYS2> modelAssays
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer)
        {
            _view = viewCollar2;
            _broCollar = new BrowseCollar(modelCollar, modelGeologist, rowsToBuffer);
            _broCollar.generatedNewPartOfBuffer += new EventHandler<EventArgs>(OnCollarGeneratedNewPartOfBuffer);
            _broCollar.refreshedViewModel += new EventHandler<EventArgs>(OnCollarRefreshedViewModel);
            _view.showAnyCollarScreen += new EventHandler<NumRowEventArgs>(_broCollar.OnShowAnyScreen);
            _view.clickCollarFilters += new EventHandler<EventArgs>(_broCollar.OnClickCollarFilters);

            _broAssays = new BrowseAssay(modelAssays, modelGeologist, rowsToBuffer);
            _broAssays.generatedNewPartOfBuffer += new EventHandler<EventArgs>(OnAssaysGeneratedNewPartOfBuffer);
            _broAssays.refreshedViewModel += new EventHandler<EventArgs>(OnAssaysRefreshedViewModel);
            _view.showAnyAssaysScreen += new EventHandler<NumRowEventArgs>(_broAssays.OnShowAnyScreen);
            _view.setCurrentRow += new EventHandler<NumRowEventArgs>(_broAssays.OnSetRowMasterTable);



            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);
            _view.openForm += new EventHandler<EventArgs>(OnOpenForm);



        }
   

        #region Form properties and events

        private void OnCollarGeneratedNewPartOfBuffer(object sender, EventArgs e)
        {
            _view.CollarList = _broCollar.GetNewBuffer();
            _view.rowCollarCount = _broCollar.GetWholeModelRowCount();
        }
        private void OnCollarRefreshedViewModel(object sender,EventArgs e)
        {
            _view.RefreshCollar();

        }

        private void OnAssaysGeneratedNewPartOfBuffer(object sender, EventArgs e)
        {
            _view.AssaysList = _broAssays.GetNewBuffer();
            _view.rowAssaysCount = _broAssays.GetWholeModelRowCount();
        }
        private void OnAssaysRefreshedViewModel(object sender, EventArgs e)
        {
            _view.RefreshAssays();
        }
        
        private void OnClickCloseForm(object sender, EventArgs e)
        {
            _view.Close();
        }
        private void OnOpenForm(object sender, EventArgs e)
        {

        }



        public void Show()
        {
            _view.CollarHeader = _broCollar.GetCollarHeader();
            _view.rowCollarCount = _broCollar.GetWholeModelRowCount();
            _view.CollarList = _broCollar.GetNewBuffer();
            _view.AssaysHeader = _broAssays.GetHeader();
            _view.rowAssaysCount = _broAssays.GetWholeModelRowCount();
            _view.AssaysList = _broAssays.GetNewBuffer();
            _view.Show();
        }
        #endregion Form properties and events


    }
}
