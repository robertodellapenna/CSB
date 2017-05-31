using System;
using System.Collections.Generic;

namespace CSB_Project.src.model.Category
{
    /// <summary>
    /// Classi che implementano le interfacce ICategory, IGroupCategory
    /// </summary>
    static partial class CategoryFactory
    {
        #region Nested class

        /// <summary>
        /// Classe per le categorie senza figli
        /// </summary>
        #region CategoryTemplate class
        private class Category : ICategory
        {
            #region Campi
            private readonly string _name;
            private IGroupCategory _parent;
            #endregion

            #region Proprietà
            /// <summary>
            /// Nome della proprietà
            /// </summary>
            public string Name { get => _name; }
            /// <summary>
            /// Riferimento alla classe padre
            /// </summary>
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
            public bool HasParent => Parent != null;
            public String Path => (Parent?.Path ?? "" ) + "\\" + Name; 
            #endregion

            #region Costruttori
            public Category( String name, IGroupCategory parent)
            {
                if (name == null || name.Trim().Length == 0)
                    throw new ArgumentException("name null, only blank or empty");
                _name = name;
                Parent = parent;
            }
            #endregion

            #region Metodi
            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is ICategory))
                    return false;
                ICategory other = obj as ICategory;
                return Path == other.Path;
            }
            #endregion

        }
        #endregion

        #region GroupCateogry class
        private class GroupCategory : Category, IGroupCategory
        {

            #region Campi
            /// <summary>
            /// Sottocategorie
            /// </summary>
            private HashSet<ICategory> _children;
            #endregion

            #region Proprietà
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

            public bool IsRoot => Parent == null;
            #endregion

            #region Costruttori
            public GroupCategory(string name) : this(name, null) { }

            public GroupCategory(string name, IGroupCategory parent) : base(name, parent)
            {
                _children = new HashSet<ICategory>();
            }
            #endregion

            #region Metodi
            /// <summary>
            /// Verifica se contine una categoria con il nome indicato
            /// </summary>
            /// <param name="name">Nome della categoria da cercare</param>
            /// <returns>True se ha trovato la categoria altrimenti false</returns>
            public bool ContainsChild(string name)
            {
                foreach (ICategory c in _children)
                    if (c.Name == name)
                        return true;
                return false;
            }
            /// <summary>
            /// Rimuove la categoria indicata, non verifica la presenza di figli in child
            /// </summary>
            /// <param name="child"></param>
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
                if (!_children.Contains(child))
                    _children.Add(child);
                if (child.Parent == null)
                    child.Parent = this;
            }
            /// <summary>
            /// Verifica se il figli newChild può essere aggiunto a newParent senza creare
            /// dei cicli all'interno dell'albero 'virtuale' delle cateogrie.
            /// </summary>
            /// <param name="newChild">figlio</param>
            /// <param name="newParent">Nuovo padre</param>
            /// <returns>True se non si creano cicli aggiungendo il nuovo figli, altrimenti false</returns>
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

                if (Path != other.Path || _children.Count != other.Children.Length)
                    return false;
                for(int i=0; i<_children.Count; i++)
                    if (!Children[i].Equals(other.Children[i]))
                        return false;
                // Tutti i figli sono uguali
                return true;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
            #endregion
        }
        #endregion
        
        #endregion
    }
}
