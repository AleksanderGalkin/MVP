﻿using System;
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
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;
using GeoDB.Service.Security;

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
                 (from a in _model .Get()
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
                      lito = a.LITOLOGY.ROCK ?? "не определено",
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
            _bhid_Collar_id = e.numRow  ;
            CreateFilteredModel();
            GeneratePage();
            base.OnSetRowMasterTable(sender, e);
        }

    }

    [AnyRolePermissionAttribute(SecurityAction.Demand, Roles = "GDB_BL_ADM,GDB_BL_GEO_ADV")]

    public class PDrillHoles
    {
        public static ILog log = LogManager.GetLogger("ConsoleAppender");
        private IViewDrillHoles2 _view;
        private BrowseCollar _broCollar;
        private BrowseAssay _broAssays;
        private PCollar2Crud _preCollar2Crud;
        private PAssays2Crud _preAssays2Crud;
        private Form mdiParent;

        public PDrillHoles
            (           IViewDrillHoles2 viewCollar2
                        , IBaseService<COLLAR2> modelCollar
                        , IBaseService<ASSAYS2> modelAssays
                        , IBaseService<GEOLOGIST> modelGeologist
                        , int rowsToBuffer
                        , PCollar2Crud PresenterCollar2Crud
                        , PAssays2Crud PresenterAssays2Crud
            )
        {
            _view = viewCollar2;
            _preCollar2Crud = PresenterCollar2Crud;
            _preAssays2Crud = PresenterAssays2Crud;

            _broCollar = new BrowseCollar(modelCollar, modelGeologist, rowsToBuffer);
            _broCollar.generatedNewPartOfBuffer += new EventHandler<EventArgs>(OnCollarGeneratedNewPartOfBuffer);
            _broCollar.refreshedViewModel += new EventHandler<EventArgs>(OnCollarRefreshedViewModel);
            _broCollar.sortedViewModel += new EventHandler<EventArgs>(OnCollarSortedViewModel);
            _broCollar.filteredViewModel += new EventHandler<EventArgs>(OnCollarFilteredViewModel);
            _view.clickCollarHeader += new EventHandler<NumSortedFieldEventArgs>(_broCollar.OnSetSortedField);
            _view.showAnyCollarScreen += new EventHandler<NumRowEventArgs>(_broCollar.OnShowAnyScreen);
            _view.settedCollarFilter += new EventHandler<FilterParamsEventArgs>(_broCollar.OnClickFilters);
            _view.clickCollarCreateData += new EventHandler<EventArgs>(OnClickCollarCreateData);
            _view.clickCollarEditData += new EventHandler<NumRowEventArgs>(OnClickCollarEditData);
            _view.clickCollarDeleteData += new EventHandler<NumRowEventArgs>(OnClickCollarDeleteData);

            _broAssays = new BrowseAssay(modelAssays, modelGeologist, rowsToBuffer);
            _broAssays.generatedNewPartOfBuffer += new EventHandler<EventArgs>(OnAssaysGeneratedNewPartOfBuffer);
            _broAssays.refreshedViewModel += new EventHandler<EventArgs>(OnAssaysRefreshedViewModel);
            _broAssays.sortedViewModel += new EventHandler<EventArgs>(OnAssaysSortedViewModel);
            _broAssays.filteredViewModel += new EventHandler<EventArgs>(OnAssaysFilteredViewModel);
            _view.clickAssaysHeader += new EventHandler<NumSortedFieldEventArgs>(_broAssays.OnSetSortedField);
            _view.showAnyAssaysScreen += new EventHandler<NumRowEventArgs>(_broAssays.OnShowAnyScreen);
            _view.settedAssaysFilter += new EventHandler<FilterParamsEventArgs>(_broAssays.OnClickFilters);
            _view.setCurrentRow += new EventHandler<NumRowEventArgs>(_broAssays.OnSetRowMasterTable);
            _view.clickAssaysCreateData += new EventHandler<EventArgs>(OnClickAssaysCreateData);
            _view.clickAssaysEditData += new EventHandler<NumRowEventArgs>(OnClickAssaysEditData);
            _view.clickAssaysDeleteData += new EventHandler<NumRowEventArgs>(OnClickAssaysDeleteData);

            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);

            _preCollar2Crud.DataChanged += new EventHandler<EventArgs>(OnPreCollar2Crud_DataChanged);
            _preAssays2Crud.DataChanged += new EventHandler<EventArgs>(OnPreAssays2Crud_DataChanged);
            
        }
        private void OnPreCollar2Crud_DataChanged(object sender, EventArgs e)
        {
            _broCollar.Refresh();
        }
        private void OnPreAssays2Crud_DataChanged(object sender, EventArgs e)
        {
            _broAssays.Refresh();
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
            _view.filteredCollarNumField = _broCollar.GetFilteredNumField();

        }

        private void OnClickCollarCreateData(object sender, EventArgs e)
        {
            _preCollar2Crud.Show(mdiParent, _view as Form);
            _view.Enabled = false;
            _broCollar.Refresh();
        }

        private void OnClickCollarEditData(object sender, NumRowEventArgs e)
        {
            _preCollar2Crud.Show(e.numRow, mdiParent, _view as Form);
            _broCollar.Refresh();
        }

        private void OnClickCollarDeleteData(object sender, NumRowEventArgs e)
        {
            _preCollar2Crud.ShowForDelete(e.numRow, mdiParent, _view as Form);
            _broCollar.Refresh();
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
        private void OnAssaysSortedViewModel(object sender, EventArgs e)
        {
            _view.sortedAssaysNumField = _broAssays.GetSortedNumField();
            _view.SortedAssaysCriterion = _broAssays.GetSortedCriterion();
        }
        private void OnAssaysFilteredViewModel(object sender, EventArgs e)
        {
            _view.AssaysList = _broAssays.GetBuffer();
            _view.rowAssaysCount = _broAssays.GetWholeModelRowCount();
            _view.filteredAssaysNumField = _broAssays.GetFilteredNumField();

        }
        private void OnClickAssaysCreateData(object sender, EventArgs e)
        {
            _preAssays2Crud.ShowCreate(_broAssays.GetForeignKey(),mdiParent,_view as Form);
            _broAssays.Refresh();
        }

        private void OnClickAssaysEditData(object sender, NumRowEventArgs e)
        {
            _preAssays2Crud.ShowModify(e.numRow, mdiParent, _view as Form);
            _broAssays.Refresh();
        }

        private void OnClickAssaysDeleteData(object sender, NumRowEventArgs e)
        {
            _preAssays2Crud.ShowForDelete(e.numRow, mdiParent, _view as Form);
            _broAssays.Refresh();
        }
        private void OnClickCloseForm(object sender, EventArgs e)
        {
            _view.Hide();
        }


        public void Show(Form f)
        {
            _view.CollarHeader = _broCollar.GetHeader();
            _view.sortedCollarNumField = _broCollar.GetSortedNumField();
            _view.SortedCollarCriterion = _broCollar.GetSortedCriterion();
            _view.filteredCollarNumField = _broCollar.GetFilteredNumField();
            _view.rowCollarCount = _broCollar.GetWholeModelRowCount();
            _view.CollarList = _broCollar.GetBuffer();

            _view.AssaysHeader = _broAssays.GetHeader();
            _view.sortedAssaysNumField = _broAssays.GetSortedNumField();
            _view.SortedAssaysCriterion = _broAssays.GetSortedCriterion();
            _view.filteredAssaysNumField = _broAssays.GetFilteredNumField();
            _view.rowAssaysCount = _broAssays.GetWholeModelRowCount();
            _view.AssaysList = _broAssays.GetBuffer();
            _view.mdiParent = f;
            this.mdiParent = f;
            _view.Show();
        }
    }
}
