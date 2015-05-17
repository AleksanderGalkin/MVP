using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Windows.Forms;
using System.Transactions;

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
                }
                else if (modeFormData._mode == ModeFormEnum.modifying)
                {
                    obj = _model.Get(modeFormData.id ?? -1);
                }
                else
                {
                    obj = _model.Get(modeFormData.id ?? -1);
                }
                obj.BENCH_ID = _view.gorizontID ?? -1;
                obj.LINE_ID = _view.blast ?? -1;
                obj.HOLE_ID = _view.hole ?? -1;
                obj.BHID = _modelGorizont.Get(obj.BENCH_ID).BENCH_NAME.ToString().Trim() + "-" + _modelBlast.Get(obj.LINE_ID).EXPL_LINE_NAME.Trim() + "-" + obj.HOLE_ID.ToString().Trim();
                obj.XAssays = _view.xAssays ?? -1;
                obj.YAssays = _view.yAssays ?? -1;
                obj.ZAssays = _view.zAssays ?? -1;
                obj.DRILL_TYPE = _view.drillType ?? -1;
                obj.ENDDEPTH = _view.enddepth ?? -1;
                obj.DOMEN = _view.domenId ?? -1;
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

            _view.Close();
        }
        private void OnClickCloseForm(object sender, EventArgs e)
        {
            _view.Close();
        }
        private void Create()
        {
            MessageBox.Show("ok");
        }
        public void Show()
        {
            _view.Tittle = "Создание объекта";
            _view.gorizontList = _modelGorizont.Get().ToDictionary(x=>x.BENCH_ID,x=>x.BENCH_NAME.ToString());
            _view.gorizontID = -1;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = -1;
            _view.blast = null;
            _view.hole = null;
            _view.xAssays = null;
            _view.yAssays = null;
            _view.zAssays = null;
            _view.enddepth = null;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = -1;
            _view.domenList = _modelDomen.Get().ToDictionary(x => x.ID, x => x.DOMEN1);
            _view.domenId = -1;
            modeFormData._mode = ModeFormEnum.creating;
            modeFormData.id = null;
            _view.Show();
        }
        public void Show(int id)
        {
            ASSAYS2 obj = _model.Get(id);

            _view.Tittle = "Редактирование объекта";
            
            _view.gorizontList = _modelGorizont.Get().ToDictionary(x => x.BENCH_ID, x => x.BENCH_NAME.ToString());
            _view.gorizontID = obj.BENCH_ID;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = obj.LINE_ID;
            _view.hole = obj.HOLE_ID;
            _view.xAssays = obj.XAssays;
            _view.yAssays = obj.YAssays;
            _view.zAssays = obj.ZAssays;
            _view.enddepth = obj.ENDDEPTH;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = obj.DRILL_TYPE;
            _view.domenList = _modelDomen.Get().ToDictionary(x => x.ID, x => x.DOMEN1);
            _view.domenId = obj.DOMEN;
            modeFormData._mode = ModeFormEnum.modifying;
            modeFormData.id = id;
            _view.Show();
        }
        public void ShowForDelete (int id)
        {
            Assays2 obj = _model.Get(id);

            _view.Tittle = "УДАЛЕНИЕ ОБЪЕКТА";

            _view.gorizontList = _modelGorizont.Get().ToDictionary(x => x.BENCH_ID, x => x.BENCH_NAME.ToString());
            _view.gorizontID = obj.BENCH_ID;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = obj.LINE_ID;
            _view.hole = obj.HOLE_ID;
            _view.xAssays = obj.XAssays;
            _view.yAssays = obj.YAssays;
            _view.zAssays = obj.ZAssays;
            _view.enddepth = obj.ENDDEPTH;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = obj.DRILL_TYPE;
            _view.domenList = _modelDomen.Get().ToDictionary(x => x.ID, x => x.DOMEN1);
            _view.domenId = obj.DOMEN;
            modeFormData._mode = ModeFormEnum.deleting;
            modeFormData.id = id;
            _view.Show(true);
        }
    }
}
