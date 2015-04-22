using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GeoDB.Presenter;
using GeoDB.View;
using NSubstitute;


namespace GeoDBTests
{
    [TestFixture]
    public class PDrillHolesTest
    {
        private PDrillHoles PDrillHoles_;
        private IViewCollar2 view_;
        [SetUp]
        void Init()
        {
            view_=Substitute.For<IViewCollar2>();
            
            PDrillHoles PDrillHoles_ = new PDrillHoles(view_);
        }

    }
}
