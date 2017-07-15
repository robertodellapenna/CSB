using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CSB_Project.src.presentation.ItemCreator
{
    public class CategorizableItemCreatorPresenter
    {
        private Func<XmlNode, bool> _addItemDelegate;

        public CategorizableItemCreatorPresenter(CategorizableItemCreatorView view, Func<XmlNode, bool> addItemDelegate)
        {
            MessageBox.Show((addItemDelegate == null) + " ");
        }
    }
}
