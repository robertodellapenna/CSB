using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;

namespace test.model.Booking
{
    [TestClass]
    public class BathHouse_BaseItemTest
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
            BathHouse_BaseItem item = new BathHouse_BaseItem("Ombrellone", 10.0);
            IGroupCategory telo = CategoryFactory.CreateRoot("telo");
            ICategory teloColore = CategoryFactory.CreateGroup("colore", telo);
            item.AddCategory(teloColore, "giallo", 1.0);
            Assert.IsTrue(item.ContainsCategory(telo));
            Assert.IsFalse(item.ContainsStrictCategory(telo));
            Assert.IsTrue(item.ContainsStrictCategory(teloColore));
            ICategory teloMateriale = CategoryFactory.CreateGroup("materiale", telo);
            item.AddCategory(teloMateriale, "paglia", 1.5);
            item.RemoveCategory(teloColore);
        }
    }
}
