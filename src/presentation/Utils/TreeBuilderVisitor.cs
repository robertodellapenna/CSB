using System;
using System.Collections.Generic;
using System.Linq;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Prenotation;
using System.Windows.Forms;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.Services;

namespace CSB_Project.src.presentation.Utils
{
    public class TreeBuilderVisitor : IPrenotationVisitor
    {
        /// <summary>
        /// Nodo di primo livello che rappresenta la prenotazione complessiva
        /// </summary>
        private TreeNode _prenotationNode;

        /// <summary>
        /// Item prenotation che compongono la prenotazione. Costituiscono i nodi di livello 1
        /// </summary>
        private IDictionary<IItemPrenotation, TreeNode> _itemPrenotationNodes;
        /// <summary>
        /// Tutti gli item visitati durante la visita alla prenotazione
        /// </summary>
        private IDictionary<IItem, TreeNode> _itemNodes;
        /// <summary>
        /// Tutti i bookable item visitati durante la visita alla prenotazione
        /// </summary>
        private IDictionary<IBookableItem, TreeNode> _bookableNodes;

        public TreeBuilderVisitor()
        {
            Clear();
        }

        public void Clear()
        {
            _prenotationNode = new TreeNode();
            _itemPrenotationNodes = new Dictionary<IItemPrenotation, TreeNode>();
            _itemNodes = new Dictionary<IItem, TreeNode>();
            _bookableNodes = new Dictionary<IBookableItem, TreeNode>();
        }

        /// <summary>
        /// Restituisce un TreeNode contenente tutta la struttura delle prenotazione.
        /// Dopo aver recuperato il valore tutti i nodi vengono azzerati e bisogna
        /// effettuare nuovamente la visita
        /// </summary>
        public TreeNode TreeStructure
        {
            get
            {
                foreach (IItemPrenotation ip in _itemPrenotationNodes.Keys)
                {

                    if (_bookableNodes.ContainsKey(ip.BaseItem))
                    {
                        if (_itemNodes.ContainsKey(ip.BaseItem.BaseItem))
                            //Informazioni dettagliate sul bookable items
                            _itemPrenotationNodes[ip].Nodes.Add(_itemNodes[ip.BaseItem.BaseItem]);
                        else
                            //Non ho informazioni dettagliate
                            _itemPrenotationNodes[ip].Nodes.Add(_bookableNodes[ip.BaseItem]);
                    }

                    // In base al tipo di ItemPrenotation recupero i dettagli presenti
                    // Se non viene implementato il metodo CustomItemPrenotation per un 
                    // ItemPrenotation specifico viene utilizzato quello di default che non
                    // aggiunge informazioni
                    TreeNode[] details = CustomItemPrenotation(ip as dynamic);
                    if (details != null)
                    {
                        foreach(TreeNode n in details)
                            _itemPrenotationNodes[ip].Nodes.Add(n);
                    }
                    _prenotationNode.Nodes.Add(_itemPrenotationNodes[ip]);
                } // Fine ciclo sugli itemPrenotation

                TreeNode structure = _prenotationNode;
                Clear();
                return structure;
            }
        }

        #region CustomBuilder

        #region ItemPrenotation
        /// <summary>
        /// CustomPrenotation di default, non aggiunge nessun dettaglio
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>null</returns>
        private TreeNode[] CustomItemPrenotation(IItemPrenotation ip)
        {
            return null;
        }

        /// <summary>
        /// CustomPrenotation per l'interfaccia ICustomizableItemPrenotation
        /// Recupera i plugin associati
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private TreeNode[] CustomItemPrenotation(ICustomizableItemPrenotation ip)
        {
            TreeNode plugin = new TreeNode();
            plugin.Text = "PLUGIN";

            foreach (IItem i in ip.Plugins)
                plugin.Nodes.Add(_itemNodes[i]);
            
            return new TreeNode[] { plugin };
        }
        #endregion

        #region Packet
        private TreeNode[] CustomPacket(IPacket packet)
        {
            TreeNode node = new TreeNode();
            node.Text = packet.Name + " " + packet.Description + packet.Price;
            return new TreeNode[] { node };
        }

        private TreeNode[] CustomPacket(DateRangePacket packet)
        {
            TreeNode node = new TreeNode();
            node.Text = packet.Name + ", " + packet.Description + ", prezzo :" + packet.Price 
                + ", usufruibile dal " +packet.Range.StartDate.ToShortDateString() 
                + " al " + packet.Range.EndDate.ToShortDateString() ;
            return new TreeNode[] { node };
        }

