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
        public void TestCreateGroupWithError()
        {
            Assert.ThrowsException<ArgumentException>( () => CategoryFactory.CreateGroup("", null) );
            Assert.ThrowsException<ArgumentException>(() => CategoryFactory.CreateGroup("  ", null));
            Assert.ThrowsException<ArgumentException>(() => CategoryFactory.CreateGroup(null, null));
        }

        [TestMethod]
        public void TestCreateLeaf()
        {
            string name = "LEAF";
            ICategory c = CategoryFactory.CreateCategory(name, null);
            Assert.IsNotNull(c);
            Assert.AreEqual(name, c.Name);
            Assert.IsTrue(c is ICategory);
        }

        [TestMethod]
        public void TestCreateLeafWithError()
        {
            Assert.ThrowsException<ArgumentException>(() => CategoryFactory.CreateCategory("", null));
            Assert.ThrowsException<ArgumentException>(() => CategoryFactory.CreateCategory("   ", null));
            Assert.ThrowsException<ArgumentException>(() => CategoryFactory.CreateCategory(null, null));
        }

        [TestMethod]
        public void TestIsRoot()
        {
            string name = "ROOT";
            string name2 = "CHILD";

            IGroupCategory c = CategoryFactory.CreateGroup(name, null);
            Assert.IsNotNull(c);
            Assert.IsTrue(c.IsRoot);

            IGroupCategory c2 = CategoryFactory.CreateGroup(name2, c);
            Assert.IsNotNull(c2);
            Assert.IsFalse(c2.IsRoot);
        }

        [TestMethod]
        public void TestHasChild()
        {
            string name = "ROOT";
            string name2 = "CHILD";
            IGroupCategory c = CategoryFactory.CreateGroup(name, null);
            Assert.IsNotNull(c);
            Assert.IsFalse(c.HasChild);

            IGroupCategory c2 = CategoryFactory.CreateGroup(name2, c);
            Assert.IsNotNull(c2);
            Assert.IsTrue(c.HasChild);
            Assert.IsFalse(c2.HasChild);
        }

        [TestMethod]
        public void TestEquals()
        {
            throw new NotImplementedException("Da fare");
        }

        [TestMethod]
        public void TestParentAddChild()
        {
            string rootName = "ROOT";
            string childName = "CHILD";
            string leafName = "LEAF";

            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            Assert.IsTrue(root.Children.Length == 1);
            Assert.IsTrue(root.Children[0] == child);
            Assert.IsTrue(child.Parent == root);
            ICategory leaf = CategoryFactory.CreateCategory(leafName, null);
            leaf.Parent = child;
            Assert.IsTrue(child.Children.Length == 1);
            Assert.IsTrue(child.Children[0] == leaf);
            Assert.IsTrue(leaf.Parent == child);
            child.AddChild(leaf);
            Assert.IsTrue(child.Children.Length == 1);
            Assert.IsTrue(child.Children[0] == leaf);
            Assert.IsTrue(leaf.Parent == child);
        }

        [TestMethod]
        public void TestParentAddChildWithError()
        {
            string rootName = "ROOT";
            string childName = "CHILD";

            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            // Aggiunto figlio nullo
            
            Assert.ThrowsException<ArgumentNullException>(() => root.AddChild(null));
            
            // child è figlio di root, e root vuole diventare figlio di child
            Assert.ThrowsException<Exception>(() => child.AddChild(root));
            // padre di me stesso
            Assert.ThrowsException<Exception>(() => root.AddChild(root));
            // padre di me stesso
            Assert.ThrowsException<Exception>(() => root.Parent = root);
        }

        [TestMethod]
        public void TestParentAddChildWithErrorTree()
        {
            string rootName = "ROOT";
            string childName = "CHILD";
            string leafName = "LEAF";

            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            IGroupCategory child2 = CategoryFactory.CreateGroup(leafName, null);
            
            child2.Parent = child;
            Assert.ThrowsException<Exception>(() => child2.AddChild(root));
            Assert.ThrowsException<Exception>(() => root.Parent = child2);

        }
    }
}
