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
            DatePriceDescriptor desc = new DatePriceDescriptor(sName, sDescription, august1010, august1510, price);
            s1 = new BasicService(desc);
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
            DatePriceDescriptor desc = new DatePriceDescriptor(sName, sDescription, DateTime.MaxValue, price);
            s1 = new BasicService(desc);
            Assert.AreEqual(sName, s1.Name);
            Assert.AreEqual(sDescription, s1.Description);
            Assert.AreEqual(0, s1.Price);


        }

        [TestMethod]
        public void TestCtorError()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new BasicService(null));
        }
    }
}
