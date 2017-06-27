using CSB_Project.src.model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB_Project.src.model.TrackingDevice;

namespace test.model.Services
{
    class UsageMock : IUsage
    {
        private DateTime _when;
        private ITrackingDevice _who;
        private IUsable _type;

        public DateTime When => _when;

        public ITrackingDevice Who => _who;

        public IUsable Type => _type;

        public UsageMock(DateTime when, ITrackingDevice who, IUsable type)
        {
            _when = when;
            _who = who ?? throw new ArgumentNullException("who null");
            _type = type ?? throw new ArgumentNullException("type null");
        }
    }
}
