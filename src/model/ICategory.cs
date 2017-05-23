using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    interface ICategory
    {
        ICategory Parent { get; }
        string Name { get; }
    }
}
