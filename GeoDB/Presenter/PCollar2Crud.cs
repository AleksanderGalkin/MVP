using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using System.Windows.Forms;

namespace GeoDB.Presenter
{
    public class PCollar2Crud
    {
        private IViewCollar2Crud _view;
        private IBaseService<COLLAR2> _model;
        private IBaseService<GORIZONT> _modelGorizont;
        private IBaseService<RL_EXPLO2> _modelBlast;
        private IBaseService<DRILLING_TYPE> _modelDrillType;

        public PCollar2Crud(IViewCollar2Crud View
                            , IBaseService<COLLAR2> Model
                            , IBaseService<GORIZONT> ModelGorizont
                            , IBaseService<RL_EXPLO2> ModelBlast
                            , IBaseService<DRILLING_TYPE> ModelDrillType)
        {
            _view = View;
            _model = Model;
            _modelGorizont = ModelGorizont;
            _modelBlast = ModelBlast;
            _modelDrillType = ModelDrillType;
            _view.clickOk+=new EventHandler<EventArgs>(OnClickOk);
            _view.clickCloseForm += new EventHandler<EventArgs>(OnClickCloseForm);




            
        }
        private void OnClickOk(object sender,EventArgs e)
        {
            COLLAR2 obj = new COLLAR2();
            obj.BHID = _view.bhid;
            obj.BENCH_ID = _view.gorizontID;
            obj.LINE_ID = _view.blast;
            obj.HOLE_ID = _view.hole;
            obj.XCOLLAR = _view.xcollar;
            obj.YCOLLAR = _view.ycollar;
            obj.ZCOLLAR = _view.zcollar;
            obj.DRILL_TYPE = _view.drillType;
            obj.ENDDEPTH = _view.enddepth;

            _model.Create(obj);
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
            _view.Tittle = "Создание / Редактирование устья скважины";
            _view.gorizontList = _modelGorizont.Get().ToDictionary(x=>x.BENCH_ID,x=>x.BENCH_NAME.ToString());
            _view.gorizontID = 2;
            _view.blastList = _modelBlast.Get().ToDictionary(x => x.EX_LINE_COD, x => x.EXPL_LINE_NAME.ToString());
            _view.blast = 3;
            _view.drillTypeList = _modelDrillType.Get().ToDictionary(x => x.DRILL_ID, x => x.DRILL_TYPE.ToString());
            _view.drillType = 2;
            _view.Show();
        }
    }
}
