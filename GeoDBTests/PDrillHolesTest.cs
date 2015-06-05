using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GeoDB.Presenter;
using NSubstitute;
using GeoDB.Service.DataAccess;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Extensions;
using GeoDbUserInterface.View;
using GeoDbUserInterface.ServiceInterfaces;


namespace GeoDBTests
{
    [TestFixture]
    public class PDrillHolesTest
    {
        private IViewDrillHoles2 _view;
        private IViewDrillHoles2 _viewEmpty;
        private int _itemToPage;
        private IBaseService<COLLAR2> _modelCollar;
        private IBaseService<COLLAR2> _modelEmpty;
        private IBaseService<ASSAYS2> _modelAssays;
        private IBaseService<GEOLOGIST> _modelGeologist;
        private List<COLLAR2> _modelCollarRecords;
        private List<COLLAR2> _modelRecordsEmpty;
        private List<ASSAYS2> _modelAssaysRecords;

        private BrowseCollar _browseCollar;
        private BrowseAssay _browseAssays;

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
                newCollar2.BHID = "bhid" + i.ToString();
                newCollar2.HOLE_ID =  i;
                newCollar2.GORIZONT = new GORIZONT();
                newCollar2.RL_EXPLO2 = new RL_EXPLO2();
                newCollar2.DRILLING_TYPE = new DRILLING_TYPE();
                _modelCollarRecords.Add(newCollar2);
                ASSAYS2 newAssays2 = new ASSAYS2();
                newAssays2.BHID = newCollar2.ID;
                newAssays2.COLLAR2 = newCollar2;
                newAssays2.REESTR_VEDOMOSTEI = new REESTR_VEDOMOSTEI();
                newAssays2.BLOCK_ZAPASOV = new BLOCK_ZAPASOV();
                newAssays2.GEOLOGIST1 = new GEOLOGIST();
                newAssays2.JOURNAL1 = new JOURNAL();
                newAssays2.LITOLOGY = new LITOLOGY();
                newAssays2.RANG1 = new RANG();
                _modelAssaysRecords.Add(newAssays2);
                
            }

            _view = Substitute.For<IViewDrillHoles2>();
            _view.CollarList = new Dictionary<int, ICollar2VmFull>();
            _view.AssaysList = new Dictionary<int, IAssays2VmFull>();
            _viewEmpty = Substitute.For<IViewDrillHoles2>();
            _viewEmpty.CollarList = new Dictionary<int, ICollar2VmFull>();
            _viewEmpty.AssaysList = new Dictionary<int, IAssays2VmFull>();

            
            
            _modelCollar = Substitute.For<IBaseService<COLLAR2>>();
            _modelCollar.Get().Returns(_modelCollarRecords);
            _modelCollar.Count().Returns(_modelCollarRecords.Count);

            _modelAssays = Substitute.For<IBaseService<ASSAYS2>>();
            _modelAssays.Get().Returns(_modelAssaysRecords);
            _modelAssays.GetByBhid(Arg.Any<int>()).Returns(a=>_modelAssaysRecords.Where(x=>x.BHID==(int)a[0]));
            _modelAssays.Count().Returns(_modelAssaysRecords.Count);

            _modelGeologist = Substitute.For<IBaseService<GEOLOGIST>>();
            _modelGeologist.Get().Returns(new List<GEOLOGIST>());
            _modelGeologist.Count().Returns(0);

            _modelEmpty = Substitute.For<IBaseService<COLLAR2>>();
            _modelEmpty.Get().Returns(_modelRecordsEmpty);
            _modelEmpty.Count().Returns(_modelRecordsEmpty.Count);

