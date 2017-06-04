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
    public class StaffAndClientTest
    {
        [TestMethod]
        public void StuffTest()
        {
            string nome = "Lorenzo";
            Staff staffOk = new Staff("Lorenzo", "Antonini", "pippo95", "pluto", 1);
            Assert.AreEqual(staffOk.FirstName, nome);
            Assert.ThrowsException<ArgumentException>(() => new Staff("", "Antonini", "pippo95", "pluto", 1));
        }

        [TestMethod]
        public void ClientTest()
        {
            string nome = "Lorenzo";
            Client clien1 = new Client("Lorenzo", "Antonini", "pippo95", "pluto", "aaa", "25/07/95");
            Assert.ThrowsException<ArgumentException>(() => new Client("", "Antonini", "pippo95", "pluto", "aaa", "23"));
            Assert.AreEqual(clien1.FirstName, nome);
            Assert.IsNotNull(clien1);
            Assert.ThrowsException<ArgumentException>(() => new Client("Lorenzo", "Antonini", "pippo95", "pluto", "aaa", "23/13/12"));
        }
    }
}
