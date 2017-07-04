using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IItemCoordinator : ICoordinator
    {

    }

    class ItemCoordinator : AbstractCoordinatorDecorator, IItemCoordinator
    {
        public ItemCoordinator(ICoordinator next) : base(next)
        {
        }
    }
}
