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
        private int _id;

        public TrackingMock(int id)
        {
            _id = id;
        }
        public int Id => _id;
    }
}
