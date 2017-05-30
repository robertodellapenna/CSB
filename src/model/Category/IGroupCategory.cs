using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Category
{
    public interface IGroupCategory : ICategory
    {
        /// <summary>
        /// Collezione dei figli della categoria
        /// </summary>
        ICategory[] Children { get; }
        /// <summary>
        /// Verifica se la categoria ha figli
        /// </summary>
        /// <returns>true se ha dei figli altrimenti false</returns>
        bool HasChild { get; }
        /// <summary>
        /// Verifica se tra i figli è presente una particolare categoria
        /// </summary>
        /// <param name="name">Nome della categoria</param>
        /// <returns>true se la categoria è presente tra i figli altrimenti false</returns>
        bool ContainsChild(string name);
        /// <summary>
        /// Verifica se la cateogria è la radice della gerarchia
        /// </summary>
        /// <returns>true se il parent è nullo altrimenti false</returns>
        bool IsRoot { get; }
        /// <summary>
        /// Rimuove il figlio dai Children
        /// </summary>
        /// <param name="child">Figlio da rimuovere</param>
        void RemoveChild(ICategory child);

        void AddChild(ICategory child);
        
    }
}
