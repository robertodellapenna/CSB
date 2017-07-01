using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.persistence
{
    public class ItemPopulatorFactory
    {
        private static ItemPopulatorFactory _instance = new ItemPopulatorFactory();
        private ItemPopulatorFactory() { }
        public static ItemPopulatorFactory Instance => _instance;
        public IItemPopulator getReader() => new XMLItemPopulator();


        private class XMLItemPopulator : IItemPopulator
        {
            
            public XMLItemPopulator()
            {

            }

            /// <summary>
            /// Legge da un file XML gli Item e li inserisci all'interno del dizionario
            /// </summary>
            /// <param name="dict"></param>
            public void Popoulate(IDictionary<string, IItem> dict)
            {
                /* Leggo dal file e aggiungo al dict */
            }
        }
    }
}
