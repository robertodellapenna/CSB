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
        public event EventHandler SelectionChanged;

        private const int DEFAULT_WIDTH = 220, DEFAULT_HEIGHT = 150; 
        private const int DEFAULT_ITEM_HEIGHT = 40, DEFAULT_ITEM_TO_SHOW = 2;
        private int _itemToShow, _itemHeight, _width;
        private Style _style;

        private BorderLabel _selectedLabel;
        private ICategory _selectedCategory;

        public ICategory SelectedCategory {
            get => _selectedCategory;
            private set
            {
                _selectedCategory = value;
                OnSelectionChanged(this, EventArgs.Empty);
            }
        }

        private ICategory _rootCategory;
        private ICategory _currentCategory;

        public ICategory RootCategory
        {
            get => _rootCategory;
            set {
                _rootCategory = value;
                Refresh();
            }
        }

        public Style Style
        {
            set => this.ApplyStyle(value);
        }

        public int ItemToShow
        {
            get => _itemToShow;
            set
            {
                #region Precondizioni
                if (value <= 0)
                    throw new ArgumentException("item to show <= 0");
                #endregion
                _itemToShow = value;
                Size = new Size(_width, ItemToShow * _itemHeight);
            }
        }

        #region Costruttori
        public CategoryPicker
            (ICategory root, int width = DEFAULT_WIDTH, int itemToShow = DEFAULT_ITEM_TO_SHOW,
            int itemHeight = DEFAULT_ITEM_HEIGHT, Style style = null)
        {
            #region Precondizioni
            if (width < 0 || itemToShow < 1 || itemHeight < 0)
                throw new ArgumentException("width, itemToShow o itemHeight illegali");
            #endregion
            InitializeComponent();
            root.Changed += CategoryChangedHandler;
            _itemHeight = itemHeight;
            ItemToShow = itemToShow;
            _width = width;
            _style = style;
            this.ApplyStyle(style);
            _flowPanel.HorizontalScroll.Visible = false;
            _flowPanel.HorizontalScroll.Enabled = false;
            _flowPanel.AutoSize = false;
            Size = new Size(width, itemHeight * ItemToShow);
            RootCategory = root;
        }

        public CategoryPicker(ICategory root) : 
            this(root, DEFAULT_WIDTH, DEFAULT_ITEM_TO_SHOW) { }

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
            bl.Size = new Size(_flowPanel.Width - SystemInformation.VerticalScrollBarWidth, _itemHeight);
            bl.Location = new Point(0, DEFAULT_ITEM_HEIGHT * itemNumber);
            bl.Style = _style;
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
            if (_selectedLabel == null)
                return;
            _selectedLabel.BackColor = Color.Black;
            _selectedLabel.BackColorHover = Color.Black;
            _selectedLabel = null;
            SelectedCategory = null;
        }

        private void Select(BorderLabel bl)
        {
            bl.BackColor = Color.Blue;
            bl.BackColorHover = Color.Blue;
            _selectedLabel = bl;
            SelectedCategory = bl.Tag as ICategory;
        }



        #region Handler
        private void OnSelectionChanged(Object sender, EventArgs args)
            => SelectionChanged?.Invoke(sender, args);

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
