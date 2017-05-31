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
        public void TestEqualsCategory()
        {
            string nameEq = "leaf";
            string nameNeq = "leaf2";

            ICategory c1 = CategoryFactory.CreateCategory(nameEq, null);

            Assert.AreEqual(c1,c1);
            
            ICategory c2 = CategoryFactory.CreateCategory(nameEq, null);
            Assert.AreEqual(c1, c2);
            Assert.AreEqual(c2, c1);

            ICategory c3 = CategoryFactory.CreateCategory(nameNeq, null);
            IGroupCategory root = CategoryFactory.CreateRoot("ROOT");
            ICategory c4 = CategoryFactory.CreateCategory(nameEq, root);
            // Nome diverso
            Assert.AreNotEqual(c1, c3);
            Assert.AreNotEqual(c3, c1);
            // padre diverso
            Assert.AreNotEqual(c1, c4);
            Assert.AreNotEqual(c4, c1);
            Assert.AreNotEqual(c1, root);
            Assert.AreNotEqual(root, c1);
            Assert.AreNotEqual(c3, c4);
        }
        
        [TestMethod]
        public void TestEqualsCategoryGroup()
        {
            string nameLeaf = "leaf";

            string nameGEq = "group";
            string nameGNEq = "group1";


            ICategory l1 = CategoryFactory.CreateCategory(nameLeaf, null);
            ICategory l2 = CategoryFactory.CreateCategory(nameLeaf, null);
            IGroupCategory g1 = CategoryFactory.CreateRoot(nameGEq);
            IGroupCategory gEqual = CategoryFactory.CreateRoot(nameGEq);
            IGroupCategory gNEqual = CategoryFactory.CreateRoot(nameGNEq);
            
            Assert.AreEqual(g1,g1);
            Assert.AreEqual(g1, gEqual);
            Assert.AreNotEqual(g1, gNEqual);

            //Aggiungo un figlio solo a g1
            g1.AddChild(l1);
            Assert.AreNotEqual(g1, gEqual);
            //Aggiungo un figlio anche a gEqual
            gEqual.AddChild(l2);
            Assert.AreEqual(g1, gEqual);
            //Cambio parent di g1 
            g1.Parent = gNEqual;
            Assert.AreNotEqual(g1, gEqual);
            //Cambio parent di gEqual per farlo diventare uguale a g1
            gEqual.Parent = gNEqual;
            Assert.AreEqual(g1, gEqual);
        }

        [TestMethod]
        public void TestPath()
        {
            string name = "leaf";
            string root = "root";
            string pathLeafName = "\\" + name;
            string pathRootName = "\\" + root;
            string completePath = "\\" + root + "\\" + name;
            ICategory l1 = CategoryFactory.CreateCategory(name, null);
            IGroupCategory rootC = CategoryFactory.CreateRoot(root);
            Assert.IsTrue(l1.Path.CompareTo(pathLeafName) == 0);
            Assert.IsTrue(rootC.Path.CompareTo(pathRootName) == 0);
            l1.Parent = rootC;
            Assert.IsTrue(l1.Path.CompareTo(completePath) == 0);

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
