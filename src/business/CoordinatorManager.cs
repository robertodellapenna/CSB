using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public class CoordinatorManager
    {
        private ICoordinator coordinator;
        private static CoordinatorManager _instance = new CoordinatorManager();
        public static CoordinatorManager Instance => _instance;
       
        public CoordinatorManager()
        {
            coordinator = new SimpleCoordinator();
            coordinator = new CategoryCoordinator(coordinator);
        }

        public ICoordinator Coordinator => coordinator;
    }
}
