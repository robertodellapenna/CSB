using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface ICoordinatorDecorator : ICoordinator
    {
        ICoordinator NextCoordinator { get; }
    }
}
