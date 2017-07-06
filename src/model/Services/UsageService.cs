using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.TrackingDevice;

namespace CSB_Project.src.model.Services
{
    class UsageService : IUsage
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly DateTime _when;
        private readonly ITrackingDevice _who;
        private readonly IUsable _type;
        #endregion
        #region Proprieta
        public IUsable Type => _type;
        public DateTime When => _when;
        public ITrackingDevice Who => _who;
        #endregion
        #region Costruttori
        public UsageService(DateTime when, ITrackingDevice who, IUsable type)
        {
            if (when == null)
                throw new ArgumentException("when is not valid");
            _when = when;
            if (who == null)
                throw new ArgumentException("who is not valid");
            _who = who;
            if (type == null)
                throw new ArgumentException("type is not valid");
            _type = type;
        }
        #endregion
        #region Metodi
        #endregion
        #region Handler
        #endregion
    }
}
