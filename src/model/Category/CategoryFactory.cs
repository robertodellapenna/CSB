using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{
    /// <summary>
    /// Factory per creare le categorie
    /// </summary>
    public static partial class CategoryFactory
    {
        /// <summary>
        /// Crea una categoria contenitore
        /// </summary>
        /// <param name="name">Nome della categoria</param>
        /// <param name="parent">Cateogria padre o null se è una radice</param>
        /// <returns>Restituisce un oggetto categoria che può avere figli</returns>
        public static IGroupCategory CreateGroup(String name, IGroupCategory parent)
        {
            return new GroupCategory(name, parent);
        }

        /// <summary>
        /// Crea una cateogria che non può avere figli
        /// </summary>
        /// <param name="name">Nome della categoria</param>
        /// <param name="parent">Padre della categoria, non può essere nullo</param>
        /// <returns>Restituisce un oggetto categoria che non può avere figli</returns>
        public static ILeafCategory CreateLeaf(String name, IGroupCategory parent)
        {
            return new LeafCategory(name, parent);
        }

        public static IGroupCategory CreateFromTree()
        {
            throw new NotImplementedException("Da implementare");
        }
    }
}
