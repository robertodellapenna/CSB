using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Users;

namespace test.model.Users
{
    [TestClass]
    class StaffAndClientTest
    {
        [TestMethod]
        public void StuffTest()
        {
            string nome = "Lorenzo";
            Staff staffOk = new Staff("Lorenzo", "Antonini", "pippo95", "pluto", 1);
            Staff staffError = new Staff("", "Antonini", "pippo95", "pluto", 1);
            Assert.AreEqual(staffOk.FirstName, nome);
            Assert.ThrowsException<ArgumentException>(() => new Staff("", "Antonini", "pippo95", "pluto", 1));
        }
    }
}
