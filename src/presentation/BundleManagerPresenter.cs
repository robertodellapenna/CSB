﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.business;
using CSB_Project.src.model.Services;

namespace CSB_Project.src.presentation
{
    public class BundleManagerPresenter
    {
        private ListView _bundleList;
        private IEnumerable<IBundle> _bundles;
        IServiceCoordinator coordinator;

        public BundleManagerPresenter(BundleManagerView view)
        {
            view.AddButton.Click += AddHandler;
            _bundleList = view.ListView;
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore dei bundle non è disponibile");

            _bundles = coordinator.Bundles;
            coordinator.ServiceChanged += ServiceChangedHandler;
            // Popolo la list view all'avvio
            ServiceChangedHandler(this, EventArgs.Empty);
        }

        #region Metodi
        #endregion 

        #region Handler
        /// <summary>
        /// Gestisce l'azione dell'add button permettendo l'inserimento di una
        /// nuova categoria
        /// </summary>
        private void AddHandler(Object sender, EventArgs eventArgs)
        {
            /* NON PER IL PROTOTIPO
            */
        }

        private void ModifyHandler(Object sender, EventArgs eventArgs)
        {
            /* PROBABILMENTE NON VA FATTO */
        }

        /// <summary>
        /// Gestisce l'evento aggiornamento dei servizi ripopolando 
        /// la list view
        /// </summary>
        public void ServiceChangedHandler(Object obj, EventArgs e)
        {
            _bundleList.Items.Clear();
            foreach (IBundle bundle in _bundles)
            {
                string[] array = new string[4];
                string pacchetti = "";
                ListViewItem items = null;
                array[0] = bundle.Name;
                array[1] = bundle.Description;
                array[2] = bundle.Price + "";
                for (int i = 0; i < bundle.Packets.Count - 1; i++)
                {
                    pacchetti = pacchetti + bundle.Packets.ElementAt(i).Name + " - ";
                }
                pacchetti = pacchetti + bundle.Packets.ElementAt(bundle.Packets.Count - 1).Name;
                array[3] = pacchetti;
                items = new ListViewItem(array);
                _bundleList.Items.Add(items);
            }
            _bundleList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _bundleList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            #endregion
        }
    }
}