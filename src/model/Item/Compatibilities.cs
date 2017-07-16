using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Item
{
    /// <summary>
    /// Gestice le comptabilità tra un 'baseItem' e tutti gli item
    /// associabili. L'associazione non è bidirezionale, se un baseItem è 
    /// comptabile con un item, l'item associato può essere non comptabile
    /// con baseItem
    /// </summary>
    public class Compatibilities
    {
        #region Campi
        /// <summary>
        /// Istanza singleton
        /// </summary>
        private static Compatibilities _instance = new Compatibilities();
        /// <summary>
        /// La chiave rappresenta l'item a cui associare vari componenti.
        /// Il valore del dizionario rappresenta tutti i componenti associabili 
        /// alla chiave e in che quantità 
        /// </summary>
        private readonly Dictionary<IItem, Dictionary<IItem, int>> _compatibiltyMap;
        #endregion

        #region Proprietà
        public static Compatibilities Instance => _instance;
        public IEnumerable<IItem> BaseItems => _compatibiltyMap.Keys.ToArray();
        public IEnumerable<IItem> AllItems
        {
            get
            {
                IEnumerable<IItem> items = new List<IItem>();
                //ISet<IItem> items = new HashSet<IItem>();
                IEnumerable<IItem> keys = _compatibiltyMap.Keys.ToArray();
                items = items.Concat(keys);
                foreach (IItem i in keys)
                    items = items.Concat(_compatibiltyMap[i].Keys.ToArray());
                return items.Distinct();
            }
        }

        #endregion

        #region Costruttori

        private Compatibilities()
        {
            _compatibiltyMap = new Dictionary<IItem, Dictionary<IItem, int>>();
        }
        #endregion

        #region Metodi

        /// <summary>
        /// Permette di verificare se un item 'itemToCheck'
        /// è compatibile con un baseItem
        /// </summary>
        /// <param name="baseItem">Item sulla quale effettuare il controllo</param>
        /// <param name="itemToCheck">Item che deve essere controllato</param>
        /// <returns> True se 'baseItem' può contenere un 'itemToCheck', altrimenti false</returns>        
        public bool CheckCompatibility(IItem itemToCheck, IItem baseItem)
        {
            #region Precondizioni
            if (itemToCheck == null)
                throw new ArgumentException("baseItem null");
            if (baseItem == null)
                throw new ArgumentException("associableItem null");
            #endregion
            if (!_compatibiltyMap.ContainsKey(baseItem))
                return false;

            return _compatibiltyMap[baseItem].ContainsKey(itemToCheck);
        }

        /// <summary>
        /// Dato un item restituisce tutti gli item che si possono associare
        /// </summary>
        /// <param name="baseItem">item dalla quale prelevare gli item associabili</param>
        /// <returns>Collezione di IItem associabili a 'baseItem'</returns>
        public IEnumerable<IItem> GetAllAssociableItems(IItem baseItem)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (!_compatibiltyMap.ContainsKey(baseItem))
                throw new ArgumentException("baseItem not present in the dictionary");
            #endregion

            return _compatibiltyMap[baseItem].Keys;
        }

        /// <summary>
        /// Dato un item restituisce tutti gli item a cui è possibile associarlo
        /// </summary>
        /// <param name="itemToAssociate">item da associare</param>
        /// <returns>Collezione di IItem a cui è possibile associarlo</returns>
        public IEnumerable<IItem> GetBaseItemsComptabileWith(IItem itemToAssociate)
        {
            #region Precondizioni
            if (itemToAssociate == null)
                throw new ArgumentException("associableItem null");
            #endregion

            //return _dictionary.Where(compatibility => compatibility.Value.Tuples.Where(tuple => tuple.Item1.Equals(associableItem)).Any()).Select(compatibility => compatibility.Key);
            //(from t in c.Value.Tuples
            // where t.Item1.Equals(associableItem)
            // select t).Any()

            return (from c in _compatibiltyMap
                    where c.Value.ContainsKey(itemToAssociate)
                    select c.Key);
        }

        /// <summary>
        /// Dato un item base è un altro item restituisce il
        /// numero di volte che è possibile associare tale item a 'baseItem'
        /// </summary>
        /// <param name="baseItem"></param>
        /// <param name="associableItem"></param>
        /// <returns></returns>
        public int GetMaxQuantity(IItem baseItem, IItem associableItem)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_compatibiltyMap.ContainsKey(baseItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            #endregion
            return _compatibiltyMap[baseItem].ContainsKey(associableItem) 
                ? _compatibiltyMap[baseItem][associableItem] : 0;
        }

        public void AddBaseItem(IItem baseItem)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            #endregion
            if (!_compatibiltyMap.ContainsKey(baseItem))
                _compatibiltyMap.Add(baseItem, new Dictionary<IItem, int>());
        }

        /// <summary>
        /// Aggiunge una comptabilità tra 'baseItem' e 'associableItem'
        /// </summary>
        /// <param name="baseItem"></param>
        /// <param name="associableItem"></param>
        /// <param name="maxQuantity"></param>
        public void AddCompatibility(IItem baseItem, IItem associableItem, int maxQuantity = int.MaxValue)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (maxQuantity <= 0)
                throw new ArgumentException("maxQuantity <= 0");
            #endregion
            if (!_compatibiltyMap.ContainsKey(baseItem))
                _compatibiltyMap.Add(baseItem, new Dictionary<IItem, int>());

            if (CheckCompatibility(baseItem, associableItem))
                //Non possono esserci due associable item uguali associati ad uno stesso compatible item
                ChangeMaxQuantity(baseItem, associableItem, maxQuantity);
            else
                // Comptabilità non presente
                _compatibiltyMap[baseItem].Add(associableItem, maxQuantity);
        }

        public void ChangeMaxQuantity(IItem baseItem, IItem associableItem, int maxQuantity)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (maxQuantity <= 0)
                throw new ArgumentException("maxQuantity <= 0");
            if(!_compatibiltyMap.ContainsKey(baseItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!CheckCompatibility(baseItem, associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            #endregion
            
            _compatibiltyMap[baseItem][associableItem] = maxQuantity;
        }

        public void RemoveCompatibility(IItem baseItem, IItem associableItem)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_compatibiltyMap.ContainsKey(baseItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!CheckCompatibility(baseItem, associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            #endregion
            _compatibiltyMap[baseItem].Remove(associableItem);
        }

        public void RemoveBaseItem(IItem baseItem)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (!_compatibiltyMap.ContainsKey(baseItem))
                throw new ArgumentException("baseItem item not present in the dictionary");
            #endregion 
            _compatibiltyMap.Remove(baseItem);
        }

        public void RemoveAssociableItem(IItem associableItem)
        {
            #region Precondizioni
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            #endregion
            foreach (IItem baseItem in GetBaseItemsComptabileWith(associableItem))
                RemoveCompatibility(baseItem, associableItem);
        }

        public void Clean()
        {
            _compatibiltyMap.Clear();
        }
        #endregion
    }
}
