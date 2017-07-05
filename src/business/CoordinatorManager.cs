using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public class CoordinatorManager
    {
        private ICoordinator _coordinator;
        private static CoordinatorManager _instance = new CoordinatorManager();
        public static CoordinatorManager Instance => _instance;
       
        public CoordinatorManager()
        {
            _coordinator = new SimpleCoordinator();
            _coordinator = new CategoryCoordinator(_coordinator);
            _coordinator = new StructureCoordinator(_coordinator);
        }

        public ICoordinator Coordinator => _coordinator;

        /// <summary>
        /// Restituisce un coordinatore del tipo indicato o che
        /// implementa l'interfaccia indicata o in alternativa null
        /// </summary>
        /// <typeparam name="T">Tipo del coordinatore o interfaccia che 
        /// deve implementare</typeparam>
        /// <returns>Coordinatore castato o null</returns>
        public T CoordinatorOfType<T>() where T : ICoordinator
        {
            ICoordinator result = _coordinator.GetCoordinatorOf(typeof(T));
            return result != null ? (T) result : default(T);
        }
    }
}
