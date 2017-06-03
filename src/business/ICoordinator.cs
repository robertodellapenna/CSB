using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface ICoordinator
    {
        event EventHandler Changed;
        void Reload();
        bool ContainsCoordinator(Type type);
        ICoordinator GetCoordinatorOf(Type type);
    }
}
