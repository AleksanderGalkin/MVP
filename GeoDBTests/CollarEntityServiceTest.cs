using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using GeoDB.Service.DataAccess;
using GeoDB.Model;
using System.Data.Objects;


namespace GeoDBTests
{
    [TestFixture]
    class CollarEntityServiceTest
    {
        CollarEntityService service;
        List<COLLAR2> _modelCollar;
        List<ASSAYS2> _modelAssays;

        [SetUp]
        public void Init()
        {
            ModelDB modeldb;// = Substitute.For<List<StorageImitation>>() as ModelDB;
            
            service = new CollarEntityService();
            _modelCollar = Substitute.For<List<COLLAR2>>();
            _modelAssays = Substitute.For<List<ASSAYS2>>();
            for (int i = 0; i < 15; i++)
            {
                COLLAR2 newCollar2 = new COLLAR2();
                newCollar2.ID = i;
                newCollar2.GORIZONT = new GORIZONT();
                newCollar2.RL_EXPLO2 = new RL_EXPLO2();
                newCollar2.DRILLING_TYPE = new DRILLING_TYPE();
                _modelCollar.Add(newCollar2);
                ASSAYS2 newAssays2 = new ASSAYS2();
                newAssays2.BHID = newCollar2.ID;
                newAssays2.COLLAR2 = newCollar2;
                newAssays2.REESTR_VEDOMOSTEI = new REESTR_VEDOMOSTEI();
                newAssays2.BLOCK_ZAPASOV = new BLOCK_ZAPASOV();
                newAssays2.GEOLOGIST1 = new GEOLOGIST();
                newAssays2.JOURNAL1 = new JOURNAL();
                newAssays2.LITOLOGY = new LITOLOGY();
                newAssays2.RANG1 = new RANG();
                _modelAssays.Add(newAssays2);

            }
            modeldb.COLLAR2.Returns(_modelCollar as IEnumerable<COLLAR2>);
            modeldb.ASSAYS2.Returns(_modelAssays as IEnumerable<ASSAYS2>);
        }

        [Test]
        public void GetFilteredTest()
        {

        }
    }

    public class StorageImitation
    {
        COLLAR2 COLLAR2 { get; set; }
        ASSAYS2 ASSAYS2 { get; set; }
    }
}
