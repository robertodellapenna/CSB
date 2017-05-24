using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    class CategoryManager
    {
        private readonly Dictionary<String,ICategory> _categories;
        private static CategoryManager _instance = new CategoryManager();

        private readonly RootCategory _root;

        public static CategoryManager Instace
        {
            get
            {
                return _instance;
            }
        }

        private CategoryManager()
        {
            _categories = new Dictionary<string, ICategory>();
            // creo la radice
            _root = new RootCategory("ROOT");
            _categories.Add(_root.Name,_root);
        }

        public void Add(ICategory parent, string name)
        {
            _categories.Add(name, new SubCategory(parent, name));
        }

        public void Remove(ICategory category)
        {
            /*
            if (category is RootCategory)
                throw new ArgumentException("Non puoi rimuovere la radice");
            _categories.Remove(category);
            */
        }

        public ICategory Root
        {
            get
            {
                return _root;
            }
        }

        #region CategoryTemplate
        private abstract class CategoryTemplate : ICategory
        {
            private string _name;
            private Dictionary<string, ICategory> _children;

            public abstract ICategory Parent { get; }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public virtual void AddChildren(ICategory child)
            {
                if (child == null)
                    throw new ArgumentNullException("child null");
                if (HasChild(child.Name))
                    throw new ArgumentException("già presente");
                _children.Add(child.Name, child);
                
            }

            public ICollection<ICategory> Children()
            {
                return _children.Values;
            }

            public bool HasChild(string name)
            {
                return _children.ContainsKey(name);
            }
        }
        #endregion

        #region RootCategory Class

        private class RootCategory : CategoryTemplate
        {
            public override ICategory Parent
            {
                get
                {
                    return this;
                }
            }
        }
        #endregion

        #region SubCategory Class
        private class SubCategory : CategoryTemplate
        {
            
        }
    #endregion

    }

}
