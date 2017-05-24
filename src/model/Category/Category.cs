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
                    if (Parent != null)
                        Parent.RemoveChild((ICategory)this);
                    _parent = value;
                }
            }

            protected CategoryTemplate( String name, IGroupCategory parent)
            {
                if (name == null || name.Trim().Length == 0)
                    throw new ArgumentException("name null, only blank or empty");
                _name = name;
                Parent = parent;
            }

            public bool HasParent { get => Parent != null; }
        }
        #endregion

        #region GroupCateogry class
        private class GroupCategory : CategoryTemplate, IGroupCategory
        {

            private HashSet<ICategory> _children;
            /// <summary>
            /// Categoria padre, se è una radice restituisce se stessi
            /// </summary>
            public override IGroupCategory Parent { get => base.Parent; set => base.Parent = value; }

            public GroupCategory(string name) : this(name, null) { }

            public GroupCategory(string name, IGroupCategory parent) : base(name, parent){
                _children = new HashSet<ICategory>();
            }

            public ICollection<ICategory> Children => throw new NotImplementedException();

            public bool HasChild() => Children.Count == 0;

            public bool HasChild(string name)
            {
                foreach (ICategory c in Children)
                    if (c.Name == name)
                        return true;
                return false;
            } 

            public bool IsRoot() => Parent == null;

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
                if (child.HasParent)
                    throw new Exception("child ha già un padre");
                if (!_children.Contains(child))
                    throw new Exception("la collezione contiene già la categoria " + child.Name);
                _children.Add(child);
                child.Parent = this;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || ! (obj is IGroupCategory) )
                    return false;
                return Name == ((IGroupCategory)obj).Name;
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
        }
        #endregion

#endregion
    }


}