        private TreeNode[] CustomPacket(TicketPacket packet)
        {
            TreeNode node = new TreeNode();
            node.Text = packet.Name + ", " + packet.Description + ", prezzo : " + packet.Price
                + ", ticket disponibili " + packet.Ticket;
            return new TreeNode[] { node };
        }
        #endregion

        #region Bundle
        private TreeNode[] CustomBundle(IBundle bundle)
        {
            TreeNode node = new TreeNode();
            node.Text = bundle.Name + " " + bundle.Description + bundle.Price;
            foreach (IPacket p in bundle.Packets)
            {
                TreeNode[] nodes = CustomPacket(p as dynamic);
                node.Add(nodes);
            }
            return new TreeNode[] { node };
        }
        #endregion

        #endregion


        /// <summary>
        /// Visita ad un nodo di tipo IPrenotation
        /// </summary>
        /// <param name="prenotation"></param>
        public void Visit(IPrenotation prenotation)
        {
            _prenotationNode.Text = "Prenotazione dal " + prenotation.PrenotationDate.StartDate.ToShortDateString() 
                + " al " + prenotation.PrenotationDate.EndDate.ToShortDateString() + ", prezzo corrente : " + prenotation.Price;
        }

        /// <summary>
        /// Visita specifica ad un nodo di tipo ICustomizablePrenotation
        /// </summary>
        /// <param name="prenotation"></param>
        public void Visit(ICustomizableServizablePrenotation prenotation)
        {
            _prenotationNode.Text = "Prenotazione dal " + prenotation.PrenotationDate.StartDate.ToShortDateString()
                + " al " + prenotation.PrenotationDate.EndDate.ToShortDateString() + ", prezzo corrente : " + prenotation.Price;
            foreach(IPacket p in prenotation.Packets)
            {
                TreeNode[] nodes = CustomPacket(p as dynamic);
                _prenotationNode.Add(nodes);
            }
            foreach (IBundle b in prenotation.Bundles)
            {
                TreeNode[] nodes = CustomBundle(b as dynamic);
                _prenotationNode.Add(nodes);
            }
        }

        public void Visit(IItemPrenotation itemPrenotation)
        {
            TreeNode node = new TreeNode();
            node.Text = "Prenotazione dal " + itemPrenotation.RangeData.StartDate.ToShortDateString()
                + " al " + itemPrenotation.RangeData.EndDate.ToShortDateString() + ", prezzo corrente : " + itemPrenotation.Price;
            _itemPrenotationNodes.Add(itemPrenotation, node);
        }

        /// <summary>
        /// Visita specifica per un nodo di tipo ICategorizableItem
        /// </summary>
        /// <param name="item"></param>
        public void Visit(ICategorizableItem item)
        {
            if (_itemNodes.ContainsKey(item))
                return;

            TreeNode node = new TreeNode();
            node.Text = item.FriendlyName + " " + item.Description + " " + " Prezzo base: " + item.BaseDailyPrice + " Prezzo complessivo: " + item.DailyPrice;
            foreach (ICategory c in item.Categories)
            {
                TreeNode cNode = new TreeNode();
                KeyValuePair<ICategory, PriceDescriptor> prop = (from pair in item.Properties where pair.Key == c select pair).First();
                cNode.Text = c.Name + " " + " " + prop.Value.Name + " " + prop.Value.Description + " " + prop.Value.Price;
                node.Nodes.Add(cNode);
            }
            _itemNodes.Add(item, node);
        }

        public void Visit(IItem item)
        {
            if (_itemNodes.ContainsKey(item))
                return;

            TreeNode node = new TreeNode()
            {
                Text = item.FriendlyName + " " + item.Description + " " + " Prezzo base: " + item.BaseDailyPrice + " Prezzo complessivo: " + item.DailyPrice
            };
            _itemNodes.Add(item, node);
        }

        public void Visit(IBookableItem item)
        {
            if (_bookableNodes.ContainsKey(item))
                return;

            TreeNode node = new TreeNode();
            node.Text = item.BaseItem.FriendlyName + " Settore :" + item.Sector + " Posizione: " + item.Position.Row + "," + item.Position.Column;
            _bookableNodes.Add(item, node);
        }
    }
}
