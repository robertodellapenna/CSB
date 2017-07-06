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
        private readonly List<Structure> _structures = new List<Structure>();
        #endregion

        #region Proprietà
        public IEnumerable<Structure> Structures => _structures.ToArray();
        #endregion

        #region Costruttori
        public StructureCoordinator(ICoordinator next) : base(next)
        {
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
            Sector sector1 = new Sector(new PriceDescriptor("Settore base", "Descrizione settore base", 0.0), 5, 10);
            Sector sector2 = new Sector(new PriceDescriptor("Settore vip", "Descrizione settore vip", 2.0), 2, 5);
            StructureArea area1 = new StructureArea(new BasicDescriptor("Spiaggia", "Descrizione spiaggia"));
            area1.addSector(sector1);
            area1.addSector(sector2);

            sector1 = new Sector(new PriceDescriptor("Settore base", "Descrizione settore base", 1.0), 2, 8);
            sector2 = new Sector(new PriceDescriptor("Settore idromassaggio", "Descrizione settore idromassaggio", 4.0), 1, 8);
            StructureArea area2 = new StructureArea(new BasicDescriptor("Piscina", "Descrizione piscina"));
            area2.addSector(sector1);
            area2.addSector(sector2);

            Structure structure = new Structure(new BasicDescriptor("Stabilimento Bologna Via Mario Longhena", "Descrizione stabilimento"));
            structure.addArea(area1);
            structure.addArea(area2);

            _structures.Add(structure);
        }

        public void AddStructure(Structure structure)
        {
            #region Precondizioni
            if (structure == null)
                throw new ArgumentNullException("structure null");
            if (_structures.Where(str => str.Name.Equals(structure.Name)).Any())
                throw new Exception("structure with this name already exists");
            #endregion
            if (!_structures.Contains(structure))
                (_structures as List<Structure>).Add(structure);
        }
        public Structure GetStructure(String strName)
        {
            #region Precondizioni
            if (strName == null || strName.Trim().Length == 0)
                throw new ArgumentException("strName null, empty or blank");
            #endregion
            if (!_structures.Where(str => str.Name.Equals(strName)).Any())
                return null;
            return _structures.Where(str => str.Name.Equals(strName)).ElementAt(0);
        }
        public StructureArea GetAreaIn(String strName, String areaName)
        {
            #region Precondizioni
            if (strName == null || strName.Trim().Length == 0)
                throw new ArgumentException("strName null, empty or blank");
            if (GetStructure(strName)==null)
                throw new Exception("there is no structure with this name");
            if (areaName == null || areaName.Trim().Length == 0)
                throw new ArgumentException("areName null, empty or blank");
            #endregion
            if (!GetStructure(strName).Areas.Where(area => area.Name.Equals(areaName)).Any())
                return null;
            return GetStructure(strName).Areas.Where(area => area.Name.Equals(areaName)).ElementAt(0);

        }
        public Sector GetSectorIn(String strName, String areaName, String sectorName)
        {
            #region Precondizioni
            if (strName == null || strName.Trim().Length == 0)
                throw new ArgumentException("strName null, empty or blank");
            if (GetStructure(strName) == null)
                throw new Exception("there is no structure with this name");
            if (areaName == null || areaName.Trim().Length == 0)
                throw new ArgumentException("areName null, empty or blank");
            if (GetAreaIn(strName, areaName)==null)
                throw new Exception("there is no area with this name in this structure");
            #endregion
            return GetAreaIn(strName, areaName).Sectors.Where(sector => sector.Name.Equals(sectorName)).ElementAt(0);
        }
        #endregion

        #region Handler
        private void OnStructureChanged(Object sender, EventArgs args)
        {
            StructureChanged?.Invoke(sender, args);
        }
        #endregion

    }
}