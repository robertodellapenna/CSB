using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.business
{
    interface ICoordinator
    {
        event EventHandler Changed;
        void Reload();
    }
}
