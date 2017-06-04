using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSB_Project.src.model.Category;

namespace test.model.Category
{
    [TestClass]
    public class CategoryFactoryTest
    {
        private string rootName, childName, leafName, newLeafName;

        public CategoryFactoryTest()
        {
            rootName = "ROOT";
            childName = "CHILD";
            leafName = "LEAF";
            newLeafName = "NEW_LEAF";
        }

        [TestMethod]
        public void TestCreateGroup()
        {
            IGroupCategory c = CategoryFactory.CreateGroup(rootName, null);
            Assert.IsNotNull(c);
            Assert.AreEqual(rootName, c.Name);
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
            ICategory c = CategoryFactory.CreateCategory(leafName, null);
            Assert.IsNotNull(c);
            Assert.AreEqual(leafName, c.Name);
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
            IGroupCategory c = CategoryFactory.CreateGroup(rootName, null);
            Assert.IsNotNull(c);
            Assert.IsTrue(c.IsRoot);

            IGroupCategory c2 = CategoryFactory.CreateGroup(childName, c);
            Assert.IsNotNull(c2);
            Assert.IsFalse(c2.IsRoot);
        }

        [TestMethod]
        public void TestHasChild()
        {
            IGroupCategory c = CategoryFactory.CreateGroup(rootName, null);
            Assert.IsNotNull(c);
            Assert.IsFalse(c.HasChild);

            IGroupCategory c2 = CategoryFactory.CreateGroup(childName, c);
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
            string nameGEq = "group";
            string nameGNEq = "group1";

            ICategory l1 = CategoryFactory.CreateCategory(leafName, null);
            ICategory l2 = CategoryFactory.CreateCategory(leafName, null);
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
            string pathLeafName = "\\" + leafName;
            string pathRootName = "\\" + rootName;
            string completePath = "\\" + rootName + "\\" + leafName;
            ICategory l1 = CategoryFactory.CreateCategory(leafName, null);
            IGroupCategory rootC = CategoryFactory.CreateRoot(rootName);
            Assert.IsTrue(l1.Path.CompareTo(pathLeafName) == 0);
            Assert.IsTrue(rootC.Path.CompareTo(pathRootName) == 0);
            l1.Parent = rootC;
            Assert.IsTrue(l1.Path.CompareTo(completePath) == 0);

        }


        [TestMethod]
        public void TestParentAddRemoveChild()
        {
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
            Assert.AreEqual(1, newLeafCounter);

        }

        [TestMethod]
        public void TestIsInside()
        {
            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            ICategory leaf = CategoryFactory.CreateCategory(leafName, child);
            ICategory newLeaf = CategoryFactory.CreateCategory(newLeafName, root);

            Assert.IsTrue(leaf.IsInside(child));
            Assert.IsTrue(leaf.IsInside(root));
            Assert.IsTrue(child.IsInside(root));
            Assert.IsTrue(newLeaf.IsInside(root));
            Assert.IsFalse(newLeaf.IsInside(child));
            Assert.IsFalse(root.IsInside(root));
            Assert.IsFalse(child.IsInside(null));
        }

        [TestMethod]
        public void TestContains()
        {
            // root -> ( child -> leaf, newLeaf )
            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            IGroupCategory child = CategoryFactory.CreateGroup(childName, root);
            ICategory leaf = CategoryFactory.CreateCategory(leafName, child);
            ICategory newLeaf = CategoryFactory.CreateCategory(newLeafName, root);

            /* Contains by name */
            Assert.IsTrue(root.ContainsChild(newLeaf));
            Assert.IsTrue(root.ContainsChild(childName));
            Assert.IsFalse(root.ContainsChild(leafName));
            Assert.IsTrue(root.ContainsChild(leafName, deep: true));
            Assert.IsTrue(child.ContainsChild(leafName, deep: true));
            Assert.IsTrue(child.ContainsChild(leafName, deep: false));
            Assert.IsFalse(child.ContainsChild(newLeafName, deep: true));
            Assert.IsFalse(child.ContainsChild(newLeafName, deep: false));
            /* Contains by obj */
            Assert.IsTrue(root.ContainsChild(child));
            Assert.IsTrue(root.ContainsChild(newLeaf));
            Assert.IsTrue(root.ContainsChild(leaf, deep: true));
            Assert.IsFalse(root.ContainsChild(leaf));
            Assert.IsTrue(child.ContainsChild(leaf));
            Assert.IsFalse(child.ContainsChild(newLeaf));
            Assert.IsFalse(child.ContainsChild(newLeaf, deep: true));
            Assert.IsFalse(root.ContainsChild(root));
        }

        [TestMethod]
        public void TestContainsWithError()
        {
            IGroupCategory root = CategoryFactory.CreateGroup(rootName, null);
            Assert.ThrowsException<ArgumentException>(() => root.ContainsChild(""));
            Assert.ThrowsException<ArgumentException>(() => root.ContainsChild("  "));
            Assert.ThrowsException<ArgumentException>(() => root.ContainsChild((string) null));
            Assert.ThrowsException<ArgumentNullException>(() => root.ContainsChild((ICategory)null));
        }
    }
}
