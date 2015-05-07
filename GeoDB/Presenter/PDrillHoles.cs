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
    public class BrowseCollar:AbsBrowser<COLLAR2,Collar2VmFull>
    {
        public BrowseCollar
         (
                       IBaseService<COLLAR2> modelCollar
                     , IBaseService<GEOLOGIST> modelGeologist
                     , int rowsToBuffer
         )
            : base(modelCollar, modelGeologist, rowsToBuffer) { }
        public override void CreateFilteredModel()
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

            temp = temp.FilteredBy(_filter);
            _filteredViewModel = temp.SortBy(_sorter);
            _wholeModelRowCount = _filteredViewModel.Count();
        }

    }

    public class BrowseAssay:AbsBrowser<ASSAYS2,Assays2VmFull>
    {
        public BrowseAssay
            (
                          IBaseService<ASSAYS2> modelAssays
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer
            )
            :base(modelAssays,modelGeologist,rowsToBuffer){}


        public override void CreateFilteredModel()
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

            _filteredViewModel = temp.FilteredBy(_filter).SortBy(_sorter);

            _wholeModelRowCount = _filteredViewModel.Count();
        }
        public  void OnSetRowMasterTable(object sender, NumRowEventArgs e)
        {
            _bhid_Collar_id = e.numRow;
            CreateFilteredModel();
            GeneratePage();
            base.OnSetRowMasterTable(sender, e);
        }

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
            _broCollar.sortedViewModel += new EventHandler<EventArgs>(OnCollarSortedViewModel);
            _broCollar.filteredViewModel += new EventHandler<EventArgs>(OnCollarFilteredViewModel);
            _view.clickCollarHeader += new EventHandler<NumSortedFieldEventArgs>(_broCollar.OnSetSortedField);
            _view.showAnyCollarScreen += new EventHandler<NumRowEventArgs>(_broCollar.OnShowAnyScreen);
            _view.clickCollarFilters += new EventHandler<EventArgs>(_broCollar.OnClickCollarFilters);

            _broAssays = new BrowseAssay(modelAssays, modelGeologist, rowsToBuffer);
            _broAssays.generatedNewPartOfBuffer += new EventHandler<EventArgs>(OnAssaysGeneratedNewPartOfBuffer);
            _broAssays.refreshedViewModel += new EventHandler<EventArgs>(OnAssaysRefreshedViewModel);
            _view.showAnyAssaysScreen += new EventHandler<NumRowEventArgs>(_broAssays.OnShowAnyScreen);
            _view.setCurrentRow += new EventHandler<NumRowEventArgs>(_broAssays.OnSetRowMasterTable);

            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);
        }
        private void OnCollarGeneratedNewPartOfBuffer(object sender, EventArgs e)
        {
            _view.CollarList = _broCollar.GetBuffer();
            _view.rowCollarCount = _broCollar.GetWholeModelRowCount();
        }
        private void OnCollarRefreshedViewModel(object sender,EventArgs e)
        {
            _view.RefreshCollar();
        }
        private void OnCollarSortedViewModel(object sender, EventArgs e)
        {
            _view.sortedCollarNumField = _broCollar.GetSortedNumField();
            _view.SortedCollarCriterion = _broCollar.GetSortedCriterion();
        }
        private void OnCollarFilteredViewModel(object sender, EventArgs e)
        {
            _view.CollarList= _broCollar.GetBuffer();
            _view.rowCollarCount = _broCollar.GetWholeModelRowCount();
            _view.filteredCollarNumField = _broCollar.GetFilteredCollarNumField();

        }
        private void OnAssaysGeneratedNewPartOfBuffer(object sender, EventArgs e)
        {
            _view.AssaysList = _broAssays.GetBuffer();
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

        public void Show()
        {
            _view.CollarHeader = _broCollar.GetHeader();
            _view.sortedCollarNumField = _broCollar.GetSortedNumField();
            _view.SortedCollarCriterion = _broCollar.GetSortedCriterion();
            _view.filteredCollarNumField = _broCollar.GetFilteredCollarNumField();
            _view.rowCollarCount = _broCollar.GetWholeModelRowCount();
            _view.CollarList = _broCollar.GetBuffer();
            _view.AssaysHeader = _broAssays.GetHeader();
            _view.rowAssaysCount = _broAssays.GetWholeModelRowCount();
            _view.AssaysList = _broAssays.GetBuffer();
            _view.Show();
        }
    }
}
