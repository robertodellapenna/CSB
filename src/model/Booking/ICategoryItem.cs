using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface ICategoryItem 
    {
        /// <summary>
        /// Controlla se all'Item è associata una categoria o una sua sotto-categoria
        /// </summary>
        bool ContainsCategory(ICategory category);
        /// <summary>
        /// Controlla se all'Item è associata una precisa categoria
        /// </summary>
        bool ContainsStrictCategory(ICategory category);
        /// <summary>
        /// Associa ad una categoria una descrizione e un prezzo percentuale
        /// </summary>
        /// <param name="category">Categoria da aggiugnere</param>
        /// <param name="valueDescription">descrizione associata alla categoria</param>
        /// <param name="pricePercentual">prezzo percentuale associato alla categoria</param>
        /// <returns>true l'inserimento è andato a buon fine, false altrimenti</returns>
        void AddCategory(ICategory category, String valueDescription, double pricePercentual);
        void ModifyCategory(ICategory category, String valueDescription, double pricePercentual);
        void RemoveCategory(ICategory category);
       
        //forse è un dettaglio implementativo il fatto che ad ogni categoria
        //è legata una descrizione e un prezzo percentuale
        //string GetDescriptionOf(ICategory category);
        //double GetPricePercentualOf(ICategory category);
    }
}
