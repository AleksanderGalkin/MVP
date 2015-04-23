using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GeoDB.Presenter;
using GeoDB.View;
using NSubstitute;
using GeoDB.Service.DataAccess;


namespace GeoDBTests
{
    [TestFixture]
    public class PDrillHolesTest
    {
        private PDrillHoles PDrillHoles_;
        private IViewCollar2 view_;
        private int itemToPage_;
        private CollarEntityService _collar2;
        [SetUp]
        public void Init()
        {
            itemToPage_ = 10;
            view_=Substitute.For<IViewCollar2>();
            PDrillHoles_ = new PDrillHoles(view_,itemToPage_);
        }

        [Test]
        public void ShowFirstPageTest()
        {
            PDrillHoles_.ShowPage();
            Assert.That(view_.CollarList.Count, Is.LessThanOrEqualTo(itemToPage_));
            Assert.That(view_.CollarList.Take(itemToPage_).ToList(),Is.EqualTo(_collar2.Get().Take(itemToPage_).ToList()));
        }
    }
}
