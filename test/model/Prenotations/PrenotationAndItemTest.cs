using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;

namespace test.model.Prenotations
{
    [TestClass]
    public class PrenotationAndItemTest
    {
        [TestMethod]
        public void CostruttorePrenotazioneTest()
        {
            DateRange range = new DateRange(5);
            DateRange rangeP = new DateRange(4);
            List<ItemPrenotation> items = new List<ItemPrenotation>();
            Client clien1 = new Client("Lorenzo", "Antonini", "pippo95", "pluto", "aaa", "25/07/95");
            ItemPrenotation item1 = new ItemPrenotation(range);
            items.Add(item1);
            Assert.ThrowsException<ArgumentException>(() => new ItemPrenotation(null));
           // Assert.ThrowsException<ArgumentException>(() => new Prenotation(1, clien1, rangeP, items));
        }
    }
}
