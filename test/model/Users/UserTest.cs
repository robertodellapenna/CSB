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
    public class UserTest
    {
        [TestMethod]
        public void CustomerLoginTest()
        {
            Assert.ThrowsException<ArgumentNullException>( () => new CustomerLoginUser(null, "AABBCCDD", new DateTime(2010, 11, 15)) );
        }

        [TestMethod]
        public void CustomerTest()
        {
            string nome = "Lorenzo";
            Customer clien1 = new Customer("Lorenzo", "Antonini", "pippo95", "25/07/95");
            Assert.ThrowsException<ArgumentException>(() => new Customer("", "Antonini", "pippo95", "23"));
            Assert.AreEqual(clien1.FirstName, nome);
            Assert.IsNotNull(clien1);
            Assert.ThrowsException<ArgumentException>(() => new Customer("Lorenzo", "Antonini", "pippo95", "23/13/12"));
        }
    }
}
