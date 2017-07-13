using CSB_Project.src.business;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Prenotation;
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
            if (style == null)
                return;
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

        public static void Populate(this TabControl tc, IEnumerable<IPrenotation> prenotations)
        {
            foreach(IPrenotation p in prenotations)
            {
                TabPage tp = new TabPage("Dal " + p.PrenotationDate.StartDate.ToShortDateString() + " al " + p.PrenotationDate.EndDate.Date.ToShortDateString());
                Panel mainPanel = new Panel();
                mainPanel.Dock = DockStyle.Fill;
                mainPanel.BackColor = Color.White;
                mainPanel.AutoScroll = true;
                mainPanel.Margin = new Padding(0);

                TextBox output = new TextBox();
                output.Multiline = true;
                output.Enabled = false;
                output.BackColor = Color.White;
                output.Dock = DockStyle.Fill;
                output.Text = p.InformationString;

                mainPanel.Controls.Add(output);
                tp.Controls.Add(mainPanel);
                tc.TabPages.Add(tp);
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

        public static void AddLoginInformation(this Control c, ILoginInformation li)
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
            if (!(c.Tag as Dictionary<string, Object>).ContainsKey(key))
                throw new InvalidOperationException("non è presente nessuna chiave '" + key + "'");
            Object obj = (c.Tag as Dictionary<string, Object>)[key];
            if (!(obj is T))
                throw new InvalidOperationException("il valore di '" + key + "' non è di tipo " + typeof(T));
            return (T)obj;
        }
    }
}
