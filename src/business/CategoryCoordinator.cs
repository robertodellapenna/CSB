using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSB_Project.src.business
{
    public interface ICategoryCoordinator : ICoordinator
    {
        IGroupCategory RootCategory { get; }
        ICategory getCategoryByPath(string path);
        event EventHandler CategoryChanged;
    }

    public class CategoryCoordinator : AbstractCoordinatorDecorator, ICategoryCoordinator
    {

        #region Eventi
        public event EventHandler CategoryChanged;
        #endregion

        #region Campi
        private IGroupCategory _root;
        #endregion

        #region Proprietà
        public IGroupCategory RootCategory => _root;
        #endregion

        #region Costruttori
        public CategoryCoordinator(ICoordinator next) : base(next) { }
        #endregion

        #region Metodi
        protected override void init()
        {
            /* Cerco un file di configurazione delle categorie nel fileSystem,
             * se lo trovo carico le categorie contenute, altrimenti inizializzo
             * una nuova categoria 
             */
            _root = CategoryFactory.CreateRoot("ROOT");
            _root.Changed += OnCategoryChanged;

            /* Categorie HardCoded */
            IGroupCategory materiali = CategoryFactory.CreateGroup("materiali", _root);
            CategoryFactory.CreateCategory("testa", materiali);
            CategoryFactory.CreateCategory("staffa", materiali);
        }

        public ICategory getCategoryByPath(string path)
        {
            #region Precondizioni
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path null or blank");
            if (!Regex.IsMatch( path, @"^(\\[^\\]+){1,}$", RegexOptions.Singleline))
                throw new ArgumentException("path non è un percorso valido");
            #endregion
            string[] categories = path.Split('\\');

            if (categories[1] != _root.Name )
                return null;

            if (categories.Length == 2)
                return _root;

            IGroupCategory currentCat = _root;
            for (int i = 2; i < categories.Length-1; i++)
            {
                currentCat = (from cat in currentCat.Children
                              where cat.Name == categories[i]
                              && cat is IGroupCategory
                              select cat as IGroupCategory).FirstOrDefault();
                if (currentCat == null)
                    return null;
            }


            return (from cat in currentCat.Children
                    where cat.Name == categories[categories.Length-1]
                    select cat).FirstOrDefault();
        }
        #endregion

        #region Handler
        private void OnCategoryChanged( Object sender, EventArgs args)
        {
            CategoryChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
