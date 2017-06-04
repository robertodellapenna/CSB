using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Utils;

namespace test.model.Utils
{
    [TestClass]
    public class RangeDateTest
    {
        /* tra august e octover ci deve essere almeno un giorno di differenza */
        private DateTime now, august_1_2010 , october_1_2010 ;
        private int positiveDuration, negativeDuration;

        public RangeDateTest()
        {
            now = DateTime.Now;
            august_1_2010 = new DateTime(2010, 8, 1);
            october_1_2010 = new DateTime(2010, 10, 1);
            positiveDuration = 1;
            negativeDuration = -1;
        }

        [TestMethod]
        public void TestCtor()
        {
            DateRange d1, d2, d3;
            DateTime newDate;

            d1 = new DateRange(august_1_2010, october_1_2010);
            Assert.AreEqual(august_1_2010.Year, d1.StartDate.Year);
            Assert.AreEqual(august_1_2010.Month, d1.StartDate.Month);
            Assert.AreEqual(august_1_2010.Day, d1.StartDate.Day);
            Assert.AreEqual(october_1_2010.Year, d1.EndDate.Year);
            Assert.AreEqual(october_1_2010.Month, d1.EndDate.Month);
            Assert.AreEqual(october_1_2010.Day, d1.EndDate.Day);

            d2 = new DateRange(august_1_2010, positiveDuration);
            newDate = august_1_2010.AddDays(positiveDuration);
            Assert.AreEqual(august_1_2010.Year, d2.StartDate.Year);
            Assert.AreEqual(august_1_2010.Month, d2.StartDate.Month);
            Assert.AreEqual(august_1_2010.Day, d2.StartDate.Day);
            Assert.AreEqual(newDate.Year, d2.EndDate.Year);
            Assert.AreEqual(newDate.Month, d2.EndDate.Month);
            Assert.AreEqual(newDate.Day, d2.EndDate.Day);

            d3 = new DateRange(positiveDuration);
            newDate = now.AddDays(positiveDuration);
            Assert.AreEqual(now.Year, d3.StartDate.Year);
            Assert.AreEqual(now.Month, d3.StartDate.Month);
            Assert.AreEqual(now.Day, d3.StartDate.Day);
            Assert.AreEqual(newDate.Year, d3.EndDate.Year);
            Assert.AreEqual(newDate.Month, d3.EndDate.Month);
            Assert.AreEqual(newDate.Day, d3.EndDate.Day);
        }

        [TestMethod]
        public void TestCtorError()
        {
            // Per ogni test, start < end
            Assert.ThrowsException<ArgumentException>(() => new DateRange(october_1_2010, august_1_2010));
            Assert.ThrowsException<ArgumentException>(() => new DateRange(october_1_2010, negativeDuration));
            Assert.ThrowsException<ArgumentException>(() => new DateRange(negativeDuration));
        }

        [TestMethod]
        public void TestContains()
        {
            DateRange d1, dIncludedInD1, dNotIncludedInD1, d2NotIncludedInD1;
            d1 = new DateRange(august_1_2010, october_1_2010);
            Assert.IsTrue(d1.Contains(d1));
            dIncludedInD1 = new DateRange(august_1_2010, august_1_2010.AddDays(positiveDuration));
            Assert.IsTrue(d1.Contains(dIncludedInD1));
            dNotIncludedInD1 = new DateRange(october_1_2010, october_1_2010.AddDays(positiveDuration));
            Assert.IsFalse(d1.Contains(dNotIncludedInD1));
            d2NotIncludedInD1 = new DateRange(august_1_2010.AddDays(negativeDuration), august_1_2010);
            Assert.IsFalse(d1.Contains(d2NotIncludedInD1));

            DateRange containsCheckEnd = new DateRange(october_1_2010.AddDays(negativeDuration), october_1_2010);
            Assert.IsTrue(d1.Contains(containsCheckEnd));

            Assert.IsTrue(d1.Contains(august_1_2010));
            Assert.IsTrue(d1.Contains(october_1_2010));
            Assert.IsFalse(d1.Contains(august_1_2010.AddDays(negativeDuration)));
            Assert.IsFalse(d1.Contains(october_1_2010.AddDays(positiveDuration)));
        }

        [TestMethod]
        public void TestOverlapWith()
        {
            DateRange d1, dOverlapStart, dOverlapEnd, dNotOverlap;
            d1 = new DateRange(august_1_2010, october_1_2010);
            Assert.IsTrue(d1.OverlapWith(d1));
            dOverlapStart = new DateRange(august_1_2010.AddDays(negativeDuration), august_1_2010);
            Assert.IsTrue(d1.OverlapWith(dOverlapStart));
            dOverlapEnd = new DateRange(october_1_2010, october_1_2010.AddDays(positiveDuration));
            Assert.IsTrue(d1.OverlapWith(dOverlapEnd));

            dNotOverlap = new DateRange(october_1_2010.AddDays(positiveDuration), october_1_2010.AddDays(positiveDuration));
            Assert.IsFalse(d1.OverlapWith(dNotOverlap));
        }
    }
}
