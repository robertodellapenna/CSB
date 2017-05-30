using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{
    /// <summary>
    /// Interfaccia marker per indicare che una categoria non può avere figli
    /// </summary>
    public interface ILeafCategory : ICategory
    {
    }
}
