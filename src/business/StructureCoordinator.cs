using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IStructureCoordinator : ICoordinator
    {
        IEnumerable<Structure> Structures { get; }
        void AddStructure(Structure structure);
        event EventHandler StructureChanged;
    }

    public class StructureCoordinator : AbstractCoordinatorDecorator, IStructureCoordinator
    {
        #region Eventi
        public event EventHandler StructureChanged;
        #endregion

        #region Campi
        private readonly IEnumerable<Structure> _structures;
        #endregion

        #region Proprietà
        public IEnumerable<Structure> Structures => _structures.ToArray();
        #endregion

        #region Costruttori
        public StructureCoordinator(ICoordinator next) : base(next)
        {
            _structures = new List<Structure>();
        }
        
        #endregion

        #region Metodi
        protected override void init()
        {
            base.init();
            /* Cerco un file di configurazione delle structures nel fileSystem,
             * se lo trovo carico le structures contenute
             */

            /* Structures HardCoded */
            Sector sector1 = new Sector(new model.Utils.PriceDescriptor("Settore base", "Descrizione settore base", 0.0), 5, 10);
            Sector sector2 = new Sector(new model.Utils.PriceDescriptor("Settore vip", "Descrizione settore vip", 2.0), 2, 5);
            StructureArea area1 = new StructureArea(new BasicDescriptor("Spiaggia", "Descrizione spiaggia"));
            area1.addSector(sector1);
            area1.addSector(sector2);

            sector1= new Sector(new model.Utils.PriceDescriptor("Settore base", "Descrizione settore base", 1.0), 2, 8);
            sector2= new Sector(new model.Utils.PriceDescriptor("Settore idromassaggio", "Descrizione settore idromassaggio", 4.0), 1, 8);
            StructureArea area2 = new StructureArea(new BasicDescriptor("Piscina", "Descrizione piscina"));
            area2.addSector(sector1);
            area2.addSector(sector2);

            Structure structure = new Structure(new BasicDescriptor("Stabilimento Bologna Via Mario Longhena", "Descrizione stabilimento"));
            structure.addArea(area1);
            structure.addArea(area2);

            (_structures as List<Structure>).Add(structure);
        }
        public void AddStructure(Structure structure)
        {
            #region Precondizioni
            if (structure == null)
                throw new ArgumentNullException("structure null");
            #endregion
            if(!_structures.Contains(structure))
                (_structures as List<Structure>).Add(structure);
        }
        #endregion

        #region Handler
        #endregion

    }
}
