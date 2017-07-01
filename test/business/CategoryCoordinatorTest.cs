using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.business;
using CSB_Project.src.model.Category;
using System.Linq;

namespace test.business
{
    [TestClass]
    public class CategoryCoordinatorTest
    {
        [TestMethod]
        public void TestGetCategoryByName()
        {
            CategoryCoordinator coor = new CategoryCoordinator( new SimpleCoordinator() );
            IGroupCategory root = coor.RootCategory;
            IGroupCategory child = CategoryFactory.CreateGroup("child", root);
            IGroupCategory subChild = CategoryFactory.CreateGroup("subChild", child);
            ICategory subSubChild = CategoryFactory.CreateCategory("subSubChild", subChild);
            Assert.AreEqual(root, coor.getCategoryByPath("\\ROOT"));
            Assert.AreEqual(child, coor.getCategoryByPath("\\ROOT\\child"));
            Assert.AreEqual(subChild, coor.getCategoryByPath("\\ROOT\\child\\subChild"));
            Assert.AreEqual(subSubChild, coor.getCategoryByPath("\\ROOT\\child\\subChild\\subSubChild"));
        }
    }
}
