using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Category;

namespace test.model.Category
{
    [TestClass]
    public class CategoryFactoryTest
    {
        
        [TestMethod]
        public void TestCreateGroup()
        {
            string name = "ROOT";
            IGroupCategory c = CategoryFactory.CreateGroup(name, null);
            Assert.IsNotNull(c);
            Assert.AreEqual(name, c.Name);
            Assert.IsTrue(c is IGroupCategory);
        }

        [TestMethod]
        public void TestCreateLeaf()
        {
            string name = "LEAF";
            ILeafCategory c = CategoryFactory.CreateLeaf(name, null);
            Assert.IsNotNull(c);
            Assert.AreEqual(name, c.Name);
            Assert.IsTrue(c is ILeafCategory);
        }

        [TestMethod]
        public void TestIsRoot()
        {
            string name = "ROOT";
            string name2 = "CHILD";

            IGroupCategory c = CategoryFactory.CreateGroup(name, null);
            Assert.IsNotNull(c);
            Assert.IsTrue(c.IsRoot());

            IGroupCategory c2 = CategoryFactory.CreateGroup(name2, c);
            Assert.IsNotNull(c2);
            Assert.IsFalse(c2.IsRoot());
        }

        [TestMethod]
        public void TestHasChild()
        {
            string name = "ROOT";
            string name2 = "CHILD";
            IGroupCategory c = CategoryFactory.CreateGroup(name, null);
            Assert.IsNotNull(c);
            Assert.IsFalse(c.HasChild());

            IGroupCategory c2 = CategoryFactory.CreateGroup(name2, c);
            Assert.IsNotNull(c2);
            Assert.IsTrue(c.HasChild());
            Assert.IsFalse(c2.HasChild());
        }
    }
}
