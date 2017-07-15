using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;
using CSB_Project.src.business;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.Services;

namespace CSB_Project.src.presentation
{
    public partial class AddPrenotationDialog : Form
    {
        #region Campi
        private IUserCoordinator _uCoord = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();
        private IPrenotationCoordinator _pCoord = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
        private AuthorizationLevel _level;
        private ILoginInformation _loginInfo;
        private ICustomer _customer;
        private List<ICustomizableItemPrenotation> _itemsPrenotation;
        private List<Bundle> _bundles;
        #endregion

        #region Proprietà
        #endregion

        #region Costruttori
        public AddPrenotationDialog()
        {
            InitializeComponent();
            //_level = this.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel");
            //if (_level == AuthorizationLevel.CUSTOMER)
            //{
            //    _loginInfo = this.RetrieveTagInformation<ILoginInformation>("loginInformation");
            //    _customer = (from u in _uCoord.RegisteredUsers
            //                 where (u is ICustomer && u.Username.Equals(_loginInfo.Username))
            //                 select u as ICustomer).First();
            //    _clientComboBox.Items.Add(_customer);
            //    _clientComboBox.Enabled = false;
            //}
            //else
            //{
                _clientComboBox.DataSource = _uCoord.Customers;
            //}
            _itemsPrenotation = new List<ICustomizableItemPrenotation>();
            
        }

        #endregion

        #region metodi
        #endregion

        #region Handlers
        public void AddItemPrenotationButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (AddItemPrenotationDialog sd = new AddItemPrenotationDialog(range))
            {
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    ICustomizableItemPrenotation itemPrenotation = sd.SelectedItem;
                    if (itemPrenotation != null)
                    {
                        _itemsPrenotation.Add(itemPrenotation);
                        _itemPrenotationListView.Items.Add(itemPrenotation.InformationString);
                    }

                }
                else
                    return;
            }
        }
        public void AddBundlesButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (SelectionBundle sb = new SelectionBundle())
            {
                if (sb.ShowDialog() == DialogResult.OK)
                {
                    

                }
                else
                    return;
            }
        }
        public void AddPacketsButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (SelectionPacket sp = new SelectionPacket())
            {
                if (sp.ShowDialog() == DialogResult.OK)
                {


                }
                else
                    return;
            }
        }
        #endregion
    }
}
