using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public class Compatibilities
    {
        #region Eventi
        #endregion

        #region Campi
        private static Compatibilities _instance;
        private readonly Dictionary<IItem, AssociableItems> _dictionary;

        #endregion

        #region Proprietà

        public static Compatibilities Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Compatibilities();
                }
                return _instance;
            }
            
        }
        public IEnumerable<IItem> CompatibleItems => _dictionary.Keys;
        #endregion

        #region Costruttori

        private Compatibilities()
        {
            _dictionary = new Dictionary<IItem, AssociableItems>();
        }

        #endregion

        #region Metodi

        public bool CheckCompatibility(IItem compatibleItem, IItem associableItem)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem)) return false;
            #endregion

            //return _dictionary[compatibleItem].Tuples.Where(tuple => tuple.Item1.Equals(associableItem)).Any();
            //return (from t in _dictionary[compatibleItem].Tuples
            //        where t.Item1.Equals(associableItem)
            //        select t).Any();

            return _dictionary[compatibleItem].ContainsKey(associableItem);
        }

        public IEnumerable<IItem> GetAllAssociablePluginItems(IItem compatibleItem)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatibleItem not present in the dictionary");
            #endregion

            //return _dictionary[compatibleItem].Tuples.Select(tuple => tuple.Item1);
            //return (from t in _dictionary[compatibleItem].Tuples
            //        select t.Item1);

            return _dictionary[compatibleItem].Keys;
        }

        public IEnumerable<IItem> GetAllCompatibleBaseItems(IItem associableItem)
        {
            #region Precondizioni
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            #endregion

            //return _dictionary.Where(compatibility => compatibility.Value.Tuples.Where(tuple => tuple.Item1.Equals(associableItem)).Any()).Select(compatibility => compatibility.Key);
            //(from t in c.Value.Tuples
            // where t.Item1.Equals(associableItem)
            // select t).Any()

            return (from c in _dictionary
                    where c.Value.ContainsKey(associableItem)
                    select c.Key);
        }

        public int GetMaxQuantity(IItem compatibleItem, IItem associableItem)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!GetAllAssociablePluginItems(compatibleItem).Contains(associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            #endregion 

            //return _dictionary[compatibleItem].Tuples.Where(tuple => tuple.Item1.Equals(associableItem)).Select(tuple => tuple.Item2).ToArray()[0];
            //return (from t in _dictionary[compatibleItem].Tuples
            //        where t.Item1.Equals(associableItem)
            //        select t.Item2).ToArray()[0];

            return _dictionary[compatibleItem][associableItem];
        }

        public void AddCompatibility(IItem compatibleItem, IItem associableItem, int maxQuantity)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (maxQuantity <= 0)
                throw new ArgumentException("maxQuantity <= 0");
            #endregion
            if (!_dictionary.ContainsKey(compatibleItem))
                _dictionary.Add(compatibleItem, new AssociableItems());
            if (CheckCompatibility(compatibleItem, associableItem))
            {
                //Non possono esserci due associable item uguali associati ad uno stesso compatible item
                ChangeMaxQuantity(compatibleItem, associableItem, maxQuantity);
            }
            else _dictionary[compatibleItem].Add(associableItem, maxQuantity);
        }

        public void ChangeMaxQuantity(IItem compatibleItem, IItem associableItem, int maxQuantity)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (maxQuantity <= 0)
                throw new ArgumentException("maxQuantity <= 0");
            if(!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!GetAllAssociablePluginItems(compatibleItem).Contains(associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            #endregion

            //_dictionary[compatibleItem].Tuples.Where(tuple => tuple.Item1.Equals(associableItem)).Select(tuple => tuple.Item2).ToArray<int>()[0] = maxQuantity;
            //(from t in _dictionary[compatibleItem].Tuples
            // where t.Item1.Equals(associableItem)
            // select t.Item2).ToArray()[0] = maxQuantity;

            _dictionary[compatibleItem][associableItem] = maxQuantity;
        }

        public void RemoveCompatibility(IItem compatibleItem, IItem associableItem)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!GetAllAssociablePluginItems(compatibleItem).Contains(associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            #endregion

            //((List<Tuple<IPluginItem, int>>)_dictionary[compatibleItem].Tuples.Where(tuple => tuple.Item1.Equals(associableItem))).RemoveAt(0);
            //((List<Tuple<IItem, int>>)(from t in _dictionary[compatibleItem].Tuples
            //                                 where t.Item1.Equals(associableItem)
            //                                 select t)).RemoveAt(0);

            _dictionary[compatibleItem].Remove(associableItem);
        }

        public void RemoveCompatibleItem(IItem compatibleItem)
        {
            #region Precondizioni
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            #endregion 
            _dictionary.Remove(compatibleItem);
        }

        public void RemoveAssociableItem(IItem associableItem)
        {
            #region Precondizioni
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            #endregion
            foreach (IItem compatibleItem in GetAllCompatibleBaseItems(associableItem))
                RemoveCompatibility(compatibleItem, associableItem);
        }

        public void Clean()
        {
            foreach (IItem compatibleItem in _dictionary.Keys) _dictionary.Remove(compatibleItem);
        }
        #endregion

        #region Handler
        #endregion

    }
}
