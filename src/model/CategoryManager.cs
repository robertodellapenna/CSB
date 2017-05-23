using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    class CategoryManager
    {
        private readonly ISet<ICategory> _categories;

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
            _categories = new HashSet<ICategory>();
            // creo la radice
            _root = new RootCategory("ROOT");
            _categories.Add(_root);
        }

        public void Add(ICategory parent, string name)
        {
            _categories.Add(new SubCategory(parent, name));
        }

        public void Remove(ICategory category)
        {
            if (category is RootCategory)
                throw new ArgumentException("Non puoi rimuovere la radice");
            _categories.Remove(category);
        }

        public ICategory Root
        {
            get
            {
                return _root;
            }
        }

        #region RootCategory Class
        private class RootCategory : ICategory
        {
            private string _name;

            public RootCategory(string name)
            {
                if (name == null || name.Trim().Length == 0)
                    throw new ArgumentException("name is empty");
                _name = name;
            }

            public ICategory Parent
            {
                get
                {
                    return this;
                }
            }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

        }
        #endregion
        #region SubCategory Class
        private class SubCategory : ICategory
        {
            private ICategory _parent;
            private string _name;

            public ICategory Parent => throw new NotImplementedException();

            public string Name => throw new NotImplementedException();

            public SubCategory(ICategory parent, string name)
            {
                _parent = parent ?? throw new ArgumentNullException("parent null");
                if (name == null || name.Trim().Length == 0)
                    throw new ArgumentException("name is empty/whitespace or null");
                _name = name;
            }
        }
    #endregion

    }

}
