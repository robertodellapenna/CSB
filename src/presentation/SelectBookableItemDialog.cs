using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Booking;
using CSB_Project.src.business;
using CSB_Project.src.model.Utils;
using System.Drawing;

namespace CSB_Project.src.presentation
{
    public partial class SelectBookableItemDialog : Form
    {

        #region Campi
        private IBookingCoordinator _bCoord = CoordinatorManager.Instance.CoordinatorOfType<IBookingCoordinator>();
        private IPrenotationCoordinator _pCoord = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
        private DateRange _range;
        private bool init = false;
        #endregion

        #region Proprietà
        public Structure SelectedStructure => _comboBoxStructure.SelectedItem as Structure;
        public StructureArea SelectedArea => _comboBoxArea.SelectedItem as StructureArea;
        public Sector SelectedSector => _comboBoxSector.SelectedItem as Sector;
        public int SelectedRow => (int)_comboBoxRow.SelectedItem;
        public int SelectedColumn => (int)_comboBoxColumn.SelectedItem;
        public IBookableItem SelectedItem
        {
            get
            {
                Object result = _labelItemValue.Tag;
                if (result == null)
                    return null;
                return result as SectorBookableItem;
            }
        }
        public DateTime From => _dateTimePickerDa.Value;
        public DateTime To => _dateTimePickerA.Value;
        public DateRange Range => new DateRange(From, To);
        #endregion

        #region Costruttori
        public SelectBookableItemDialog(DateRange range)
        {
            InitializeComponent();
            _range = range;
            _dateTimePickerDa.Value = _range.StartDate;
            _dateTimePickerA.Value = _range.EndDate;
        }
        #endregion

        #region metodi
        public void LoadStructures(IEnumerable<Structure> structures)
        {
            if (!init)
                init = true;
            _comboBoxStructure.DataSource = structures;
        }

        private void LoadAreas(IEnumerable<StructureArea> areas)
        {
            _comboBoxArea.DataSource = areas;
        }

        private void LoadSectors(IEnumerable<Sector> sectors)
        {
            _comboBoxSector.DataSource = sectors;
        }

        private void LoadRows(int rows)
        {
            List<int> rowsString = new List<int>();
            for (int i = 1; i <= rows; i++)
                rowsString.Add(i);
            _comboBoxRow.DataSource = rowsString;
        }

        private void LoadColumns(int cols)
        {
            List<int> colsString = new List<int>();
            for (int i = 1; i <= cols; i++)
                colsString.Add(i);
            _comboBoxColumn.DataSource = colsString;
        }
     

        #endregion

        #region Handlers
        public void DateFromChangedHandler(Object obj, EventArgs e)
        {
            if(_dateTimePickerDa.Value < _range.StartDate)
            {
                //MessageBox.Show("Data oltre il range della tua prenotazione");
                _dateTimePickerDa.Value = _range.StartDate;
            }
            if ( _dateTimePickerDa.Value > _dateTimePickerA.Value)
            {
                //MessageBox.Show("Range inconsistente");
                _dateTimePickerDa.Value = _range.StartDate;
            }
            if(init)
                SelectedStructureHandler(this, EventArgs.Empty);
        }
        public void DateToChangedHandler(Object obj, EventArgs e)
        {
            if (_dateTimePickerA.Value >  _range.EndDate)
            {
                //MessageBox.Show("Data oltre il range della tua prenotazione");
                _dateTimePickerA.Value = _range.EndDate;
            }
            if (_dateTimePickerA.Value < _dateTimePickerDa.Value)
            {
                //MessageBox.Show("Range inconsistente");
                _dateTimePickerA.Value = _range.EndDate;
            }
            if(init)
                SelectedStructureHandler(this, EventArgs.Empty);
        }
        public void SelectedStructureHandler(Object obj, EventArgs e)
        {
            LoadAreas(SelectedStructure.Areas);
        }
        public void SelectedAreaHandler(Object obj, EventArgs e)
        {
           LoadSectors(SelectedArea.Sectors);
        }
        public void SelectedSectorHandler(Object obj, EventArgs e)
        {
            LoadRows(SelectedSector.Rows);
        }
        public void SelectedRowHandler(Object obj, EventArgs e)
        {
            LoadColumns(SelectedSector.Columns);
        }
        public void SelectedColumnHandler(Object obj, EventArgs e)
        {
            Position position = new Position(SelectedRow, SelectedColumn);
            IBookableItem item = _bCoord.GetBookableItem(SelectedSector, position);
            if (item == null)
            {
                _labelItemValue.Text = "";
                _labelItemValue.Tag = null;
            }
            else
            {
                bool available = _pCoord.IsAvailable(SelectedSector, position, Range);
                if (available)
                {
                    _labelItemValue.Text = item.ToString();
                    _labelItemValue.ForeColor = Color.Green;
                    _labelItemValue.Tag = item;
                }
                else
                {
                    _labelItemValue.Text = item.ToString();
                    _labelItemValue.ForeColor = Color.Red;
                    _labelItemValue.Tag = null;
                }
            }
        }
        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if (SelectedItem == null)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

    }
}
