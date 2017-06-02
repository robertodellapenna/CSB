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

            public event EventHandler Changed;
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
                    if (this == value)
                        throw new Exception("non puoi essere padre di te stesso");
                    // Il parent che voglio impostare è uguale a quello attuale
                    if (Parent == value)
                        return;

                    IGroupCategory oldParent = Parent;

                    if (oldParent != null)
                    {
                        // Rimuovo l'associazione che avevo precedentemente
                        oldParent.RemoveChild(this);
                    }
                    _parent = value;
                    // Provo ad aggiungermi alla collezione del nuovo padre
                    if (value != null)
                    {
                        try
                        {
                            value.AddChild(this);
                        }
                        catch (Exception e)
                        {
                            // Ripristino il collegamento
                            _parent = oldParent;
                            oldParent?.AddChild(this);
                            // Rilancio l'eccezione
                            throw new Exception("Non sono riuscito ad aggiungermi alla collezione del nuovo padre", e);
                        }
                    }

                    OnChange(this, EventArgs.Empty);
                }
            }
            public bool HasParent => Parent != null;
            public String Path => (Parent?.Path ?? "") + "\\" + Name;
            #endregion

            #region Costruttori
            public Category(String name, IGroupCategory parent)
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

            public override int GetHashCode()
            {
                return Path.GetHashCode();
            }
            #endregion

            #region Handler
            /* Viene invocato quando cambia il padre, unico campo modificabile della classe */
            protected virtual void OnChange(Object o, EventArgs e)
            {
                Changed?.Invoke(o, e);
            }
            #endregion

        }
        #endregion

        #region GroupCateogry class
        private class GroupCategory : Category, IGroupCategory
        {

            #region Eventi
            #endregion

            #region Campi
            /// <summary>
            /// Sottocategorie
            /// </summary>
            private HashSet<ICategory> _children = new HashSet<ICategory>();
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

            public override IGroupCategory Parent
            {
                get => base.Parent;
                set
                {
                    if (Parent != null && value != Parent)
                        Parent.DeregistrationFrom(this);
                    base.Parent = value;
                    if (Parent != null && value != Parent)
                        Parent.RegistrationAt(this);
                }
            }
            #endregion

            #region Costruttori
            public GroupCategory(string name) : this(name, null) { }

            public GroupCategory(string name, IGroupCategory parent) : base(name, parent)
            {
                //_children = 
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
                #region Precondizioni
                if (child == null)
                    throw new ArgumentNullException("child null");
                if (!_children.Contains(child))
                    return;
                //throw new Exception("la collezione non contiene la categoria " + child.Name);
                #endregion
                _children.Remove(child);
                try
                {
                    child.Parent = null;
                }
                catch (Exception e)
                {
                    _children.Add(child);
                    throw new Exception("non sono riuscito a rimuovere il padre di child", e);
                }
                DeregistrationFrom(child);
                //Notifico il cambiamento
                OnChange(this, EventArgs.Empty);
            }

            public void AddChild(ICategory child)
            {
                #region Precondizioni
                if (child == null)
                    throw new ArgumentNullException("child null");
                if (_children.Contains(child))
                    throw new Exception("la collezione contine già questo figlio");
                if (checkCycle(child, this))
                    throw new Exception("Stai creando un ciclo");
                /*
                if (child.Parent == this)
                    // sono già suo padre
                    return;
                /*
                /*
                 * DA ELIMINARE
                if (child.HasParent && child.Parent != this)
                    throw new Exception("child ha già un padre");
                */


                /*
                 * DA ELIMINARE
                if (_children.Contains(child))
                    return;
                    */
                #endregion
                // Lo aggiungo alla collezione interna
                _children.Add(child);
                try
                {
                    child.Parent = this;
                }
                catch (Exception e)
                {
                    _children.Remove(child);
                    throw new Exception("non sono riuscito ad associarmi come padre", e);
                }
                RegistrationAt(child);
                OnChange(this, EventArgs.Empty);
                /*
                if (child.Parent == null)
                {
                    child.Parent = this;
                    RegistrationAt(child);
                    OnChange(this, EventArgs.Empty);
                }
                */
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

            public void RegistrationAt(ICategory child)
            {
                #region Precondizioni
                if (child == null)
                    throw new ArgumentNullException("child null");
                #endregion
                // se è effettivamente mio figlio mi registro
                if (_children.Contains(child))
                    child.Changed += OnChange;
            }

            public void DeregistrationFrom(ICategory child)
            {
                #region Precondizioni
                if (child == null)
                    throw new ArgumentNullException("child null");
                #endregion
                child.Changed -= OnChange;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is IGroupCategory))
                    return false;
                IGroupCategory other = obj as IGroupCategory;

                if (Path != other.Path || _children.Count != other.Children.Length)
                    return false;
                for (int i = 0; i < _children.Count; i++)
                    if (!Children[i].Equals(other.Children[i]))
                        return false;
                // Tutti i figli sono uguali
                return true;
            }

            public override int GetHashCode()
            {
                return Path.GetHashCode();
            }
            #endregion

            #region Handler
            protected override void OnChange(Object sender, EventArgs e)
            {
                base.OnChange(sender, e);
            }
            #endregion
        }
        #endregion

        #endregion
    }
}
