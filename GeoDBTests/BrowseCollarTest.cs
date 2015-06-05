using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GeoDB.Presenter;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using NSubstitute;
using GeoDbUserInterface.ServiceInterfaces;

namespace GeoDBTests
{
    public class BrowseCollarTest
    {
        private BrowseCollar _broCollar;
        private IBaseService<COLLAR2> _modelCollar;
        private List<COLLAR2> _modelCollarRecords;
        private IBaseService<GEOLOGIST> _modelGeologist;

        [SetUp]
        public void Init()
        {
            _modelCollarRecords = new List<COLLAR2>();
            for (int i = 0; i < 15; i++)
            {
                COLLAR2 newCollar2 = new COLLAR2();
                newCollar2.ID = i;
                newCollar2.BHID = "bhid" + i.ToString();
                newCollar2.HOLE_ID = i;
                newCollar2.GORIZONT = new GORIZONT();
                newCollar2.RL_EXPLO2 = new RL_EXPLO2();
                newCollar2.DRILLING_TYPE = new DRILLING_TYPE();
                _modelCollarRecords.Add(newCollar2);
            }
            _modelGeologist = Substitute.For<IBaseService<GEOLOGIST>>();
            _modelGeologist.Get().Returns(new List<GEOLOGIST>());
            _modelGeologist.Count().Returns(0);

            _modelCollar = Substitute.For<IBaseService<COLLAR2>>();
            _broCollar = new BrowseCollar(_modelCollar, _modelGeologist, 5);
        }

        [Test]
        public void SortingFirstOpeningTest()
        {
            Assert.That(_broCollar.GetSortedNumField(), Is.EqualTo(10));
        }

        [Test]
        public void SortingSetCriterionsTest()
        {
            _broCollar.OnSetSortedField(this, new ANumSortedFieldEventArgs(1, SortererTypeCriterion.Descending));
            Assert.That(_broCollar.GetSortedNumField(), Is.EqualTo(1));
            _broCollar.OnSetSortedField(this, new ANumSortedFieldEventArgs(2, SortererTypeCriterion.Ascending));
            Assert.That(_broCollar.GetSortedNumField(), Is.EqualTo(2));
            Assert.That(_broCollar.GetSortedCriterion(), Is.EqualTo(SortererTypeCriterion.Ascending));
        }
    }
}
