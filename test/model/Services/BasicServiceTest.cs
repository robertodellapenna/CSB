using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.Utils;

namespace test.model.Services
{
    [TestClass]
    public class BasicServiceTest
    {
        private BasicService s1;
        private String sName, sDescription;
        private DateTime august1510;
        private DateTime august1010;
        private double price;

        public BasicServiceTest()
        {
            sName = "Servizio Base";
            sDescription = "Descrizione del servizio base";
            august1010 = new DateTime(2010, 8, 10);
            august1510 = new DateTime(2010, 8, 15);
            price = 5.10;
            s1 = new BasicService(sName, sDescription, price, new DateRange(august1010, august1510));
        }

        [TestMethod]
        public void TestPrice()
        {
            Assert.AreEqual(price, s1.Price);
            int days = s1.Availability.Days;
            Assert.AreEqual(price * days, s1.PriceFor(days));
            Assert.AreEqual(price * days, s1.PriceFor(s1.Availability));
        }

        [TestMethod]
        public void TestCtor()
        {
            s1 = new BasicService(sName, sDescription);
            Assert.AreEqual(sName, s1.Name);
            Assert.AreEqual(sDescription, s1.Desciption);
            Assert.AreEqual(0, s1.Price);


        }

        [TestMethod]
        public void TestCtorError()
        {
            // Nome e descrizione non validi
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService("   ", sDescription));
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService(sName, "   "));
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService(null, null));
            // Data inizio > Data fine
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService(sName, sDescription, august1510, august1010));
            // Prezzo < 0
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService(sName, sDescription, -10));
            // Data inizio > Data fine
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService(sName, sDescription, august1010));
        }
    }
}
