using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    class Compatibilities
    {
        #region Eventi
        #endregion

        #region Campi
        private static Compatibilities _instance;
        private readonly Dictionary<IBaseItem, IEnumerable<Tuple<IPluginItem, int>>> _dictionary;

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

        #endregion

        #region Costruttori

        private Compatibilities()
        {
        }

        #endregion

        #region Metodi

        public bool CheckCompatibility(IBaseItem compatibleItem, IPluginItem associableItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");

            if (!_dictionary.ContainsKey(compatibleItem)) return false;
            return _dictionary[compatibleItem].Where(tuple => tuple.Item1.Equals(associableItem)).Any();
        }

        public IEnumerable<IPluginItem> GetAllAssociablePluginItems(IBaseItem compatibleItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatibleItem not present in the dictionary");
            return _dictionary[compatibleItem].Select(tuple => tuple.Item1);
        }

        public IEnumerable<IBaseItem> GetAllCompatibleBaseItems(IPluginItem associableItem)
        {
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            return _dictionary.Where(compatibility => compatibility.Value.Where(tuple => tuple.Item1.Equals(associableItem)).Any()).Select(compatibility => compatibility.Key);
        }

        public int GetMaxQuantity(IBaseItem compatibleItem, IPluginItem associableItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!GetAllAssociablePluginItems(compatibleItem).Contains(associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            return _dictionary[compatibleItem].Where(tuple => tuple.Item1.Equals(associableItem)).Select(tuple => tuple.Item2).ToArray()[0];
        }

        public void AddCompatibility(IBaseItem compatibleItem, IPluginItem associableItem, int maxQuantity)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (compatibleItem is IPluginItem)
                throw new ArgumentException("compatibleItem cannot be a pluginItem");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (maxQuantity <= 0)
                throw new ArgumentException("maxQuantity <= 0");
            if (!_dictionary.ContainsKey(compatibleItem)) _dictionary.Add(compatibleItem, new List<Tuple<IPluginItem, int>>());
            if (CheckCompatibility(compatibleItem, associableItem))
            {
                //Non possono esserci due associable item uguali associati ad uno stesso compatible item
                ChangeMaxQuantity(compatibleItem, associableItem, maxQuantity);
            }
            else ((List<Tuple<IPluginItem, int>>)_dictionary[compatibleItem]).Add(new Tuple<IPluginItem, int>(associableItem, maxQuantity));
        }

        public void ChangeMaxQuantity(IBaseItem compatibleItem, IPluginItem associableItem, int maxQuantity)
        {
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
            _dictionary[compatibleItem].Where(tuple => tuple.Item1.Equals(associableItem)).Select(tuple => tuple.Item2).ToArray<int>()[0] = maxQuantity;
        }

        public void RemoveCompatibility(IBaseItem compatibleItem, IPluginItem associableItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            if (!GetAllAssociablePluginItems(compatibleItem).Contains(associableItem))
                throw new ArgumentException("compatibility between compatible and associable items not present");
            ((List<Tuple<IPluginItem, int>>)_dictionary[compatibleItem].Where(tuple => tuple.Item1.Equals(associableItem))).RemoveAt(0);
        }

        public void RemoveCompatibleItem(IBaseItem compatibleItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            _dictionary.Remove(compatibleItem);
        }

        public void RemoveAssociableItem(IPluginItem associableItem)
        {
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            foreach (IBaseItem compatibleItem in GetAllCompatibleBaseItems(associableItem))
                RemoveCompatibility(compatibleItem, associableItem);
        }

        public void Clean()
        {
            foreach (IBaseItem compatibleItem in _dictionary.Keys) _dictionary.Remove(compatibleItem);
        }
        #endregion

        #region Handler
        #endregion

    }
}
