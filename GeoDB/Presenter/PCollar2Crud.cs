using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Transactions;
using GeoDbUserInterface.View;

namespace GeoDB.Presenter
{
    public class PCollar2Crud
    {
        private IViewCollar2Crud _view;
        private IBaseService<COLLAR2> _model;
        private IBaseService<GORIZONT> _modelGorizont;
        private IBaseService<RL_EXPLO2> _modelBlast;
        private IBaseService<DRILLING_TYPE> _modelDrillType;
        private IBaseService<DOMEN> _modelDomen;
        private enum ModeFormEnum { creating, modifying, deleting } ;
        private struct ModeFormDataStru
        {
            public ModeFormEnum _mode;
            public int? id;
        }
        ModeFormDataStru modeFormData;
        public event EventHandler<EventArgs> DataChanged;
        public PCollar2Crud(IViewCollar2Crud View
                            , IBaseService<COLLAR2> Model
                            , IBaseService<GORIZONT> ModelGorizont
                            , IBaseService<RL_EXPLO2> ModelBlast
                            , IBaseService<DRILLING_TYPE> ModelDrillType
                            , IBaseService<DOMEN> ModelDomen)
        {
            _view = View;
            _model = Model;
            _modelGorizont = ModelGorizont;
            _modelBlast = ModelBlast;
            _modelDrillType = ModelDrillType;
            _modelDomen = ModelDomen;
            _view.clickOk+=new EventHandler<EventArgs>(OnClickOk);
            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);




            
        }
        private void OnClickOk(object sender,EventArgs e)
        {

                COLLAR2 obj;
                if ( modeFormData._mode == ModeFormEnum.creating)
                {
                    obj = new COLLAR2(); 
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
                obj.XCOLLAR = _view.xcollar ?? -1;
                obj.YCOLLAR = _view.ycollar ?? -1;
                obj.ZCOLLAR = _view.zcollar ?? -1;
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
                    throw new InvalidOperationException("Что то пошло не так при сохранении./n  Что то пошло не так при сохранении.",ex.InnerException);
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
        public void Show(IView Parent, IView Owner)
        {
            _view.Tittle = "Создание объекта";
            _view.gorizontList = _modelGorizont.Get().ToDictionary(x=>x.BENCH_ID,x=>x.BENCH_NAME.ToString());
            _view.gorizontID = -1;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = -1;
            _view.blast = null;
            _view.hole = null;
            _view.xcollar = null;
            _view.ycollar = null;
            _view.zcollar = null;
            _view.enddepth = null;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = -1;
            _view.domenList = _modelDomen.Get().ToDictionary(x => x.ID, x => x.DOMEN1);
            _view.domenId = -1;
            modeFormData._mode = ModeFormEnum.creating;
            modeFormData.id = null;
            _view.mdiParent = StaticInformation.MdiParentForm;
            _view.OwnerForm = Owner;
             
            _view.Show();
        }
        public void Show(int id, IView Parent, IView Owner)
        {
            COLLAR2 obj = _model.Get(id);

            _view.Tittle = "Редактирование объекта";
            
            _view.gorizontList = _modelGorizont.Get().ToDictionary(x => x.BENCH_ID, x => x.BENCH_NAME.ToString());
            _view.gorizontID = obj.BENCH_ID;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = obj.LINE_ID;
            _view.hole = obj.HOLE_ID;
            _view.xcollar = obj.XCOLLAR;
            _view.ycollar = obj.YCOLLAR;
            _view.zcollar = obj.ZCOLLAR;
            _view.enddepth = obj.ENDDEPTH;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = obj.DRILL_TYPE;
            _view.domenList = _modelDomen.Get().ToDictionary(x => x.ID, x => x.DOMEN1);
            _view.domenId = obj.DOMEN;
            modeFormData._mode = ModeFormEnum.modifying;
            modeFormData.id = id;
            _view.mdiParent = StaticInformation.MdiParentForm;
            _view.OwnerForm = Owner;
            _view.Show();
        }
        public void ShowForDelete(int id, IView Parent, IView Owner)
        {
            COLLAR2 obj = _model.Get(id);

            _view.Tittle = "УДАЛЕНИЕ ОБЪЕКТА";

            _view.gorizontList = _modelGorizont.Get().ToDictionary(x => x.BENCH_ID, x => x.BENCH_NAME.ToString());
            _view.gorizontID = obj.BENCH_ID;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = obj.LINE_ID;
            _view.hole = obj.HOLE_ID;
            _view.xcollar = obj.XCOLLAR;
            _view.ycollar = obj.YCOLLAR;
            _view.zcollar = obj.ZCOLLAR;
            _view.enddepth = obj.ENDDEPTH;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = obj.DRILL_TYPE;
            _view.domenList = _modelDomen.Get().ToDictionary(x => x.ID, x => x.DOMEN1);
            _view.domenId = obj.DOMEN;
            modeFormData._mode = ModeFormEnum.deleting;
            modeFormData.id = id;
            _view.mdiParent = StaticInformation.MdiParentForm;
            _view.Show(true);
        }
    }
}
