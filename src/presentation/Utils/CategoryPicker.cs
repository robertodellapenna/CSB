using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.business;
using CSB_Project.src.model.Category;

namespace CSB_Project.src.presentation.Utils
{
    public partial class CategoryPicker : UserControl
    {
        private const int DEFAULT_WIDTH = 220, DEFAULT_HEIGHT = 150; 
        private const int ITEM_HEIGHT = 40;
        private BorderLabel _selected;
        public ICategory SelectedCategory => _selected?.Tag as ICategory;
        private ICategory _rootCategory;
        private ICategory _currentCategory;
        public ICategory RootCategory
        {
            get => _rootCategory;
            set => _rootCategory = value;
        }

        #region Costruttori
        public CategoryPicker(ICategory root, Size size, Style style = null)
        {
            InitializeComponent();
            RootCategory = root;
            root.Changed += CategoryChangedHandler;
            Size = size;
            this.ApplyStyle(style);
            _flowPanel.HorizontalScroll.Visible = false;
            _flowPanel.HorizontalScroll.Enabled = false;
            _flowPanel.Size = Size;
            
            Refresh();
        }

        public CategoryPicker(ICategory root) : 
            this(root, new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT)) { }

        public CategoryPicker()
            : this(CategoryFactory.CreateRoot("ROOT")) { }
        #endregion

        private void Populate( ICategory category )
        {
            _flowPanel.Controls.Clear();
            if (category == null)
                return;
            _currentCategory = category;
            _flowPanel.Controls.Add(CreateBorderLabel(0, category.Parent));
            if(category is IGroupCategory)
            {
                int index = 0;
                foreach(ICategory c in (category as IGroupCategory).Children)
                    _flowPanel.Controls.Add(CreateBorderLabel(++index, c));
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            Populate(RootCategory);
        }

        private BorderLabel CreateBorderLabel(int itemNumber, ICategory c)
        {
            BorderLabel bl = new BorderLabel(c?.Name ?? "");
            bl.Margin = new Padding(0);
            bl.BorderSize = 2;
            bl.AutoSize = false;
            bl.Size = new Size(_flowPanel.Width - SystemInformation.VerticalScrollBarWidth, ITEM_HEIGHT);
            bl.Location = new Point(0, ITEM_HEIGHT * itemNumber);
            if (itemNumber == 0 && !String.IsNullOrEmpty(c?.Name ?? null))
                bl.Icon = Image.FromFile("../../icon/goUp.png");
            bl.Tag = c;
            if (itemNumber == 0)
            {
                bl.Click += RepopulateHandler;
                bl.ForeColor = Color.Yellow;
                bl.ForeColorHover = Color.Yellow;
            }
            else
            {
                bl.Click += SelecectHandler;
                bl.ForeColorHover = Color.LightYellow;
            }
            bl.DoubleClick += RepopulateHandler;
            
            return bl;
        }

        private void Deselect()
        {
            if (_selected == null)
                return;
            _selected.BackColor = Color.Black;
            _selected.BackColorHover = Color.Black;
            _selected = null;
        }

        private void Select(BorderLabel bl)
        {
            bl.BackColor = Color.Blue;
            bl.BackColorHover = Color.Blue;
            _selected = bl;
        }

        #region Handler
        private void SelecectHandler(Object obj, EventArgs e)
        {
            if (!(obj is BorderLabel))
                // non posso continuare;
                return;
            Object clickeObj = (obj as BorderLabel).Tag;
            if (clickeObj == null)
            {
                //cliccato sulla label vuota
                Deselect();
                return;
            }
            if (!(clickeObj is ICategory))
                // non posso continuare
                throw new InvalidOperationException("Il tag non è una categoria");
            ICategory clickedCat = clickeObj as ICategory;
            if (clickedCat == SelectedCategory)
            {
                Deselect();
            }
            else
            {
                Deselect();
                Select(obj as BorderLabel);
            }
        }

        private void CategoryChangedHandler(Object obj, EventArgs e)
        {
            Populate(_currentCategory);
        }

        private void RepopulateHandler(Object obj, EventArgs e)
        {
            if( !(obj is BorderLabel))
                // non posso continuare;
                return;
            Object clickeObj = (obj as BorderLabel).Tag;
            if (clickeObj == null)
                //cliccato sulla label vuota
                return;
            if (!(clickeObj is ICategory))
                // non posso continuare
                throw new InvalidOperationException("Il tag non è una categoria");
            ICategory clickedCat = clickeObj as ICategory;
            if(!(clickedCat is IGroupCategory) 
                || (clickedCat as IGroupCategory).Children.Count() == 0)
            {
                MessageBox.Show("Non ci sono sottocategori");
                return;
            }
            Populate(clickedCat);
            Deselect();
        }
        #endregion
    }
}
