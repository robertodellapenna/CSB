using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{
    /// <summary>
    /// Factory per istanziare le classi Category
    /// </summary>
    public static partial class CategoryFactory
    {
        /// <summary>
        /// Crea una categoria contenitore
        /// </summary>
        /// <param name="name">Nome della categoria</param>
        /// <param name="parent">Cateogria padre o null se è una radice</param>
        /// <returns>Restituisce un oggetto categoria che può avere figli</returns>
        public static IGroupCategory CreateGroup(String name, IGroupCategory parent) => new GroupCategory(name, parent);

        /// <summary>
        /// Crea una cateogria che non può avere figli
        /// </summary>
        /// <param name="name">Nome della categoria</param>
        /// <param name="parent">Padre della categoria, non può essere nullo</param>
        /// <returns>Restituisce un oggetto categoria che non può avere figli</returns>
        public static ICategory CreateLeaf(String name, IGroupCategory parent) => new Category(name, parent);

        /// <summary>
        /// Crea una classe contenitore con parent null, ha lo stesso comportamento
        /// di CreateGroup(name , null).
        /// </summary>
        /// <returns></returns>
        public static IGroupCategory CreateRoot(String name) => new GroupCategory(name, null);

        public static IGroupCategory CreateFromTree()
        {
            throw new NotImplementedException("Da implementare");
        }
    }
}
