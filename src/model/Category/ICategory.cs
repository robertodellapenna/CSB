using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{

    public interface ICategory
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

        string Path { get; }

        /// <summary>
        /// Verifica se la categoria è contenuta in superParent
        /// </summary>
        /// <param name="superParent">cateogria che deve contenere l'oggetto su cui si invoca il metodo</param>
        /// <returns>True se superParent contiene l'oggetto</returns>
        bool IsInside(IGroupCategory superParent);

        /// <summary>
        /// La gerarchia è cambiata
        /// </summary>
        event EventHandler Changed;
    }
}
