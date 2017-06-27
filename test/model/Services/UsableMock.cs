using CSB_Project.src.model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB_Project.src.model.Utils;

namespace test.model.Services
{
    class UsableMock : IUsable
    {
        private string _name;
        private DateRange _avail;

        public UsableMock( string name)
        {
            _name = name;
            _avail = new DateRange(new DateTime(10, 10, 10), new DateTime(10, 10, 15));
        }

        public string Name => _name;

        public string Description => "Mock Service";

        public double Price => 10;

        public DateRange Availability => _avail;

        public bool IsActiveIn(DateTime when) => Availability.Contains(when);

        public bool IsActiveIn(DateRange when) => Availability.Contains(when);
    }
}
