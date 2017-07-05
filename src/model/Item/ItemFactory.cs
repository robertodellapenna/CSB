using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace CSB_Project.src.model.Item
{
    public static partial class ItemFactory
    {
        /// <summary>
        /// Collezione di item. Non è possibile avere due item con nome
        /// identico.
        /// </summary>
        private static readonly ISet<IItem> _items =
           new HashSet<IItem>();

       
        public static IItem GetItem(string identifier)
        {
            #region Precondizioni
            if (String.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("identifier null or blank");
            #endregion

            return _items.Where(i => i.Identifier == identifier).SingleOrDefault();
        }
        

        /// <summary>
        /// Items disponibili all'interno del sistema
        /// </summary>
        public static IEnumerable<IItem> Items => _items;

        /// <summary>
        /// Permette di inserire un nuovo item nel sistema. Riceve in ingresso
        /// una stringa contente tutte le informazioni con la quale costruire
        /// il nuovo Item. La stringa sarà delegata al parser scecifico indicato
        /// sulla prima riga.
        /// </summary>
        /// <param name="itemToParse">Stringa di cui effettuare il parsing</param>
        /// <returns>Restituisce l'item aggiunto alla collezione</returns>
        public static IItem CreateItem(XmlNode itemToParse)
        {
            #region Precondizioni
            if ( itemToParse == null )
                throw new ArgumentException("itemToParse null");
            #endregion
            
            if (itemToParse.Name != "Item")
                throw new InvalidOperationException("Puoi creare solo degli item");
            if (itemToParse.ChildNodes.Count < 2)
                throw new ItemDescriptorException("L'item non ha abbastanzi argomenti");
            XmlNodeList xnl = itemToParse.SelectNodes("Class");
            
            if (xnl.Count != 1)
                throw new ItemDescriptorException("Sono specificate più classi o neanche una");
            string classType = xnl.Item(0).InnerText;
        
            // Verifico se è disponibile un parser 
            Type t = Type.GetType(classType, throwOnError: false, ignoreCase: true);
            if (t == null)
                throw new ItemDescriptorException("Impossibile trovare il parser per " + classType);
            // Invoco il metodo statico Parse sul Parser indicato nella descrizione
            Object obj = t.InvokeMember("Parse", BindingFlags.InvokeMethod | BindingFlags.Public |
                BindingFlags.Static, null, null, new object[] { itemToParse });

            IItem item = null;
            try
            {
                item = obj as IItem;
            }
            catch (InvalidCastException e)
            {
                throw new ItemDescriptorException("Non sono riuscito ad effettuare il casting");
            }

            // Controllo se l'item è già presente
            if (_items.Contains(item))
                throw new InvalidOperationException("Item Name già presente");
            _items.Add(item);
            return item;
        }

        public static IEnumerable<IItem> FindByFriendlyName( string friendlyName )
        {
            #region Precondizioni
            if (String.IsNullOrWhiteSpace(friendlyName))
                throw new ArgumentException("friendlyName null or blank");
            #endregion

            return (from item in _items
                    where item.FriendlyName.Contains(friendlyName)
                    select item);
        }
    }

    public class ItemDescriptorException : ApplicationException
    {
        public ItemDescriptorException(string message) : base(message) { }
    }
}
