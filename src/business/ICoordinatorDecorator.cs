using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.business
{
    interface ICoordinatorDecorator : ICoordinator
    {
        ICoordinator Coordinator { get; }
        bool ContainsCoordinator(Type type);
        ICoordinator getCoordinatorOf(Type type);
    }
}