            _browseCollar = new BrowseCollar(_modelCollar, _modelGeologist, _itemToPage);
            _browseAssays = new BrowseAssay(_modelAssays, _modelGeologist, _itemToPage);
            
        }

        [Test]
        public void GetWholeModelRowCountWithoutFiltersTest()
        {
            Assert.That(_browseCollar.GetWholeModelRowCount(), Is.EqualTo(15));
        }
        [Test]
        public void GetWholeModelRowCountWithFiltersTest()
        {
            _browseCollar.ChangeFilter(new DGVHeader { fieldName = "id", fieldHeader = "id" },
                                    new LinqExtensionFilterCriterion(2, 4) as ILinqExtensionFilterCriterion);
            _browseCollar.ChangeFilter(new DGVHeader { fieldName = "hole", fieldHeader = "hole" },
                        new LinqExtensionFilterCriterion(3, 6) as ILinqExtensionFilterCriterion);
            Assert.That(_browseCollar.GetWholeModelRowCount(), Is.EqualTo(2));
        }

        [Test]
        public void GetWholeModelRowCountWithBadFiltersTest()
        {
            _browseCollar.ChangeFilter(new DGVHeader { fieldName = "id", fieldHeader = "id" },
                                    new LinqExtensionFilterCriterion(-1) );
            Assert.DoesNotThrow(()=>_browseCollar.GetBuffer());
            Assert.That(_browseCollar.GetWholeModelRowCount(), Is.EqualTo(0));
            
        }

        [Test]
        public void GetNewBufferFirstPageTest()
        {
            IDictionary<int,ICollar2VmFull> buffer=_browseCollar.GetBuffer();
            Assert.That(buffer.Count, Is.EqualTo(5));
            Assert.That(buffer.ElementAt(0).Value.id, Is.EqualTo(0));
            Assert.That(buffer.ElementAt(4).Value.id, Is.EqualTo(4));
        }

        [Test]
        public void GetNewBufferPrevPageTest()
        {
            IDictionary<int, ICollar2VmFull> buffer = _browseCollar.GetBuffer();
            _browseCollar.OnShowAnyScreen(this, new ANumRowEventArgs(13));
            _browseCollar.OnShowAnyScreen(this, new ANumRowEventArgs(10));
            Assert.That(buffer.Count, Is.EqualTo(5));
            Assert.That(buffer.ElementAt(4).Value.id, Is.EqualTo(10));
        }

        [Test]
        public void GetNewBufferLastPageTest()
        {
            IDictionary<int, ICollar2VmFull> buffer = _browseCollar.GetBuffer();
            _browseCollar.OnShowAnyScreen(this, new ANumRowEventArgs(10));
            _browseCollar.OnShowAnyScreen(this, new ANumRowEventArgs(13));
            Assert.That(buffer.Count, Is.EqualTo(5));
            Assert.That(buffer.ElementAt(4).Value.id, Is.EqualTo(14));
        }

        [Test]
        public void GetWholeModelRowCountWithoutFiltersAssaysTest()
        {
            Assert.That(_browseAssays.GetWholeModelRowCount(), Is.EqualTo(1));
        }
        [Test]
        public void ChangeCollarCurrentRowTest()
        {
            _view.setCurrentRow += new EventHandler<ANumRowEventArgs>(_browseAssays.OnSetRowMasterTable);
            _view.setCurrentRow += Raise.Event<EventHandler<ANumRowEventArgs>>(new ANumRowEventArgs(13));
            Assert.That(_browseAssays.GetWholeModelRowCount(),Is.EqualTo(1));
            Assert.That(_browseAssays.GetBuffer().ElementAt(0).Value.bhid, Is.EqualTo(13));
        }
        [Test]
        public void TwoAssaysToOneCollarTest()
        {
            _modelAssaysRecords.ElementAt(6).BHID = 5;
            _modelAssays.Get().Returns(_modelAssaysRecords);
            _view.setCurrentRow += new EventHandler<ANumRowEventArgs>(_browseAssays.OnSetRowMasterTable);
            _view.setCurrentRow += Raise.Event<EventHandler<ANumRowEventArgs>>(new ANumRowEventArgs(5));
            Assert.That(_browseAssays.GetWholeModelRowCount(), Is.EqualTo(2));
        }

       
    }
}
