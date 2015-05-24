using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using GeoDB.View;
using GeoDB.Presenter;
using GeoDB.Service.DataAccess.Interface;

namespace GeoDBTests
{
    public class LoginTest
    {
        private IViewLogin _view;
        private ITestDbConnection _testMsSqlConnection;
        private PLogin _preLogin;

        [SetUp]
        public void Init()
        {
            _view = Substitute.For<IViewLogin>();
            _view.userName.Returns("test");
            _view.password.Returns("1641642wW");
            _view.serverName.Returns("localhost");
            _view.dbName.Returns("bl_test");

            _testMsSqlConnection = Substitute.For<ITestDbConnection>();
            

            _preLogin = new PLogin(_view);
        }

        [Test]
        public void TrueLoginTest ()
        {
            _testMsSqlConnection.TestAndGetConString("test", "1641642wW", "localhost", "bl_test").Returns("Any string");
            _view.clickOk += Raise.Event();
            Assert.DoesNotThrow(delegate { _preLogin.GetConnectionString(); });
            Assert.That(_preLogin.GetConnectionString(), !Is.Empty);
        }

        [Test]
        public void FalseLoginTest()
        {
            _testMsSqlConnection.TestAndGetConString("test", "badPassword", "localhost", "bl_test").Returns("Any string");
            _view.clickOk += Raise.Event();
            Assert.Throws<UnauthorizedAccessException>(delegate { _preLogin.GetConnectionString(); });

        }

    }
}
