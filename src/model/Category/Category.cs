using System;
using System.Collections.Generic;

namespace CSB_Project.src.model.Category
{
    static partial class CategoryFactory
    {
        #region Nested class

        /// <summary>
        /// Classe Template per le categorie
        /// </summary>
        #region CategoryTemplate class
        private abstract class CategoryTemplate : ICategory
        {
            private readonly string _name;

            private IGroupCategory _parent;

            public string Name { get => _name; }

            public virtual IGroupCategory Parent
            {
                get => _parent;
                set
                {
                    // Il parent che voglio impostare è uguale a quello attuale
                    if (Parent == value)
                        return;
                    // Devo impostare un nuovo parent
                    if (Parent != null)
                        // Rimuovo l'associazione che avevo precedentemente
                        Parent.RemoveChild((ICategory)this);
                    _parent = value;
                    _parent.AddChild(this);
                }
            }

            protected CategoryTemplate( String name, IGroupCategory parent)
            {
                if (name == null || name.Trim().Length == 0)
                    throw new ArgumentException("name null, only blank or empty");
                _name = name;
                Parent = parent;
            }

            public bool HasParent => Parent != null; 
        }
        #endregion

        #region GroupCateogry class
        private class GroupCategory : CategoryTemplate, IGroupCategory
        {
            /// <summary>
            /// Categorie figlie
            /// </summary>
            private HashSet<ICategory> _children;
            
            public GroupCategory(string name) : this(name, null) { }

            public GroupCategory(string name, IGroupCategory parent) : base(name, parent){
                _children = new HashSet<ICategory>();
            }

            public ICategory[] Children
            {
                get
                {
                    ICategory[] array = new ICategory[_children.Count];
                    _children.CopyTo(array);
                    return array;
                }
            }

            public bool HasChild => _children.Count > 0;

            public bool ContainsChild(string name)
            {
                foreach (ICategory c in _children)
                    if (c.Name == name)
                        return true;
                return false;
            } 

            public bool IsRoot => Parent == null;

            public void RemoveChild(ICategory child)
            {
                if (child == null)
                    throw new ArgumentNullException("child null");
                if (!_children.Contains(child))
                    throw new Exception("la collezione non contiene la categoria " + child.Name);
                _children.Remove(child);
                child.Parent = null;
            }

            public void AddChild(ICategory child)
            {
                if (child == null)
                    throw new ArgumentNullException("child null");
                if (child.HasParent && child.Parent != this)
                    throw new Exception("child ha già un padre");
                if (checkCycle(child, this))
                    throw new Exception("Stai creando un ciclo");
                if(!_children.Contains(child))
                    _children.Add(child);
                if(child.Parent == null)
                    child.Parent = this;
            }

            private bool checkCycle(ICategory newChild, IGroupCategory newParent)
            {
                if (newChild == newParent)
                    return true;
                if (newParent.Parent == null)
                    return false;
                if (newParent.Parent.Name == newChild.Name)
                    return true;
                return checkCycle(newChild, newParent.Parent);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is IGroupCategory))
                    return false;
                IGroupCategory other = obj as IGroupCategory;

                if (Name != other.Name || _children.Count != other.Children.Length)
                    return false;
                return Children.Equals(other.Children);
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

        }
        #endregion

        #region LeafCategory class
        private class LeafCategory : CategoryTemplate, ILeafCategory
        {
            public LeafCategory(string name) : this(name, null) { }

            public LeafCategory(String name, IGroupCategory parent) : base(name, parent) {
            }

            public override bool Equals(object obj)
            {
                if (obj == null || ! (obj is ILeafCategory) )
                    return false;
                return Name == (obj as ILeafCategory).Name;
            }
        }
        #endregion

#endregion
    }


}
