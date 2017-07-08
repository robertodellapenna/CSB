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
            Staff staffOk = new Staff(1, "Lorenzo", "Antonini", 1);
            Assert.AreEqual(staffOk.FirstName, nome);
            Assert.ThrowsException<ArgumentException>(() => new Staff(1, "", "Antonini", 1));
        }

        [TestMethod]
        public void ClientTest()
        {
            string nome = "Lorenzo";
            Client clien1 = new Client(1, "Lorenzo", "Antonini", "pippo95", "25/07/95");
            Assert.ThrowsException<ArgumentException>(() => new Client(1, "", "Antonini", "pippo95", "23"));
            Assert.AreEqual(clien1.FirstName, nome);
            Assert.IsNotNull(clien1);
            Assert.ThrowsException<ArgumentException>(() => new Client(1, "Lorenzo", "Antonini", "pippo95", "23/13/12"));
        }
    }
}
