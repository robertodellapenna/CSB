using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CSB_Project.src.presentation.ItemCreator
{
    public class BasicItemCreatorPresenter
    {
        private Func<XmlNode, bool> _addItemDelegate;

        public BasicItemCreatorPresenter(BasicItemCreatorView view, Func<XmlNode, bool> addItemDelegate)
        {
            MessageBox.Show((addItemDelegate == null) + " ");
        }
    }
}
