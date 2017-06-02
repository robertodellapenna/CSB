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
        
        /* DA ELIMINARE */
        /*
        [TestMethod]
        public void TestChildren()
        {
            string rootName = "ROOT";
            string childName = "CHILD";
            string leafName = "LEAF";

            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            Assert.AreEqual(0, root.Children.Length);

            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            Assert.AreEqual(1, root.Children.Length);

            IGroupCategory leaf = CategoryFactory.CreateGroup(leafName, child);
            Assert.AreEqual(1, root.Children.Length);
            Assert.AreEqual(1, child.Children.Length);

            child.RemoveChild(leaf);
            Assert.AreEqual(1, root.Children.Length);
            Assert.AreEqual(0, child.Children.Length);
        }
        */

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
            // l1 | l2 | g1 | gEqual | gNEqual
            Assert.AreEqual(g1,g1);
            Assert.AreEqual(g1, gEqual);
            Assert.AreNotEqual(g1, gNEqual);

            // l2 | g1 -> l1 | gEqual | gNEqual
            //g1 ha un figlio mentre gEqual no
            g1.AddChild(l1);
            Assert.AreNotEqual(g1, gEqual);
            // g1 -> l1 | gEqual -> l2| gNEqual
            //(Confrontando i nomi e i path g1 e gEqual sono due gerarchie identifiche)
            gEqual.AddChild(l2);
            Assert.AreEqual(g1, gEqual);
            // gNEqual -> g1 -> l1 | gEqual -> l2
            // g1 ha un padre mentre l2 no, non sono due gerarchi identifiche
            g1.Parent = gNEqual;
            Assert.AreNotEqual(g1, gEqual);
            // gNEqual -> g1 -> l1 | gRoot -> gEqual -> l2  
            //(Confrontando i nomi e i path sono due gerarchie identifiche)
            IGroupCategory gRoot = CategoryFactory.CreateRoot(nameGNEq);
            gEqual.Parent = gRoot;
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
        public void TestParentAddRemoveChild()
        {
            string rootName = "ROOT";
            string childName = "CHILD";
            string leafName = "LEAF";

            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            // root -> child
            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            Assert.AreEqual(1, root.Children.Length);
            Assert.AreSame(child, root.Children[0]);
            Assert.AreSame(root, child.Parent);
            
            ICategory leaf = CategoryFactory.CreateCategory(leafName, null);
            // root -> child -> leaf
            leaf.Parent = child;
            Assert.AreEqual(1, child.Children.Length);
            Assert.AreEqual(1, root.Children.Length);
            Assert.AreSame(leaf, child.Children[0]);
            Assert.AreSame(child, leaf.Parent);
            
            // root -> child    |  leaf
            leaf.Parent = null;
            Assert.AreEqual(0, child.Children.Length);
            Assert.AreEqual(1, root.Children.Length);
            // root     | child     | leaf
            root.RemoveChild(child);
            Assert.AreEqual(0, child.Children.Length);
            Assert.AreEqual(0, root.Children.Length);
        }

        [TestMethod]
        public void TestParentAddRemoveChildWithError()
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

            
            // root-> ( child, child ) !! Errore figlio uguale
            Assert.ThrowsException<Exception> ( () => root.AddChild(child) );
            Assert.AreEqual(0, child.Children.Length);
            Assert.AreEqual(1, root.Children.Length);
            Assert.AreSame(child, root.Children[0]);
            Assert.AreSame(root, child.Parent);
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

        [TestMethod]
        public void TestEvents()
        {
            string rootName = "ROOT";
            string childName = "CHILD";
            string leafName = "LEAF";
            string newLeafName = "NEW LEAF";

            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            IGroupCategory child = CategoryFactory.CreateGroup(childName, null);
            IGroupCategory leaf = CategoryFactory.CreateGroup(leafName, null);

            int rootCounter = 0, childCounter = 0, leafCounter = 0;

            root.Changed += (obj, e) => rootCounter++;
            child.Changed += (obj, e) => childCounter++;
            leaf.Changed += (obj, e) => leafCounter++;

            Assert.AreEqual(0, rootCounter);
            Assert.AreEqual(0, childCounter);
            Assert.AreEqual(0, leafCounter);

            root.AddChild(child);

            Assert.AreEqual(1, rootCounter);
            Assert.AreEqual(1, childCounter);
            Assert.AreEqual(0, leafCounter);

            child.AddChild(leaf);

            Assert.AreEqual(2, rootCounter);
            Assert.AreEqual(2, childCounter);
            Assert.AreEqual(1, leafCounter);

            child.RemoveChild(leaf);
            Assert.AreEqual(3, rootCounter);
            Assert.AreEqual(3, childCounter);
            Assert.AreEqual(2, leafCounter);


            ICategory newLeaf = CategoryFactory.CreateCategory(newLeafName, null);

            int newLeafCounter = 0;
            newLeaf.Changed += (obj, e) => newLeafCounter++;

            newLeaf.Parent = leaf;

            Assert.AreEqual(3, rootCounter);
            Assert.AreEqual(3, childCounter);
            Assert.AreEqual(3, leafCounter);
            Assert.AreEqual(1, newLeaf);

        }
    }
}
