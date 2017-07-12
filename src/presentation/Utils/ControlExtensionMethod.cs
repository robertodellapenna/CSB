using CSB_Project.src.business;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation.Utils
{
    public static class ControlExtensionMethod
    {
        /// <summary>
        /// Applica lo stile ad un controllo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="style"></param>
        public static void ApplyStyle(this Control c, Style style)
        {
            if (style == null)
                style = Style.DefaultStyle;
            if(style.Font != null)
                c.Font = style.Font;
        }

        public static void ApplyStyle(this TextBox tb, Style style)
        {
            ApplyStyle(tb as Control, style);
            tb.TextAlign = style.TextAlign;
        }

        public static void Populate<T>(this ListView lv, IEnumerable<T> items, Func<T, String> extractor)
        {
            ListViewItem lvi;
            lv.Clear();
            foreach(T obj in items)
            {
                lvi = new ListViewItem(extractor(obj));
                lvi.Tag = obj;
                lv.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Popola ricorsavamente una treeNodeCollection partendo da una categoria radice
        /// </summary>
        /// <param name="nodes">Nodo a cui aggiungere i nuovi nodi</param>
        /// <param name="category">Categoria radice con cui popolare i nodi</param>
        public static void Populate(this TreeNodeCollection tnc, ICategory category)
        {
            TreeNode tn = new TreeNode(category.Name);
            tn.Tag = category;
            if (category is IGroupCategory)
                foreach (ICategory c in (category as IGroupCategory).Children)
                    tn.Nodes.Populate(c);
            tnc.Add(tn);
        }

        /// <summary>
        /// Popola la tree view partendo dalle strutture esistenti
        /// </summary>
        /// <param name="nodes">Nodo a cui aggiungere i nuovi nodi</param>
        /// <param name="structures">Strutture con cui popolare i nodi</param>
        public static void Populate(this TreeNodeCollection nodes, IEnumerable<Structure> structures, DateRange range, IBookingCoordinator bCoordinator, IPrenotationCoordinator pCoordinator)
        {
            foreach (Structure structure in structures)
            {
                TreeNode tnStructure = new TreeNode(structure.Name);
                tnStructure.Tag = structure;
                foreach (StructureArea area in structure.Areas)
                {
                    TreeNode tnArea = new TreeNode(area.Name);
                    tnArea.Tag = area;
                    foreach (Sector sector in area.Sectors)
                    {
                        TreeNode tnSector = new TreeNode(sector.Name);
                        tnSector.Tag = sector;
                        tnSector.Populate(range, bCoordinator, pCoordinator);
                        tnArea.Nodes.Add(tnSector);
                    }
                    tnStructure.Nodes.Add(tnArea);
                }
                nodes.Add(tnStructure);
            }
        }

        public static void Populate(this TreeNode tnSector, DateRange range, IBookingCoordinator bCoordinator, IPrenotationCoordinator pCoordinator)
        {
            Sector sector = tnSector.Tag as Sector;
            for (int i=1; i<=sector.Rows; i++)
            {
                TreeNode tnRow = new TreeNode("Riga "+i);
                tnRow.Tag = sector;
                for (int j = 1; j <= sector.Columns; j++)
                {
                    Position positionToAdd = new Position(i, j);
                    IBookableItem item = bCoordinator.GetBookableItem(sector, positionToAdd);
                    TreeNode tnBookableItem;
                    if (item == null)
                    {
                        tnBookableItem = new TreeNode(j + " - nessun elemento");
                    }
                    else
                    {
                        string status = "Buisy";
                        Color color = Color.Red;
                        bool available = pCoordinator.IsAvailable(sector, positionToAdd, range);
                        if (available)
                        {
                            status = "Free";
                            color = Color.Green;
                        }
                        tnBookableItem = new TreeNode(j + " - " + status + " - " + item.ToString());
                        tnBookableItem.ForeColor = color;
                        tnBookableItem.Tag = item;
                    }
                    tnRow.Nodes.Add(tnBookableItem);
                }
                tnSector.Nodes.Add(tnRow);
            }
        }

        public static void SetHint(this TextBox tb, string msg, Color color)
        {
            SetColorMsg(tb, msg, color);
        }

        public static void RemoveHint(this TextBox tb, Color color)
        {
            SetColorMsg(tb, String.Empty, color);
        }

        private static void SetColorMsg(TextBox tb, string msg, Color color)
        {
            #region Precondizioni
            if (tb == null)
                throw new ArgumentNullException("tb null");
            if (msg == null)
                throw new ArgumentNullException("msg null");
            #endregion
            tb.Text = msg;
            tb.ForeColor = color;
        }

        public static void AddTagInformation(this Control c, string key, Object value)
        {
            if (c.Tag == null)
                c.Tag = new Dictionary<string, Object>();
            else
            {
                if (!(c.Tag is Dictionary<string, Object>))
                {
                    Dictionary<string, Object> dict = new Dictionary<string, object>();
                    dict.Add("previousTagValue", c.Tag);
                    c.Tag = dict;
                }
            }
            (c.Tag as Dictionary<string, Object>)[key] = value;
        }

        public static void AddLoginInformation(this Control c, LoginPresenter.ILoginInformation li)
        {
            #region Precondizioni
            if (li == null)
                throw new ArgumentNullException("li null");
            #endregion
            AddTagInformation(c, "loginInformation", li);
        }

        public static Object RetrieveTagInformation(this Control c, string key)
        {
            if (c.Tag == null ||
                !(c.Tag is Dictionary<string, Object>))
                throw new InvalidOperationException("Il campo tag non è un dizionario");
            if((c.Tag as Dictionary<string, Object>).ContainsKey(key))
                throw new InvalidOperationException("non è presente nessuna chiave '" + key +"'");
            return (c.Tag as Dictionary<string, Object>)[key];
        }

        public static T RetrieveTagInformation<T>(this Control c, string key)
        {
            if (c.Tag == null ||
                !(c.Tag is Dictionary<string, Object>))
                throw new InvalidOperationException("Il campo tag non è un dizionario");
            if ((c.Tag as Dictionary<string, Object>).ContainsKey(key))
                throw new InvalidOperationException("non è presente nessuna chiave '" + key + "'");
            Object obj = (c.Tag as Dictionary<string, Object>)[key];

            if (!(obj is T))
                throw new InvalidOperationException("il valore di '" + key + "' non è di tipo " + typeof(T));
            return (T)obj;
        }
    }
}
