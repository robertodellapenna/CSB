using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.business
{
    public interface ICoordinatorDecorator : ICoordinator
    {
        ICoordinator Coordinator { get; }
    }
}
