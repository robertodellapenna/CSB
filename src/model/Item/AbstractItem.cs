using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Item
{
    public abstract class AbstractItem : IItem
    {
        #region Campi
        private readonly PriceDescriptor _descriptor;
        private readonly string _identifier;
        #endregion

        #region Proprietà
        public string Identifier => _identifier;
        public string Description => _descriptor.Description;
        public double BaseDailyPrice => _descriptor.Price;
        public string FriendlyName => _descriptor.Name;
        public virtual double DailyPrice => BaseDailyPrice;
        public abstract string InformationString { get; }
        #endregion

        #region Costruttori
        public AbstractItem(string id, PriceDescriptor descriptor)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            if (String.IsNullOrWhiteSpace(id))
                throw new ArgumentException("id null or blank");
            #endregion
            _descriptor = descriptor;
            _identifier = id;
        }
        #endregion

        #region Metodi
        public override int GetHashCode()
        {
            return _identifier.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AbstractItem))
                return false;
            AbstractItem other = obj as AbstractItem;

            return Identifier == other.Identifier;
        }
        #endregion
    }
}
