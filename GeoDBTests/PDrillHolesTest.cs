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
        private PDrillHoles _PDrillHolesWithEmptyModel;
        private IViewCollar2 _view;
        private IViewCollar2 _viewEmpty;
        private int _itemToPage;
        private IBaseService<COLLAR2> _model;
        private IBaseService<COLLAR2> _modelEmpty;
        private List<COLLAR2> _modelRecords;
        private List<COLLAR2> _modelRecordsEmpty;

        

        [SetUp]
        public void Init()
        {
            _itemToPage = 5;

            _modelRecords = new List<COLLAR2>();
            _modelRecordsEmpty = new List<COLLAR2>();
            for (int i = 0 ; i < 15 ; i++)
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
            _viewEmpty = Substitute.For<IViewCollar2>();
            _viewEmpty.CollarList = new List<Collar2VmFull>();

            
            _model = Substitute.For<IBaseService<COLLAR2>>();
            _model.Get().Returns(_modelRecords);
            _model.Count().Returns(_modelRecords.Count);

            _modelEmpty = Substitute.For<IBaseService<COLLAR2>>();
            _modelEmpty.Get().Returns(_modelRecordsEmpty);
            _modelEmpty.Count().Returns(_modelRecordsEmpty.Count);

            _PDrillHoles = new PDrillHoles(_view, _model, _itemToPage);
            _PDrillHolesWithEmptyModel = new PDrillHoles(_viewEmpty, _modelEmpty, _itemToPage);
            
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

        [Test]
        public void ShowFourthPageTest()
        {
            _view.showNextScreen += Raise.Event();
            _view.showNextScreen += Raise.Event();
            _view.showNextScreen += Raise.Event();
            int FIRST_ITEM_BEFORE_LAST_EVENT = 8;
            int firstItem = FIRST_ITEM_BEFORE_LAST_EVENT + _itemToPage - 1;
            
            int lastItem = firstItem + _itemToPage - 1;
            if (lastItem > _model.Count())
            {
                firstItem = (_model.Count() - 1) - (_itemToPage - 1);
                lastItem = firstItem + _itemToPage - 1;
            }
            Assert.That(_view.CollarList.ElementAt(0).id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).id, Is.EqualTo(lastItem));
        }

        [Test]
        public void ShowPrevScreenAfterFourthPageTest()
        {
            _view.showNextScreen += Raise.Event();
            _view.showNextScreen += Raise.Event();
            _view.showNextScreen += Raise.Event();
            _view.showPrevScreen += Raise.Event();
            int FIRST_ITEM_BEFORE_LAST_EVENT = 10;
            int firstItem = FIRST_ITEM_BEFORE_LAST_EVENT - (_itemToPage - 1);
            int lastItem = firstItem + _itemToPage - 1;
            Assert.That(_view.CollarList.ElementAt(0).id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).id, Is.EqualTo(lastItem));
        }

        [Test]
        public void ShowFirstScreenAfterFourthPageTest()
        {
            _view.showNextScreen += Raise.Event();
            _view.showNextScreen += Raise.Event();
            _view.showNextScreen += Raise.Event();
            _view.showPrevScreen += Raise.Event();
            _view.showPrevScreen += Raise.Event();
            _view.showPrevScreen += Raise.Event();
            int FIRST_ITEM_BEFORE_LAST_EVENT = 3;
            int firstItem = FIRST_ITEM_BEFORE_LAST_EVENT - (_itemToPage - 1);
            int lastItem = firstItem + _itemToPage - 1;
            if (firstItem < 0)
            {
                firstItem = 0;
                lastItem = firstItem + _itemToPage - 1;
            }
            Assert.That(_view.CollarList.ElementAt(0).id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).id, Is.EqualTo(lastItem));
        }

        [Test]
        public void ShowFirstPageTestWithEmptyModel()
        {
            Assert.DoesNotThrow(_PDrillHolesWithEmptyModel.ShowPage);
            _PDrillHolesWithEmptyModel.ShowPage();
            Assert.That(_view.CollarList.Count, Is.EqualTo(0));
            
        }

    }
}
