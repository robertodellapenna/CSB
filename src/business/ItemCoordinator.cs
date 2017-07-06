using CSB_Project.src.model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IItemCoordinator : ICoordinator
    {
        IEnumerable<IItem> baseItems { get; }
        IEnumerable<IItem> GetAssociableItemOf(IItem baseItem);
    }

    class ItemCoordinator : AbstractCoordinatorDecorator, IItemCoordinator
    {
        private Compatibilities _compatibilites;

        public ItemCoordinator(ICoordinator next) : base(next)
        {
            _compatibilites = Compatibilities.Instance;
        }

        public IEnumerable<IItem> baseItems => _compatibilites.BaseItems;

        public IEnumerable<IItem> GetAssociableItemOf(IItem baseItem) 
            => _compatibilites.GetBaseItemsComptabileWith(baseItem);
    }
}
