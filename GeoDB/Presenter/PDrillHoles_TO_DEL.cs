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
    public class PDrillHoles_TO_DEL
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");
        private IViewDrillHoles2 _view;

        private IBaseService<COLLAR2> _modelCollar;        
        private int _rowsCollarToBuffer;
        private int _totalCollarItems;
        private int _currentCollarFirsItemInForm;


        private IBaseService<ASSAYS2> _modelAssays;
        private int _rowsAssaysToBuffer;
        private int _totalAssaysItems;
        private int _currentAssaysFirsItemInForm;

        private IBaseService<GEOLOGIST> _modelGeologist;

        private Dictionary<DGVHeader, LinqExtensionFilterCriterion> _collarFilterCriterion;
        private Dictionary<DGVHeader, LinqExtensionFilterCriterion> _assaysFilterCriterion;
        private DGVHeaderComparer _myDGVHeaderComparer ;
        private int _bhid;

        public PDrillHoles_TO_DEL(IViewDrillHoles2 viewCollar2
                        , IBaseService<COLLAR2> modelCollar
                        , IBaseService<ASSAYS2> modelAssays
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer)
        {
            _view = viewCollar2;
            _view.CollarList = new Dictionary<int, Collar2VmFull>();
            _view.showNextCollarScreen += new EventHandler<EventArgs>(OnShowNextScreen);
            _view.showPrevCollarScreen += new EventHandler<EventArgs>(OnShowPrevScreen);
            _view.showAnyCollarScreen += new EventHandler<NumRowEventArgs>(OnShowAnyScreen);
            _view.setCurrentRow += new EventHandler<NumRowEventArgs>(OnSetCurrentRow);


            _modelCollar = modelCollar;
            _rowsCollarToBuffer = rowsToBuffer;
            _currentCollarFirsItemInForm = 0;
            _totalCollarItems = _modelCollar.Count();

            _view.AssaysList = new Dictionary<int, Assays2VmFull>();
            _view.showNextAssaysScreen += new EventHandler<EventArgs>(OnShowNextScreen);
            _view.showPrevAssaysScreen += new EventHandler<EventArgs>(OnShowPrevScreen);
            _view.showAnyAssaysScreen += new EventHandler<NumRowEventArgs>(OnShowAnyScreen);
        
            _modelAssays = modelAssays;
            _rowsAssaysToBuffer = 20;
            _currentAssaysFirsItemInForm = 0;
            _totalAssaysItems = _modelAssays.Count();

            _myDGVHeaderComparer = new DGVHeaderComparer();
            _assaysFilterCriterion = new Dictionary<DGVHeader, LinqExtensionFilterCriterion>(_myDGVHeaderComparer);
            _collarFilterCriterion = new Dictionary<DGVHeader, LinqExtensionFilterCriterion>(_myDGVHeaderComparer);
            _modelGeologist = modelGeologist;

            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);
            _view.openForm += new EventHandler<EventArgs>(OnOpenForm);
            _view.clickCollarFilters+= new EventHandler<EventArgs>(OnClickCollarFilters);

        }
        #region Collar properies and events
        public void SetCollarHeader()
        {
            _view.CollarHeader = Collar2VmFull.header;
        }
        public void SetCollarRowCount(int numRow)
        {
            _view.rowCollarCount = numRow;
        }
        public void ShowCollarPage()
        {
            var wholeMod =
               (from a in _modelCollar.Get()
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
                }
                );
            wholeMod=  wholeMod.FilteredBy(_collarFilterCriterion);

            SetCollarRowCount(wholeMod.Count());

            var bufferMod=
                    wholeMod.Skip(_currentCollarFirsItemInForm)
                   .Take(_rowsCollarToBuffer)
                   .ToList();
            
            int numerator=_currentCollarFirsItemInForm;
            _view.minCollarRow = numerator;
            _view.CollarList.Clear();
            foreach(var i in bufferMod)
            {

                _view.CollarList.Add(numerator++, i);
            }
            _view.maxCollarRow = numerator - 1;
            
        }

        public void Show()
        {
            SetCollarHeader();
            SetAssaysHeader();
            ShowCollarPage();
            _view.Show();
        }

  
        private void OnShowNextScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalCollarItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsCollarToBuffer);


            _currentCollarFirsItemInForm = _currentCollarFirsItemInForm + _rowsCollarToBuffer - 1;
            if (_currentCollarFirsItemInForm + (_rowsCollarToBuffer-1) > _modelCollar.Count()-1)
            {
                _currentCollarFirsItemInForm = (_modelCollar.Count() - 1) - (_rowsCollarToBuffer - 1);
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            ShowCollarPage();
            
            
        }

        private void OnShowPrevScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalCollarItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsCollarToBuffer);


            _currentCollarFirsItemInForm = _currentCollarFirsItemInForm - (_rowsCollarToBuffer - 1);
            if (_currentCollarFirsItemInForm - (_rowsCollarToBuffer-1) < 0)
            {
                _currentCollarFirsItemInForm = 0;
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            ShowCollarPage();
        }

        private void OnShowAnyScreen(object sender, NumRowEventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalCollarItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsCollarToBuffer);


            _currentCollarFirsItemInForm = e.numRow - (_rowsCollarToBuffer / 2);
            if (_currentCollarFirsItemInForm  < 0)
            {
                _currentCollarFirsItemInForm = 0;
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            ShowCollarPage();
        }



        private void OnSetCurrentRow(object sender, NumRowEventArgs e)
        {
            
            DGVHeader assaysIdField=new DGVHeader{fieldName="bhid",fieldHeader="bhid"};
            LinqExtensionFilterCriterion criterionId;
            if (_assaysFilterCriterion.TryGetValue(assaysIdField, out criterionId))
            {
                criterionId.Set(e.numRow);

            }
            else
            {
                _assaysFilterCriterion.Add(assaysIdField, new LinqExtensionFilterCriterion(e.numRow));
            }
            _bhid = e.numRow;
            ShowAssaysPage();
            _view.RefreshCollar();
        }

        #endregion Collar properies and events


        #region Assays properties and events
        public void SetAssaysHeader()
        {
            _view.AssaysHeader = Assays2VmFull.header;
        }
        public void SetAssaysRowCount(int numRow)
        {
            _view.rowAssaysCount = numRow;
        }
        public void ShowAssaysPage()
        {
            var mod =
               (from a in _modelAssays.GetByBhid(_bhid)
                join b in _modelGeologist.Get()
                on a.LastUserID equals b.GEOLOGIST_ID
                into louter
                from item in louter.DefaultIfEmpty(new GEOLOGIST { GEOLOGIST_NAME = String.Empty })

                select new Assays2VmFull
                {
                    id = a.ID,
                    bhid = a.BHID,
                    sample = a.SAMPLE,
                    from_ =a.FROM, 
                    to =a.TO,
                    length =a.LENGTH,
                    zblock = a.BLOCK_ZAPASOV!=null ? a.BLOCK_ZAPASOV.CATEGORY:"не определено",
                    lito = a.LITOLOGY.LITO_COD ?? "не определено",
                    rang = a.RANG1!=null ? a.RANG1.TYPE_RANG : "не определено",
                    ves =a.VES_SAMPLE,
                    au =a.Au,
                    au_cut =a.Au_cut,
                    as_ =a.As,
                    sb =a.Sb,
                    s =a.S,
                    ca =a.Ca,
                    fe =a.Fe,
                    ag =a.Ag,
                    c =a.C,
                    end_date =a.END_DATE,
                    blank = a.REESTR_VEDOMOSTEI.BLANK_ID ?? "не определено",
                    journal = a.JOURNAL1.JOURNAL_NAME ?? "не определено",
                    geologist = a.GEOLOGIST1.GEOLOGIST_NAME ?? "не определено",
                    pit =a.PIT,
                    lastUserID = item.GEOLOGIST_NAME,
                    lastDT = a.LastDT
                }
                )
                    .FilteredBy(_assaysFilterCriterion)
                    .Skip(_currentAssaysFirsItemInForm)
                    .Take(_rowsAssaysToBuffer)
                    .ToList();

            int numerator = _currentAssaysFirsItemInForm;
            _view.minAssaysRow = numerator;
            _view.AssaysList.Clear();
            SetAssaysRowCount(mod.Count);
            foreach (var i in mod)
            {

                _view.AssaysList.Add(numerator++, i);
            }
            _view.maxAssaysRow = numerator - 1;
            _view.RefreshAssays();
        }
                    

        private void OnShowNextAssaysScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentCollarFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalCollarItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsCollarToBuffer);


            _currentAssaysFirsItemInForm = _currentAssaysFirsItemInForm + _rowsAssaysToBuffer - 1;
            if (_currentAssaysFirsItemInForm + (_rowsAssaysToBuffer - 1) > _modelAssays.Count() - 1)
            {
                _currentAssaysFirsItemInForm = (_modelAssays.Count() - 1) - (_rowsAssaysToBuffer - 1);
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentAssaysFirsItemInForm);
            ShowAssaysPage();


        }

        private void OnShowPrevAssaysScreen(object sender, EventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentAssaysFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalAssaysItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsAssaysToBuffer);


            _currentAssaysFirsItemInForm = _currentAssaysFirsItemInForm - (_rowsAssaysToBuffer - 1);
            if (_currentAssaysFirsItemInForm - (_rowsAssaysToBuffer - 1) < 0)
            {
                _currentAssaysFirsItemInForm = 0;
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentAssaysFirsItemInForm);
            ShowAssaysPage();
        }

        private void OnShowAnyAssaysScreen(object sender, NumRowEventArgs e)
        {
            log.DebugFormat("_currentFirsItemInForm_before_calculation_new_FirstItem: {0}", _currentAssaysFirsItemInForm);
            log.DebugFormat("_totalItems: {0}", _totalAssaysItems);
            log.DebugFormat("_rowsToPage: {0}", _rowsAssaysToBuffer);


            _currentAssaysFirsItemInForm = e.numRow - (_rowsAssaysToBuffer / 2);
            if (_currentAssaysFirsItemInForm < 0)
            {
                _currentAssaysFirsItemInForm = 0;
            }
            log.DebugFormat("_currentFirsItemInForm_after_calculation_new_FirstItem: {0}", _currentAssaysFirsItemInForm);
            ShowAssaysPage();
        }

        #endregion Assays properties and events

        #region Form properties and events
        private void OnClickCloseForm(object sender, EventArgs e)
        {
            _view.Close();
        }

        private void OnOpenForm(object sender, EventArgs e)
        {

        }

        private void OnClickCollarFilters(object sender, EventArgs e)
        {
            _collarFilterCriterion.Add(new DGVHeader { fieldHeader = "gorizont", fieldName = "gorizont" }
                                        , new LinqExtensionFilterCriterion(200, 350));
            ShowCollarPage();
        }
        #endregion Form properties and events


    }
}
