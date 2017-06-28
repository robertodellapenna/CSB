using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Utils;

namespace test.model.Booking
{
    [TestClass]
    class CategoryBaseItemTest
    {
        //private CategoryBaseItem oPagliaVip;
        //private CategoryBaseItem oSemplice;
        //private CategoryBaseItem oTeloBluMedio;
        //private PriceDescriptor oDesc;


        public CategoryBaseItemTest()
        { 
            //IGroupCategory materiale = CategoryFactory.CreateRoot("Materiale");
            //IGroupCategory colore = CategoryFactory.CreateRoot("Colore");
            //IGroupCategory grandezza = CategoryFactory.CreateRoot("Grandezza");

            //oDesc = new PriceDescriptor("Ombrellone", "Desrizione ombrellone", 10.0);

            //oSemplice = new CategoryBaseItem(oDesc);
            //oPagliaVip = new CategoryBaseItem(oDesc);
            //oTeloBluMedio = new CategoryBaseItem(oDesc);
            
        }

        [TestMethod]
        public void TestCtor()
        {
            //CategoryBaseItem item = new CategoryBaseItem("Ombrellone", 10.0);
            //Assert.AreEqual(item.Name, "Ombrellone");
            //Assert.AreEqual(item.BaseDailyPrice, 10.0);
            //Assert.AreEqual(item.getDailyPrice(), item.BaseDailyPrice);
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
