using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.TrackingDevice
{
    public abstract class Card : ITrackingDevice
    {
        #region Eventi
        #endregion
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
        #endregion
        #region Handler
        #endregion
    }
}
