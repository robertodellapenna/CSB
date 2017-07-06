using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.business;

namespace CSB_Project.src.presentation.ItemCreatorPresenter
{
    public partial class CategoryPicker : UserControl
    {
        public CategoryPicker()
        {
            InitializeComponent();
            ICategoryCoordinator coor = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
            if (coor == null)
                throw new InvalidOperationException("Coordinatore categorie non disponibile");
            
            
        }
    }
}
