using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using CSB_Project.src.model.Item;
using System.Collections.ObjectModel;

namespace CSB_Project.src.presentation
{
    public class ItemCreatorPresenter
    {
        private Func<XmlNode, bool> _addItemDelegate;
        private Func<IEnumerable<IItem>> _items;

        public ItemCreatorPresenter(ItemCreatorView view, Func<XmlNode, bool> addItemDelegate, Func<IEnumerable<IItem>> items){

            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (addItemDelegate == null)
                throw new ArgumentNullException("addItemDelegate null");
            if (items == null)
                throw new ArgumentNullException("items null");
            #endregion
            _addItemDelegate = addItemDelegate;
            _items = items;
            //Recupero tutte le classi dall'assembly che contengono il nome 
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = from type in assembly.GetTypes()
                                      where type.Namespace == "CSB_Project.src.presentation.ItemCreator"
                                      && Regex.IsMatch(type.Name, @"^.+CreatorView$") 
                                      && type.GetConstructor(Type.EmptyTypes) != null
                                      && type.BaseType == typeof(System.Windows.Forms.Form)
                                      select type;

            foreach(Type viewType in types)
            {
                // Controllo che ci sia un presenter per questo tipo
                IEnumerable<Type> presenterType = from type in assembly.GetTypes()
                                          where type.Namespace == "CSB_Project.src.presentation.ItemCreator"
                                          && Regex.IsMatch(type.Name, @"^" + viewType.Name.Replace("CreatorView","") + @"CreatorPresenter$")
                                          && type.GetConstructor(new Type[] { viewType, _addItemDelegate.GetType(), _items.GetType() }) != null
                                          select type;

                if (presenterType.Count() != 1)
                    continue;

                Button b = new Button();
                b.Text = viewType.Name.Replace("CreatorView", "");
                b.Size = new Size(view.ButtonPanel.Width, 40);
                b.Margin = new Padding(0);
                b.BackColor = SystemColors.Control;
                b.Click += (sender, e) => AssociateView(viewType, presenterType.ElementAt(0));

                view.ButtonPanel.Controls.Add(b);
            }
        }

        private void AssociateView(Type viewType, Type presenterType)
        {
            // creo la view
            Object view = viewType.GetConstructor(Type.EmptyTypes).Invoke(new object[] { });
            // creo il presenter passandogli la view
            presenterType.GetConstructor(new Type[] { viewType, _addItemDelegate.GetType(), _items.GetType() })
                .Invoke(new object[] { view, _addItemDelegate, _items });
            // mostro la view
            (view as Form).Show();
        }
    }
}
