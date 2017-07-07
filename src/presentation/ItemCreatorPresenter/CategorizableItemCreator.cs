using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;
using CSB_Project.src.business;
using CSB_Project.src.model.Category;

namespace CSB_Project.src.presentation.ItemCreatorPresenter
{
    public partial class CategorizableItemCreator : UserControl
    {
        private const int PICTURE_INDEX = 0;
        private const int CATPICKER_INDEX = 1;
        private const int DESC_INDEX = 2;
        private const int PRICE_INDEX = 3;
        private const int IMAGE_SIZE = 64;
        private const int DEFAULT_WIDTH = 120;
        private int _width;
        private ICategory _root;

        public CategorizableItemCreator()
        {
            #region Precondizioni
            ICategoryCoordinator coord = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
            if (coord == null)
                throw new InvalidOperationException("non è disponibile un coordinatore delle categorie");
            #endregion
            _root = coord.RootCategory;

            InitializeComponent();
            _width = DEFAULT_WIDTH;
            // Init tabella 
            Style style = new Style();
            style.Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
            int freeSpace = _tableLayout.Width - IMAGE_SIZE - DEFAULT_WIDTH;
            // image - categoryPicker - desc - prezzo
            _tableLayout.ColumnStyles.Clear();
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, IMAGE_SIZE));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, DEFAULT_WIDTH));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Convert.ToInt32(freeSpace*0.65)));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Convert.ToInt32(freeSpace * 0.35)- SystemInformation.VerticalScrollBarWidth)); 
            _tableLayout.RowCount = 1;
            _tableLayout.Controls.Add(new BorderLabel("", Color.White,Color.White, Color.White, 0,style));
            _tableLayout.Controls.Add(new BorderLabel("Scegli la categoria", Color.Black, Color.White, Color.White, 0, style));
            _tableLayout.Controls.Add(new BorderLabel("Descrizione", Color.Black, Color.White, Color.White, 0, style));
            _tableLayout.Controls.Add(new BorderLabel("Prezzo", Color.Black, Color.White, Color.White, 0, style));

            AddCategoryInput(removable : false, addable:true); 
        }

        private void AddCategoryInput(bool removable = true, bool addable = false)
        {
            #region Precondizioni
            if (removable && addable)
                throw new InvalidOperationException("non può essere sia removable e addable");
            #endregion
            _tableLayout.RowCount++;
            PictureBox pb = new PictureBox();
            CategoryPicker cp = CreateCategoryPicker();
            TextBox desc = new TextBox();
            NumericUpDown price = new NumericUpDown();

            //name init per rimozione successiva
            pb.Name = "pb" + _tableLayout.RowCount;
            cp.Name = "cp" + _tableLayout.RowCount;
            desc.Name = "desc" + _tableLayout.RowCount;
            price.Name = "price" + _tableLayout.RowCount;

            //picture init 
            if (removable)
            {
                pb.Image = new Bitmap(Image.FromFile("../../Icon/remove.png"), new Size(64, 64));
                pb.Tag = new string[] { cp.Name, desc.Name, pb.Name, price.Name };
                pb.Click += RemoveRowHandler;
            }
            if (addable)
            {
                pb.Image = new Bitmap(Image.FromFile("../../Icon/add.png"), new Size(64, 64));
                pb.Click += AddRowHandler;
            }
            pb.Anchor = AnchorStyles.None;
            pb.Margin = new Padding(0);
            pb.Size = new Size(IMAGE_SIZE, IMAGE_SIZE);

            //desc init
            desc.Margin = new Padding(0);
            desc.Size = new Size(Convert.ToInt32(_tableLayout.ColumnStyles[DESC_INDEX].Width), cp.Height);
            desc.Anchor = AnchorStyles.None;
            desc.TextAlign = HorizontalAlignment.Center;
            desc.Multiline = true;
            desc.MaxLength = 100;
            //price init
            price.Margin = new Padding(0);
            price.DecimalPlaces = 2;
            price.TextAlign = HorizontalAlignment.Center;
            price.Size = new Size(Convert.ToInt32(_tableLayout.ColumnStyles[PRICE_INDEX].Width), cp.Height);
            price.Anchor = AnchorStyles.None;

            //aggiungo i controlli
            _tableLayout.Controls.Add(pb);
            _tableLayout.Controls.Add(cp);
            _tableLayout.Controls.Add(desc);
            _tableLayout.Controls.Add(price);
        }

        private CategoryPicker CreateCategoryPicker()
        {
            Style s = new Style();
            s.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            return new CategoryPicker(_root, _width, itemToShow: 2, itemHeight: 30, style : s);
        }

        private void AddRowHandler(Object obj, EventArgs e)
        {
            foreach(TextBox tb in _tableLayout.Controls.OfType<TextBox>())
            {
                if (tb.Text == "")
                {
                    MessageBox.Show("Hai ancora una categoria da riempire");
                    return;
                }
            }
            AddCategoryInput();                
        }

        private void RemoveRowHandler(Object obj, EventArgs e)
        {
            if (!(obj is PictureBox))
                return;

            string[] controlToRemove = ((obj as Control).Tag) as string[];
            Control[] controls = new Control[_tableLayout.Controls.Count];
            _tableLayout.Controls.CopyTo(controls, 0);
            _tableLayout.Controls.Clear();
            
            
            if(controls.Count() % _tableLayout.ColumnCount != 0)
                throw new InvalidOperationException("il numero di contorlli non va bene");

            //copio l'header
            for (int i = 0; i < _tableLayout.ColumnCount; i++)
                _tableLayout.Controls.Add(controls[i]);
            _tableLayout.RowCount = 1;

            for (int i=_tableLayout.ColumnCount; i<controls.Count(); i+=_tableLayout.ColumnCount)
            {
                if (controlToRemove.Contains(controls[i].Name))
                    //controlli da rimuovere
                    continue;

                //setto i nomi
                controls[i + PICTURE_INDEX].Name = "pb" + _tableLayout.RowCount;
                controls[i + CATPICKER_INDEX].Name = "cp" + _tableLayout.RowCount;
                controls[i + DESC_INDEX].Name = "desc" + _tableLayout.RowCount;
                controls[i + PRICE_INDEX].Name = "price" + _tableLayout.RowCount;
                //aggiunto i controlli
                _tableLayout.Controls.Add(controls[i+PICTURE_INDEX]);
                _tableLayout.Controls.Add(controls[i+CATPICKER_INDEX]);
                _tableLayout.Controls.Add(controls[i+DESC_INDEX]);
                _tableLayout.Controls.Add(controls[i+PRICE_INDEX]);

                controls[i].Tag = new string[] {controls[i+PICTURE_INDEX].Name, controls[i+CATPICKER_INDEX].Name,
                    controls[i+DESC_INDEX].Name, controls[i+PRICE_INDEX].Name };
                _tableLayout.RowCount++;
            }
        }
    }
}
