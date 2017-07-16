using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.TrackingDevice
{
    public abstract class Card : ITrackingDevice
    {
        #region Campi
        private readonly int _id;
        #endregion
        #region Proprieta
        public int Id { get => _id; }
        #endregion
        #region Costruttori
        /// <summary>
        /// Carta associabile a prenotazioni 
        /// serve per il resoconto finale dei servizi utilizzati
        /// </summary>
        /// <param name="id">id</param>
        public Card(int id)
        {
            if (id < 0)
                throw new ArgumentException("id not valid");
            _id = id;
        }
        #endregion
        #region Metodi
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 31;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is ITrackingDevice))
                return false;
            return (obj as ITrackingDevice).Id == Id;
        }
        #endregion
    }
}
