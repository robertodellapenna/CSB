using CSB_Project.src.model.Item;
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

        public CategorizableItemCreatorPresenter(CategorizableItemCreatorView view, Func<XmlNode, bool> addItemDelegate, Func<IEnumerable<IItem>> items)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (addItemDelegate == null)
                throw new ArgumentNullException("addItemDelegate null");
            if (items == null)
                throw new ArgumentNullException("items null");
            #endregion
            _addItemDelegate = addItemDelegate;
        }
    }
}
