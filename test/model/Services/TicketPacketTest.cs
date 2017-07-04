using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;
using System.Collections.Generic;
using CSB_Project.src.model.Utils;
using System.Linq;

namespace test.model.Services
{
    [TestClass]
    public class TicketPacketTest
    {
        [TestMethod]
        public void TestFilter()
        {
            IUsable s1 = new UsableMock("s1");
            IUsable s2 = new UsableMock("s2");
            ITrackingDevice t1 = new TrackingMock(1);
            ITrackingDevice t2 = new TrackingMock(2);
            IList<IUsage> usage = new List<IUsage>();
            IList<IUsage> okUsage = new List<IUsage>();
            IUsage u;
            u = new UsageMock(s1.Availability.StartDate, t1, s1);
            usage.Add(u);
            usage.Add(u);
            okUsage.Add(u);
            u = new UsageMock(s1.Availability.StartDate, t1, s2);
            usage.Add(u);
            u = new UsageMock(s1.Availability.EndDate, t1, s1);
            usage.Add(u);

            DatePriceDescriptor dpd = new DatePriceDescriptor("p1","p1test",s1.Availability);
            TicketPacket tp = new TicketPacket(dpd, s1, 1);
            IEnumerable<IUsage> result = tp.filter(usage);
            IEnumerable<IUsage> expected = usage.Except(okUsage);
            Assert.AreEqual(expected.Count(), result.Count());
            for(int i=0; i < result.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i));
            }
        }
    }
}
