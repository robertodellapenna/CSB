using CSB_Project.src.business;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Item;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CSB_Project.src.presentation.ItemCreator
{
    public class CategorizableItemCreatorPresenter
    {
        private Func<XmlNode, bool> _addItemDelegate;
        private BasicItemControl _bic;
        private Button _addButton;

        private const int PICTURE_INDEX = 0;
        private const int CATPICKER_INDEX = 1;
        private const int CATVALUE_INDEX = 2;
        private const int CATDESC_INDEX = 3;
        private const int PRICE_INDEX = 4;
        private const int IMAGE_SIZE = 64;
        private const int DEFAULT_WIDTH = 120;
        private int _width;
        private ICategory _root;
        private TableLayoutPanel _tableLayout;

        public CategorizableItemCreatorPresenter(CategorizableItemCreatorView view, Func<XmlNode, bool> addItemDelegate, Func<IEnumerable<IItem>> items)
        {
            ICategoryCoordinator coord;
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (addItemDelegate == null)
                throw new ArgumentNullException("addItemDelegate null");
            if (items == null)
                throw new ArgumentNullException("items null");
            coord = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
            if (coord == null)
                throw new InvalidOperationException("non è disponibile un coordinatore delle categorie");
            #endregion
            
            _addItemDelegate = addItemDelegate;
            _tableLayout = view.TableLayout;
            _root = coord.RootCategory;

            new BasicControlPresenter(view.Control, items);
            _addItemDelegate = addItemDelegate;
            _bic = view.Control;
            _addButton = view.AddButton;
            _addButton.BackColor = SystemColors.Control;
            _addButton.Click += AddButtonHandler;
            _bic.FriendlyNameBox.TextChanged += (obj, e) => CheckButtonStatus();
            _bic.DescriptionBox.TextChanged += (obj, e) => CheckButtonStatus();
            _bic.IdentifierBox.TextChanged += (obj, e) => CheckButtonStatus();
            
             _width = DEFAULT_WIDTH;
            // Init tabella 
            Style style = new Style();
            style.Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
            int freeSpace = _tableLayout.Width - IMAGE_SIZE - DEFAULT_WIDTH;
            // image - categoryPicker - value - desc - prezzo
            _tableLayout.ColumnStyles.Clear();
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, IMAGE_SIZE));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, DEFAULT_WIDTH));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Convert.ToInt32(freeSpace * 0.3)));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Convert.ToInt32(freeSpace * 0.4)));
            _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Convert.ToInt32(freeSpace * 0.3) - SystemInformation.VerticalScrollBarWidth));
            _tableLayout.ColumnCount = _tableLayout.ColumnStyles.Count;
            _tableLayout.RowCount = 1;
            _tableLayout.Controls.Add(new BorderLabel("", Color.White, Color.White, Color.White, 0, style));
            _tableLayout.Controls.Add(new BorderLabel("Scegli la categoria", Color.Black, Color.White, Color.White, 0, style));
            _tableLayout.Controls.Add(new BorderLabel("Valore", Color.Black, Color.White, Color.White, 0, style));
            _tableLayout.Controls.Add(new BorderLabel("Descrizione", Color.Black, Color.White, Color.White, 0, style));
            _tableLayout.Controls.Add(new BorderLabel("Prezzo", Color.Black, Color.White, Color.White, 0, style));

            AddCategoryInput(removable: false, addable: true);
            CheckButtonStatus();
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
            TextBox value = new TextBox();
            TextBox desc = new TextBox();
            NumericUpDown price = new NumericUpDown();
            
            cp.SelectionChanged += (obj, e) => CheckButtonStatus();

            //name init per rimozione successiva
            pb.Name = "pb" + _tableLayout.RowCount;
            value.Name = "val" + _tableLayout.RowCount;
            cp.Name = "cp" + _tableLayout.RowCount;
            desc.Name = "desc" + _tableLayout.RowCount;
            price.Name = "price" + _tableLayout.RowCount;

            //picture init 
            if (removable)
            {
                pb.Image = new Bitmap(Image.FromFile("../../Icon/remove.png"), new Size(64, 64));
                pb.Tag = new string[] { cp.Name, desc.Name, pb.Name, price.Name, value.Name };
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
            pb.Click += (obj,e ) => CheckButtonStatus();

            //value init
            value.Margin = new Padding(0);
            value.Size = new Size(Convert.ToInt32(_tableLayout.ColumnStyles[CATVALUE_INDEX].Width), cp.Height);
            value.Anchor = AnchorStyles.None;
            value.TextAlign = HorizontalAlignment.Center;
            value.MaxLength = 40;
            value.TextChanged += (obj, e) => CheckButtonStatus();
            //desc init
            desc.Margin = new Padding(0);
            desc.Size = new Size(Convert.ToInt32(_tableLayout.ColumnStyles[CATDESC_INDEX].Width), cp.Height);
            desc.Anchor = AnchorStyles.None;
            desc.TextAlign = HorizontalAlignment.Center;
            desc.Multiline = true;
            desc.MaxLength = 100;
            desc.TextChanged += (obj, e) => CheckButtonStatus();
            //price init
            price.Margin = new Padding(0);
            price.DecimalPlaces = 2;
            price.TextAlign = HorizontalAlignment.Center;
            price.Size = new Size(Convert.ToInt32(_tableLayout.ColumnStyles[PRICE_INDEX].Width), cp.Height);
            price.Anchor = AnchorStyles.None;

            //aggiungo i controlli
            _tableLayout.Controls.Add(pb);
            _tableLayout.Controls.Add(cp);
            _tableLayout.Controls.Add(value);
            _tableLayout.Controls.Add(desc);
            _tableLayout.Controls.Add(price);
        }

        private CategoryPicker CreateCategoryPicker()
        {
            Style s = new Style();
            s.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            return new CategoryPicker(_root, _width, itemToShow: 2, itemHeight: 30, style: s);
        }

        private void AddRowHandler(Object obj, EventArgs e)
        {
            foreach (TextBox tb in _tableLayout.Controls.OfType<TextBox>())
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


            if (controls.Count() % _tableLayout.ColumnCount != 0)
                throw new InvalidOperationException("il numero di contorlli non va bene");

            //copio l'header
            for (int i = 0; i < _tableLayout.ColumnCount; i++)
                _tableLayout.Controls.Add(controls[i]);
            _tableLayout.RowCount = 1;

            for (int i = _tableLayout.ColumnCount; i < controls.Count(); i += _tableLayout.ColumnCount)
            {
                if (controlToRemove.Contains(controls[i].Name))
                    //controlli da rimuovere
                    continue;

                //setto i nomi
                controls[i + PICTURE_INDEX].Name = "pb" + _tableLayout.RowCount;
                controls[i + CATPICKER_INDEX].Name = "cp" + _tableLayout.RowCount;
                controls[i + CATVALUE_INDEX].Name = "val" + _tableLayout.RowCount;
                controls[i + CATDESC_INDEX].Name = "desc" + _tableLayout.RowCount;
                controls[i + PRICE_INDEX].Name = "price" + _tableLayout.RowCount;
                //aggiunto i controlli
                _tableLayout.Controls.Add(controls[i + PICTURE_INDEX]);
                _tableLayout.Controls.Add(controls[i + CATPICKER_INDEX]);
                _tableLayout.Controls.Add(controls[i + CATVALUE_INDEX]);
                _tableLayout.Controls.Add(controls[i + CATDESC_INDEX]);
                _tableLayout.Controls.Add(controls[i + PRICE_INDEX]);

                controls[i].Tag = new string[] {controls[i+PICTURE_INDEX].Name, controls[i+CATPICKER_INDEX].Name, controls[i+CATVALUE_INDEX].Name,
                    controls[i+CATDESC_INDEX].Name, controls[i+PRICE_INDEX].Name };
                _tableLayout.RowCount++;
            }
        }

        private void CheckButtonStatus()
        {
            bool enable = true;
            for(int i=_tableLayout.ColumnCount; i<_tableLayout.Controls.Count; i+=_tableLayout.ColumnCount)
            {
                if ( (_tableLayout.Controls[i + CATPICKER_INDEX] as CategoryPicker).SelectedCategory == null
                     || String.IsNullOrWhiteSpace((_tableLayout.Controls[i + CATDESC_INDEX] as TextBox).Text)
                     || String.IsNullOrWhiteSpace((_tableLayout.Controls[i + CATVALUE_INDEX] as TextBox).Text))
                {
                    enable = false;
                    break;
                }
            }

            _addButton.Enabled = enable && _bic.ErrorProvider.GetError(_bic.IdentifierBox) == ""
            && _bic.ErrorProvider.GetError(_bic.DescriptionBox) == ""
            && _bic.ErrorProvider.GetError(_bic.FriendlyNameBox) == "";
        }

        private void AddButtonHandler(Object sender, EventArgs e)
        {
            // Genero un xml node con la struttura dell'item da inserire
            StringBuilder br = new StringBuilder();
            br.AppendLine("<Items>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+CategorizableParser</Class>");
            br.AppendLine("    <Identifier>" + _bic.IdentifierBox.Text +"</Identifier>");
            br.AppendLine("    <Name>" + _bic.FriendlyNameBox.Text + "</Name>");
            br.AppendLine("    <Description>" + _bic.DescriptionBox.Text + "</Description>");
            br.AppendLine("    <Price>" + _bic.PriceBox.Text + "</Price>");

            for (int i = _tableLayout.ColumnCount; i < _tableLayout.Controls.Count; i += _tableLayout.ColumnCount)
            {
                br.AppendLine("    <Category>");
                br.AppendLine("      <Path>" + (_tableLayout.Controls[i+CATPICKER_INDEX] as CategoryPicker).SelectedCategory.Path+"</Path>");
                br.AppendLine("      <Name>" + (_tableLayout.Controls[i + CATVALUE_INDEX] as TextBox).Text + "</Name>");
                br.AppendLine("      <Description>" + (_tableLayout.Controls[i + CATDESC_INDEX] as TextBox).Text + "</Description>");
                br.AppendLine("      <Price>" + (_tableLayout.Controls[i + PRICE_INDEX] as NumericUpDown).Text + "</Price>");
                br.AppendLine("    </Category>");
            }
            br.AppendLine("  </Item>");
            br.AppendLine("</Items>");

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(br.ToString());
            XmlElement root = xml.DocumentElement;
            XmlNodeList xnl = root.SelectNodes("/Items/Item");
            if (_addItemDelegate(xnl[0]))
            {
                _bic.IdentifierBox.Text = "";
                _bic.FriendlyNameBox.Text = "";
                _bic.DescriptionBox.Text = "";
                _bic.PriceBox.Value = 0;
                MessageBox.Show("Item aggiunto correttamente");
            }
            else
                MessageBox.Show("Item non aggiunto al sistema, uno o più campi non validi");
        }
    }
}
