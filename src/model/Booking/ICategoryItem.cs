using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.model.Booking
{
    interface ICategoryItem 
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
        /// Inserisce nel dizionario una chiave(categoria) associandola ad un valore(descrizione + prezzo)
        /// </summary>
        /// <param name="category">Categoria da aggiugnere</param>
        /// <param name="valueDescription">descrizione del valore associato alla categoria</param>
        /// <param name="pricePercentual">prezzo percentuale del valore associato alla categoria</param>
        /// <returns>true l'inserimento è andato a buon fine, false altrimenti</returns>
        void AddCategory(ICategory category, String valueDescription, double pricePercentual);
        void ModifyCategory(ICategory category, String valueDescription, double pricePercentual);
        void RemoveCategory(ICategory category);
        /// <summary>
        /// Estrae il valore associato ad una categoria 
        /// </summary>
        /// <param name="category">Nome della categoria</param>
        /// <returns>Il valore ed il prezzo percentuale associato alla categoria</returns>
        Tuple<string, double> getValueOfCategory(ICategory category);
    }
}
