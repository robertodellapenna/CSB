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
        private readonly Dictionary<IBaseItem, IEnumerable<IPluginItem>> _dictionary;

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
            return _dictionary[compatibleItem].Contains<IPluginItem>(associableItem);
        }

        public IEnumerable<IPluginItem> GetAllAssociablePluginItems(IBaseItem compatibleItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatibleItem not present in the dictionary");
            return _dictionary[compatibleItem];

        }

        public IEnumerable<IBaseItem> GetAllCompatibleBaseItems(IPluginItem associableItem)
        {
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            return _dictionary.Where(compatibility => compatibility.Value.Contains<IPluginItem>(associableItem)).Select(compatibility => compatibility.Key);
        }

        public void AddCompatibility(IBaseItem compatibleItem, IPluginItem associableItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (compatibleItem is IPluginItem)
                throw new ArgumentException("compatibleItem cannot be a pluginItem");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem)) _dictionary.Add(compatibleItem, new List<IPluginItem>());
            ((List<IPluginItem>)_dictionary[compatibleItem]).Add(associableItem);
        }

        public void RemoveCompatibility(IBaseItem compatibleItem, IPluginItem associableItem)
        {
            if (compatibleItem == null)
                throw new ArgumentException("compatibleItem null");
            if (associableItem == null)
                throw new ArgumentException("associableItem null");
            if (!_dictionary.ContainsKey(compatibleItem))
                throw new ArgumentException("compatible item not present in the dictionary");
            ((List<IPluginItem>)_dictionary[compatibleItem]).Remove(associableItem);
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
            foreach (IBaseItem compatibleItem in _dictionary.Where(compatibility => compatibility.Value.Contains<IPluginItem>(associableItem)).Select(compatibility => compatibility.Key))
                ((List<IPluginItem>)_dictionary[compatibleItem]).Remove(associableItem);
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
