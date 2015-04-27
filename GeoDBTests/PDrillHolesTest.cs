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
        private IBaseService<COLLAR2> _modelCollar;
        private IBaseService<COLLAR2> _modelEmpty;
        private IBaseService<ASSAYS2> _modelAssays;
        private IBaseService<GEOLOGIST> _modelGeologist;
        private List<COLLAR2> _modelCollarRecords;
        private List<COLLAR2> _modelRecordsEmpty;
        private List<ASSAYS2> _modelAssaysRecords;

        

        [SetUp]
        public void Init()
        {
            _itemToPage = 5;

            _modelCollarRecords = new List<COLLAR2>();
            _modelRecordsEmpty = new List<COLLAR2>();
            _modelAssaysRecords = new List<ASSAYS2>();

            for (int i = 0 ; i < 15 ; i++)
            {
                COLLAR2 newCollar2 = new COLLAR2();
                newCollar2.ID = i;
                newCollar2.GORIZONT = new GORIZONT();
                newCollar2.RL_EXPLO2 = new RL_EXPLO2();
                newCollar2.DRILLING_TYPE = new DRILLING_TYPE();
                _modelCollarRecords.Add(newCollar2);
                ASSAYS2 newAssays2 = new ASSAYS2();
                newAssays2.COLLAR2 = newCollar2;
                newAssays2.REESTR_VEDOMOSTEI = new REESTR_VEDOMOSTEI();
                newAssays2.BLOCK_ZAPASOV = new BLOCK_ZAPASOV();
                newAssays2.GEOLOGIST1 = new GEOLOGIST();
                newAssays2.JOURNAL1 = new JOURNAL();
                newAssays2.LITOLOGY = new LITOLOGY();
                newAssays2.RANG1 = new RANG();
                
            }

            _view=Substitute.For<IViewCollar2>();
            _view.CollarList = new Dictionary<int,Collar2VmFull>();
            _viewEmpty = Substitute.For<IViewCollar2>();
            _viewEmpty.CollarList = new Dictionary<int, Collar2VmFull>();

            _view.AssaysList = new Dictionary<int, Assays2VmFull>();
            
            _modelCollar = Substitute.For<IBaseService<COLLAR2>>();
            _modelCollar.Get().Returns(_modelCollarRecords);
            _modelCollar.Count().Returns(_modelCollarRecords.Count);

            _modelAssays = Substitute.For<IBaseService<ASSAYS2>>();
            _modelAssays.Get().Returns(_modelAssaysRecords);
            _modelAssays.Count().Returns(_modelAssaysRecords.Count);

            _modelGeologist = Substitute.For<IBaseService<GEOLOGIST>>();
            _modelGeologist.Get().Returns(new List<GEOLOGIST>());
            _modelGeologist.Count().Returns(0);

            _modelEmpty = Substitute.For<IBaseService<COLLAR2>>();
            _modelEmpty.Get().Returns(_modelRecordsEmpty);
            _modelEmpty.Count().Returns(_modelRecordsEmpty.Count);

            _PDrillHoles = new PDrillHoles(_view, _modelCollar, _modelAssays,_modelGeologist, _itemToPage);
            _PDrillHolesWithEmptyModel = new PDrillHoles(_viewEmpty, _modelEmpty, _modelAssays,_modelGeologist, _itemToPage);
            
        }

        [Test]
        public void ShowFirstPageTest()
        {
            _PDrillHoles.ShowPage();
            Assert.That(_view.CollarList.Count, Is.GreaterThan(0));
            Assert.That(_view.CollarList.Count, Is.LessThanOrEqualTo(_itemToPage));
            Assert.That(_view.CollarList.Take(_itemToPage).ToList().Count(),
                                Is.EqualTo(_modelCollar.Get().Take(_itemToPage).ToList().Count()));
        }

        [Test]
        public void ShowSecondPageTest()
        {
            _view.showNextScreen += Raise.Event();
            int FIRST_ITEM_BEFORE_LAST_EVENT = 0;
            int firstItem = FIRST_ITEM_BEFORE_LAST_EVENT + _itemToPage - 1;
            int lastItem = firstItem + _itemToPage - 1;
            Assert.That(_view.CollarList.ElementAt(0).Value.id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).Value.id, Is.EqualTo(lastItem));
        
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
            if (lastItem > _modelCollar.Count())
            {
                firstItem = (_modelCollar.Count() - 1) - (_itemToPage - 1);
                lastItem = firstItem + _itemToPage - 1;
            }
            Assert.That(_view.CollarList.ElementAt(0).Value.id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).Value.id, Is.EqualTo(lastItem));
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
            Assert.That(_view.CollarList.ElementAt(0).Value.id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).Value.id, Is.EqualTo(lastItem));
        }

        [Test]
        public void ShowFirstScreenAfterFourthPageTest()
        {
            _PDrillHoles.ShowPage();
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
            Assert.That(_view.CollarList.ElementAt(0).Value.id, Is.EqualTo(firstItem));
            Assert.That(_view.CollarList.ElementAt(_itemToPage - 1).Value.id, Is.EqualTo(lastItem));
        }

        [Test]
        public void ShowAnyPageTest_13()
        {
            _PDrillHoles.ShowPage();
            _view.showAnyScreen += Raise.Event<EventHandler<NumRowEventArgs>>(new NumRowEventArgs(13));
            
            Assert.That(_view.CollarList.ElementAt(0).Value.id, Is.EqualTo(11));
            Assert.That(_view.CollarList.ElementAt(3).Value.id, Is.EqualTo(14));
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
