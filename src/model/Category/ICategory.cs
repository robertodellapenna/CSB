using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{

    interface ICategory
    {
        /// <summary>
        /// Nome della categoria
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Categoria padre
        /// </summary>
        IGroupCategory Parent { get; set; }

        bool HasParent { get; }
    }
}
