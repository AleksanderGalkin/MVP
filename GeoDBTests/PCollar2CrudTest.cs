using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using GeoDB.Model;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Presenter;
using GeoDbUserInterface.View;

namespace GeoDBTests
{
    public class PCollar2CrudTest
    {
        private PCollar2Crud Collar2Crud;
        private IViewCollar2Crud _view;
        private IBaseService<COLLAR2> _modelCollar;
        private IBaseService<GORIZONT> _modelGorizont;
        private IBaseService<RL_EXPLO2> _modelBlast;
        private IBaseService<DRILLING_TYPE> _modelDrillType;
        private IBaseService<DOMEN> _modelDomen;
        private List<COLLAR2> _modelCollarRecords;

       
        public void Init()
        {
            
            _view = Substitute.For<IViewCollar2Crud>();
            _view.gorizontID = 2;
            _view.hole = 5;
            _view.xcollar = 1.1;
            _view.ycollar = 2.2;
            _view.zcollar = 3.3;
            _view.drillType = 3;
            _view.enddepth = 10;
            _modelCollarRecords = new List<COLLAR2>();
            _modelCollar = Substitute.For<IBaseService<COLLAR2>>();
            _modelBlast = Substitute.For<IBaseService<RL_EXPLO2>>();
            _modelDrillType = Substitute.For<IBaseService<DRILLING_TYPE>>();
            _modelDomen = Substitute.For<IBaseService<DOMEN>>();
            _modelGorizont = Substitute.For<IBaseService<GORIZONT>>();
            _modelCollar.Count().ReturnsForAnyArgs(_modelCollarRecords.Count());
            _modelCollar.When(x => x.Create(Arg.Any<COLLAR2>())).Do(x => _modelCollarRecords.Add(x[0] as COLLAR2));
            Collar2Crud = new PCollar2Crud(_view, _modelCollar, _modelGorizont, _modelBlast, _modelDrillType, _modelDomen);
        }

        
        public void CreateTest()
        {
          //  _view.clickOk += new EventHandler<EventArgs>(Collar2Crud.On);
            _view.clickOk += Raise.Event<EventHandler<EventArgs>>();
            _modelCollar.Count().ReturnsForAnyArgs(_modelCollarRecords.Count());
            Assert.That(_modelCollar.Count(), Is.EqualTo(1));
        }
    }
}
