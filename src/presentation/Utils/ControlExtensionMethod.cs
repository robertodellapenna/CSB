using CSB_Project.src.model.Category;
using CSB_Project.src.model.Structure;
using System;
using System.Collections.Generic;
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
            c.Font = style.Font;
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
        public static void Populate(this TreeNodeCollection nodes, IEnumerable<Structure> structures)
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
                        tnArea.Nodes.Add(tnSector);
                    }
                    tnStructure.Nodes.Add(tnArea);
                }
                nodes.Add(tnStructure);
            }
        }

    }
}
