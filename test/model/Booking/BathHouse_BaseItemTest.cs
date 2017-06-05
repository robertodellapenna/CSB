using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;

namespace test.model.Booking
{
    [TestClass]
    class BathHouse_BaseItemTest
    {
        [TestMethod]
        public void CostructorTest()
        {
            BathHouse_BaseItem item = new BathHouse_BaseItem("Ombrellone", 10.0);
            Assert.AreEqual(item.Name, "Ombrellone");
            Assert.AreEqual(item.BaseDailyPrice, 10.0);
            Assert.AreEqual(item.getDailyPrice(), item.BaseDailyPrice);
        }

        [TestMethod]
        public void CategoriesTest()
        {
            //IGroupCategory root = CategoryFactory.CreateRoot("telo");
            //ICategory category = CategoryFactory.CreateGroup("colore", root);
            //item.AddCategory(category, "giallo", 1.0);
            //Assert.IsTrue(item.ContainsCategory(root));
            //Assert.IsFalse(item.ContainsStrictCategory(root));
            //Assert.IsTrue(item.ContainsStrictCategory(category));
        }
    }
}
