using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Windows.Forms;
using System.Transactions;
using GeoDbUserInterface.View;

namespace GeoDB.Presenter
{
    public class PAssays2Crud
    {
        private IViewAssays2Crud _view;
        private IBaseService<ASSAYS2> _model;
        private IBaseService<BLOCK_ZAPASOV> _modelZblock;
        private IBaseService<LITOLOGY> _modelLito;
        private IBaseService<RANG> _modelRang;
        private IBaseService<REESTR_VEDOMOSTEI> _modelBlank;
        private IBaseService<JOURNAL> _modelJournal;
        private IBaseService<GEOLOGIST> _modelGeologist;

        private enum ModeFormEnum { creating, modifying, deleting } ;
        private struct ModeFormDataStru
        {
            public ModeFormEnum _mode;
            public int? id;
        }
        ModeFormDataStru modeFormData;

        public event EventHandler<EventArgs> DataChanged;

        public PAssays2Crud(IViewAssays2Crud View
                            , IBaseService<ASSAYS2> Model
                            , IBaseService<BLOCK_ZAPASOV> ModelBlockZapasov
                            , IBaseService<LITOLOGY> ModelLito
                            , IBaseService<RANG> ModelRang
                            , IBaseService<REESTR_VEDOMOSTEI> ModelBlank
                            , IBaseService<JOURNAL> ModelJournal
                            , IBaseService<GEOLOGIST> ModelGeologist)
        {
            _view = View;
            _model = Model;
            _modelZblock = ModelBlockZapasov;
            _modelLito = ModelLito;
            _modelRang = ModelRang;
            _modelBlank = ModelBlank;
            _modelJournal = ModelJournal;
            _modelGeologist = ModelGeologist;
            

            _view.clickOk+=new EventHandler<EventArgs>(OnClickOk);
            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);




            
        }
        private void OnClickOk(object sender,EventArgs e)
        {

                ASSAYS2 obj;
                if ( modeFormData._mode == ModeFormEnum.creating)
                {
                    obj = new ASSAYS2();
                    obj.BHID = _view.bhid;
                }
                else if (modeFormData._mode == ModeFormEnum.modifying)
                {
                    obj = _model.Get(modeFormData.id ?? -1);
                }
                else
                {
                    obj = _model.Get(modeFormData.id ?? -1);
                }
                obj.SAMPLE = _view.sample ;
                obj.FROM = _view.from_ ?? -1;
                obj.TO = _view.to ?? -1;
                obj.LENGTH = _view.length ?? -1;
                obj.RESERVERS_BLOCK = _view.zblock;
                obj.ROCK = _view.lito ?? -1;
                obj.RANG = _view.rang ?? -1;
                obj.END_DATE = _view.end_date ;
                obj.BLANK_ID = _view.blank ?? -1;
                obj.JOURNAL = _view.journal ?? -1;
                obj.GEOLOGIST = _view.geologist ?? -1;
                obj.PIT = _view.pit ;

                obj.LastUserID = 6;
                obj.LastDT = DateTime.Now;
    
                try
                {
                    if (modeFormData._mode == ModeFormEnum.creating)
                    {
                        _model.Create(obj);
                    }
                    else if (modeFormData._mode == ModeFormEnum.modifying)
                    {
                        _model.Modify(obj);
                    }
                    else
                    {
                        _model.Delete(obj);
                    }


                }
                catch(Exception ex)
                {
                    if (modeFormData._mode != ModeFormEnum.creating)
                    {
                        _model.Refresh(obj);
                    }
                    MessageBox.Show(String.Format("Что то пошло не так при сохранении./n {0}",ex.InnerException),"Что то пошло не так при сохранении.");
                }

                var ev = DataChanged;
                if (ev != null)
                {
                    ev(this, EventArgs.Empty);
                }
            _view.Close();
        }
        private void OnClickCloseForm(object sender, EventArgs e)
        {
            _view.Hide();
        }
        private void Create()
        {
            MessageBox.Show("ok");
        }
        public void ShowCreate(int bhid, IView Parent, IView Owner)
        {
            _view.Tittle = "Создание объекта";
            _view.bhid = bhid;
            _view.sample = "";
            _view.from_ = null;
            _view.to = null;
            _view.length = null;
            _view.zblokList = _modelZblock.Get().ToDictionary(x => x.RESERVERS_BLOCK, x => x.CATEGORY);
            _view.zblock = -1;
            _view.litoList = _modelLito.Get().ToDictionary(x => x.LITO_ID, x => x.ROCK);
            _view.lito = -1;
            _view.rangList = _modelRang.Get().ToDictionary(x => x.ID, x => x.TYPE_RANG);
            _view.rang = -1;

            _view.end_date = DateTime.Now;
            _view.blankList = _modelBlank.Get().ToDictionary(x => x.ID, x => x.BLANK_ID);
            _view.blank = -1;
            _view.journalList = _modelJournal.Get().ToDictionary(x => x.JOURNAL_ID, x => x.JOURNAL_NAME);
            _view.journal = -1;
            _view.geologistList = _modelGeologist.Get().ToDictionary(x => x.GEOLOGIST_ID, x => x.GEOLOGIST_NAME);
            _view.geologist = -1;
            Dictionary<string, string> tempList= new Dictionary<string, string>();
            tempList.Add("N","N");
            tempList.Add("S","S");
            _view.pitList=tempList;
            _view.geologist = -1;
            modeFormData._mode = ModeFormEnum.creating;
            modeFormData.id = null;
            _view.mdiParent = StaticInformation.MdiParentForm;
            _view.OwnerForm = Owner;
            _view.Show();
        }
        public void ShowModify(int id, IView Parent, IView Owner)
        {
            ASSAYS2 obj = _model.Get(id);

            _view.Tittle = "Редактирование объекта";
            _view.sample = obj.SAMPLE;
            _view.from_ = obj.FROM;
            _view.to = obj.TO;
            _view.length = obj.LENGTH;
            _view.zblokList = _modelZblock.Get().ToDictionary(x => x.RESERVERS_BLOCK, x => x.CATEGORY);
            _view.zblock = obj.RESERVERS_BLOCK;
            _view.litoList = _modelLito.Get().ToDictionary(x => x.LITO_ID, x => x.ROCK);
            _view.lito = obj.ROCK;
            _view.rangList = _modelRang.Get().ToDictionary(x => x.ID, x => x.TYPE_RANG);
            _view.rang = obj.RANG;

            _view.end_date = obj.END_DATE;
            _view.blankList = _modelBlank.Get().ToDictionary(x => x.ID, x => x.BLANK_ID);
            _view.blank = obj.BLANK_ID;
            _view.journalList = _modelJournal.Get().ToDictionary(x => x.JOURNAL_ID, x => x.JOURNAL_NAME);
            _view.journal = obj.JOURNAL;
            _view.geologistList = _modelGeologist.Get().ToDictionary(x => x.GEOLOGIST_ID, x => x.GEOLOGIST_NAME);
            _view.geologist = obj.GEOLOGIST;
            Dictionary<string, string> tempList = new Dictionary<string, string>();
            tempList.Add("N", "N");
            tempList.Add("S", "S");
            _view.pitList = tempList;
            _view.pit = obj.PIT;
            modeFormData._mode = ModeFormEnum.modifying;
            modeFormData.id = id;
            _view.mdiParent = StaticInformation.MdiParentForm;
            _view.OwnerForm = Owner;
            _view.Show();
        }
        public void ShowForDelete(int id, IView Parent, IView Owner)
        {
            ASSAYS2 obj = _model.Get(id);

            _view.Tittle = "УДАЛЕНИЕ ОБЪЕКТА";
            _view.sample = obj.SAMPLE;
            _view.from_ = obj.FROM;
            _view.to = obj.TO;
            _view.length = obj.LENGTH;
            _view.zblokList = _modelZblock.Get().ToDictionary(x => x.RESERVERS_BLOCK, x => x.CATEGORY);
            _view.zblock = obj.RESERVERS_BLOCK;
            _view.litoList = _modelLito.Get().ToDictionary(x => x.LITO_ID, x => x.ROCK);
            _view.lito = obj.ROCK;
            _view.rangList = _modelRang.Get().ToDictionary(x => x.ID, x => x.TYPE_RANG);
            _view.rang = obj.RANG;
            _view.end_date = obj.END_DATE;
            _view.blankList = _modelBlank.Get().ToDictionary(x => x.ID, x => x.BLANK_ID);
            _view.blank = obj.BLANK_ID;
            _view.journalList = _modelJournal.Get().ToDictionary(x => x.JOURNAL_ID, x => x.JOURNAL_NAME);
            _view.journal = obj.JOURNAL;
            _view.geologistList = _modelGeologist.Get().ToDictionary(x => x.GEOLOGIST_ID, x => x.GEOLOGIST_NAME);
            _view.geologist = obj.GEOLOGIST;
            _view.pit = obj.PIT; modeFormData._mode = ModeFormEnum.deleting;
            modeFormData.id = id;
            _view.mdiParent = StaticInformation.MdiParentForm;
            _view.OwnerForm = Owner;
            _view.Show(true);
        }
    }
}
