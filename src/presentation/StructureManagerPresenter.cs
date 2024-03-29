﻿using CSB_Project.src.business;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CSB_Project.src.presentation
{
    public class StructureManagerPresenter
    {
        private TreeView _structureTree;
        private IEnumerable<Structure> _structures;
        private IBookingCoordinator _bCoordinator;
        private IPrenotationCoordinator _pCoordinator;
        private IItemCoordinator _iCoordinator;
        private DateTimePicker _fromDateBox;
        private DateTimePicker _toDateBox;
        private AuthorizationLevel _level;
        private StructureManagerView _view;

        public StructureManagerPresenter(StructureManagerView view)
        {
            _view = view;
            view.AddButton.Click += AddHandler;
            _structureTree = view.TreeView;
            _structureTree.AfterSelect += ItemSelectedHandler;
            IStructureCoordinator sCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IStructureCoordinator>();
            if (sCoordinator == null)
                throw new InvalidOperationException("Il coordinatore delle strutture non è disponibile");

            _bCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IBookingCoordinator>();
            if (_bCoordinator == null)
                throw new InvalidOperationException("Il coordinatore deli Bookable Items non è disponibile");

            _pCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
            if (_bCoordinator == null)
                throw new InvalidOperationException("Il coordinatore delle prenotations non è disponibile");

            _iCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IItemCoordinator>();
            if (_bCoordinator == null)
                throw new InvalidOperationException("Il coordinatore degli items non è disponibile");

            _structures = sCoordinator.Structures;
            sCoordinator.StructureChanged += StructureChangedHandler;

            _fromDateBox = view.FromDate;
            _toDateBox = view.ToDate;

            _fromDateBox.ValueChanged += DateChanged;

            try
            {
                _level = view.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel");
            }
            catch ( Exception e)
            {
                //Chiave non disponibile o cast non riuscito
            }
            view.AddButton.Enabled = false;
            view.ModifyButton.Enabled = false;
            view.DeleteButton.Enabled = false;
            // Popolo la tree view all'avvio
            DateChanged(this, EventArgs.Empty);
        }

        #region Metodi
        /// <summary>
        /// Popola la tree view partendo dalle strutture esistenti
        /// </summary>
        /// <param name="nodes">Nodo a cui aggiungere i nuovi nodi</param>
        /// <param name="structures">Strutture con cui popolare i nodi</param>
        public void Populate(TreeNodeCollection nodes, IEnumerable<Structure> structures, DateRange range)
        {
            foreach (Structure structure in structures)
            {
                TreeNode tnStructure = new TreeNode(structure.ToString());
                tnStructure.Tag = structure;
                foreach (StructureArea area in structure.Areas)
                {
                    TreeNode tnArea = new TreeNode(area.ToString());
                    tnArea.Tag = area;
                    foreach (Sector sector in area.Sectors)
                    {
                        TreeNode tnSector = new TreeNode(sector.ToString());
                        tnSector.Tag = sector;
                        Populate(tnSector,range);
                        tnArea.Nodes.Add(tnSector);
                    }
                    tnStructure.Nodes.Add(tnArea);
                }
                nodes.Add(tnStructure);
            }
        }

        private void Populate(TreeNode tnSector, DateRange range)
        {
            Sector sector = tnSector.Tag as Sector;
            for (int i = 1; i <= sector.Rows; i++)
            {
                TreeNode tnRow = new TreeNode("Riga " + i);
                tnRow.Tag = i;
                for (int j = 1; j <= sector.Columns; j++)
                {
                    Position positionToAdd = new Position(i, j);
                    IBookableItem item = _bCoordinator.GetBookableItem(sector, positionToAdd);
                    TreeNode tnBookableItem;

                    if (item == null)
                    {
                        tnBookableItem = new TreeNode(j + " - nessun elemento");
                        tnBookableItem.Tag = null;
                    }
                    else
                    {
                        string status = "Occupato";
                        Color color = Color.Red;
                        bool available = _pCoordinator.IsAvailable(sector, positionToAdd, range);
                        if (available)
                        {
                            status = "Libero";
                            color = Color.Green;
                        }
                        tnBookableItem = new TreeNode(j + " - " + status + " - " + item.ToString());
                        tnBookableItem.ForeColor = color;
                        tnBookableItem.Tag = item;
                        foreach (IItem plugin in _iCoordinator.GetAssociableItemOf(item.BaseItem))
                        {
                            TreeNode tnPluginItem = new TreeNode("Plugin - " + plugin.FriendlyName + "(+€" + plugin.DailyPrice + ")");
                            tnPluginItem.ForeColor = color;
                            tnPluginItem.Tag = plugin;
                            tnBookableItem.Nodes.Add(tnPluginItem);
                        }
                    }
             
                    tnRow.Nodes.Add(tnBookableItem);
                }
                tnSector.Nodes.Add(tnRow);
            }
        }
        #endregion 

        #region Handler
        /// <summary>
        /// Gestisce l'azione dell'add button permettendo l'inserimento di una
        /// nuova categoria
        /// </summary>
        private void AddHandler(Object sender, EventArgs eventArgs)
        {
            if (_structureTree.SelectedNode != null)
            {
                Object selectedItem = _structureTree.SelectedNode.Tag;
                string text = _structureTree.SelectedNode.Text;
                if (selectedItem == null && text.Contains("nessun elemento"))
                {
                    IItem baseItem = null;
                    Position position = new Position((int)_structureTree.SelectedNode.Parent.Tag, _structureTree.SelectedNode.Index + 1);
                    Sector sector = _structureTree.SelectedNode.Parent.Parent.Tag as Sector;
                    using (SelectItemDialog sd = new SelectItemDialog())
                    {
                        sd.LoadItems(_iCoordinator.BaseItems);
                        if (sd.ShowDialog() == DialogResult.OK)
                        {
                            baseItem = sd.SelectedItem;
                        }
                        else
                            return;
                    }
                    if (baseItem != null)
                    {
                        IBookableItem bookItem = new SectorBookableItem(baseItem, position, sector);
                        _bCoordinator.AddBookableItem(bookItem);
                        StructureChangedHandler(this, EventArgs.Empty);
                    }
                }
                else
                {
                    //non si può aggiungere
                }
            }
            
        }

        private void ModifyHandler(Object sender, EventArgs eventArgs)
        {
            
        }

        public void ItemSelectedHandler(Object sender, EventArgs eventArgs)
        {
            Object selectedItem = _structureTree.SelectedNode.Tag;
            string text = _structureTree.SelectedNode.Text;
            if (selectedItem == null && text.Contains("nessun elemento"))
            {
                if (_level == AuthorizationLevel.ADVANCED_STAFF)
                {
                    _view.AddButton.Enabled = true;
                    _view.ModifyButton.Enabled = true;
                    _view.DeleteButton.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Gestisce l'evento aggiornamento delle categorie ripopolando 
        /// la tree view
        /// </summary>
        public void StructureChangedHandler(Object obj, EventArgs e)
        {
            _structureTree.Nodes.Clear();
            DateRange dr = new DateRange(_fromDateBox.Value, _toDateBox.Value);
            Populate(_structureTree.Nodes,_structures, dr);
            _structureTree.ExpandAll();
        }
        
        public void DateChanged(Object obj, EventArgs e)
        {
            _structureTree.Nodes.Clear();
            DateRange dr = new DateRange(_fromDateBox.Value, _toDateBox.Value);
            Populate(_structureTree.Nodes,_structures, dr);
            _structureTree.ExpandAll();
        }
        #endregion
    }
}

