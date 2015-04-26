using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GeoDB.Presenter;
using GeoDB.View;
using NSubstitute;
using GeoDB.Service.DataAccess;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;


namespace GeoDBTests
{
    [TestFixture]
    public class PDrillHolesTest
    {
        private PDrillHoles _PDrillHoles;
        private IViewCollar2 _view;
        private int _itemToPage;
        private IBaseService<COLLAR2> _model;
        private List<COLLAR2> _modelRecords;
        [SetUp]
        public void Init()
        {
            _itemToPage = 10;

            _modelRecords = new List<COLLAR2>();
            for (int i = 0 ; i < 50 ; i++)
            {
                COLLAR2 newCollar2 = new COLLAR2();
                newCollar2.ID = i;
                newCollar2.GORIZONT = new GORIZONT();
                newCollar2.RL_EXPLO2 = new RL_EXPLO2();
                newCollar2.DRILLING_TYPE = new DRILLING_TYPE();
                _modelRecords.Add(newCollar2);
            }

            _view=Substitute.For<IViewCollar2>();
            _view.CollarList = new List<Collar2VmFull>();
            
            _model = Substitute.For<IBaseService<COLLAR2>>();
            _model.Get().Returns(_modelRecords);
            _model.Count().Returns(_modelRecords.Count);

            _PDrillHoles = new PDrillHoles(_view, _model, _itemToPage);
            
            
        }

        [Test]
        public void ShowFirstPageTest()
        {
            _PDrillHoles.ShowPage();
            Assert.That(_view.CollarList.Count, Is.GreaterThan(0));
            Assert.That(_view.CollarList.Count, Is.LessThanOrEqualTo(_itemToPage));
            Assert.That(_view.CollarList.Take(_itemToPage).ToList().Count(),
                                Is.EqualTo(_model.Get().Take(_itemToPage).ToList().Count()));
        }

        [Test]
        public void ShowSecondPageTest()
        {
            _view.showNextScreen += Raise.Event();
            int FIRST_ITEM_BEFORE_LAST_EVENT = 0;
            int firstItem = FIRST_ITEM_BEFORE_LAST_EVENT + _itemToPage - 1;
            int lastItem = firstItem + _itemToPage - 1;
            Assert.That(_view.CollarList.ElementAt(0).id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).id, Is.EqualTo(lastItem));
        
        }

    }
}
