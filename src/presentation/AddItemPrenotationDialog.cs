using CSB_Project.src.business;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public partial class AddItemPrenotationDialog : Form
    {
        #region Campi
        private ICustomizableItemPrenotation _itemPrenotation;
        private IStructureCoordinator _sCoord = CoordinatorManager.Instance.CoordinatorOfType<IStructureCoordinator>();
        private IItemCoordinator _iCoord = CoordinatorManager.Instance.CoordinatorOfType<IItemCoordinator>();
        private DateRange _range;
        #endregion

        #region Proprietà
        public ICustomizableItemPrenotation SelectedItem => _itemPrenotation;
        #endregion

        public AddItemPrenotationDialog(DateRange range)
        {
            InitializeComponent();
            _addBookableItemButton.Enabled = true;
            _addPluginItemButton.Enabled = false;
            _range = range;
            _fromDateTimePicker.Enabled = false;
            _toDateTimePicker.Enabled = false;
        }

        #region Handlers
        public void AddBookableItemButtonHandler(Object obj, EventArgs e)
        {
            using (SelectBookableItemDialog sd = new SelectBookableItemDialog(_range))
            {
                sd.LoadStructures(_sCoord.Structures);
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    IBookableItem bookableItem = sd.SelectedItem;
                    if (bookableItem != null)
                    {
                        _itemPrenotation = new CustomizableItemPrenotation(sd.Range, sd.SelectedItem);
                        _addBookableItemButton.Text = "Cambia elemento prenotabile";
                        _addPluginItemButton.Enabled = true;
                        Sector sector = _itemPrenotation.BaseItem.Sector;
                        Structure structure = null;
                        StructureArea area = null;
                        foreach (Structure s in _sCoord.Structures)
                            foreach (StructureArea a in s.Areas)
                                if (a.Sectors.Contains(sector))
                                {
                                    structure = s;
                                    area = a;
                                    break;
                                }
                        _locationLabelValue.Text = structure.ToString() + " - " + area.ToString() + " - " + sector.ToString();
                        _itemLabelValue.Text = _itemPrenotation.BaseItem.ToString();
                        _positionLabelValue.Text = _itemPrenotation.BaseItem.Position.ToString();
                        _rangeLabelValue.Text = _itemPrenotation.RangeData.StartDate.ToShortDateString() + " - " + _itemPrenotation.RangeData.EndDate.ToShortDateString();
                        _fromDateTimePicker.Enabled = true;
                        _fromDateTimePicker.Value = _itemPrenotation.RangeData.StartDate;
                        _toDateTimePicker.Enabled = true;
                        _toDateTimePicker.Value = _itemPrenotation.RangeData.EndDate;
                    }
                  
                }
                else
                    return;
            }
        }
        public void AddPluginItemButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (SelectItemDialog sd = new SelectItemDialog())
            {
                sd.LoadItems(_iCoord.GetAssociableItemOf(SelectedItem.BaseItem.BaseItem) as IEnumerable<AbstractItem>);
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    IItem plugin= sd.SelectedItem;
                    if (plugin != null)
                    {
                        _itemPrenotation.AddPlugin(plugin, range);
                        _pluginListView.Items.Add(plugin.FriendlyName + " (" + range.StartDate.ToShortDateString() +" - " + range.EndDate.ToShortDateString()+")");
                    }
                    
                }
                else
                    return;
            }
        }
        public void FromDateChangedHandler(Object obj, EventArgs e)
        {
            if (_fromDateTimePicker.Value < _itemPrenotation.RangeData.StartDate)
            {
                //MessageBox.Show("Data oltre il range della tua prenotazione");
                _fromDateTimePicker.Value = _itemPrenotation.RangeData.StartDate;
            }
            if (_fromDateTimePicker.Value > _toDateTimePicker.Value)
            {
                //MessageBox.Show("Range inconsistente");
                _fromDateTimePicker.Value = _itemPrenotation.RangeData.StartDate;
            }

        }
        public void ToDateChangedHandler(Object obj, EventArgs e)
        {
            if (_toDateTimePicker.Value > _itemPrenotation.RangeData.EndDate)
            {
                //MessageBox.Show("Data oltre il range della tua prenotazione");
                _toDateTimePicker.Value = _itemPrenotation.RangeData.EndDate;
            }
            if (_toDateTimePicker.Value < _fromDateTimePicker.Value)
            {
                //MessageBox.Show("Range inconsistente");
                _toDateTimePicker.Value = _itemPrenotation.RangeData.EndDate;
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
