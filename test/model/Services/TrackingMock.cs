using CSB_Project.src.model.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.model.Services
{
    class TrackingMock : ITrackingDevice
    {
        private string _id;

        public TrackingMock(string id)
        {
            _id = id;
        }
        public string ID => _id;
    }
}
