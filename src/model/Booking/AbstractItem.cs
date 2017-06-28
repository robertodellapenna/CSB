using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public abstract class AbstractItem : IItem
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly PriceDescriptor _descriptor;
        #endregion

        #region Proprietà
        public string Name => _descriptor.Name;
        public string Description => _descriptor.Description;
        public double BaseDailyPrice => _descriptor.Price;
        #endregion

        #region Costruttori
        public AbstractItem(PriceDescriptor descriptor)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            #endregion
            _descriptor = descriptor;
        }
        #endregion

        #region Metodi

        public override bool Equals(object obj)
        {
            #region Precondizioni
            if (obj == null || !(obj is AbstractItem))
                return false;
            #endregion
            AbstractItem other = obj as AbstractItem;

            return Name == other.Name;
        }
        #endregion

        #region Handler
        #endregion
    }
}
