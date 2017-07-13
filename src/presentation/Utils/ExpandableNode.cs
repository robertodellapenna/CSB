using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CSB_Project.src.presentation.Utils
{
    public partial class ExpandableNode : UserControl
    {
        private ObservableCollection<Object> _children;
        private List<BorderLabel> _childrenLabel;

        public ObservableCollection<Object> Children => _children;

        private bool open = false;
        private bool openable = false;

        public ExpandableNode()
        {
            InitializeComponent();
            // label init
            SizeChanged += RefreshControl;
            _label.BorderSize = 0;
            _label.Size = _backPanel.Size;
            _label.Icon = null;
            _label.Text = "Top Level";
            _children = new ObservableCollection<Object>();
            _childrenLabel = new List<BorderLabel>();
            _children.CollectionChanged += CollectionChangedHandler;
            _label.Click += OpenCloseHandler;
        }

        private void OpenCloseHandler(Object o, EventArgs e)
        {
            if (!openable)
                return;
            if (open)
            {
                // era aperto, chiudo
                _label.Icon = Image.FromFile("../../icon/closed.png");
                foreach(BorderLabel bl in _childrenLabel)
                {
                    bl.Enabled = false;
                    bl.Visible = false;
                }
            }
            else
            {
                // era chiuso, apro 
                _label.Icon = Image.FromFile("../../icon/open.png");
                foreach (BorderLabel bl in _childrenLabel)
                {
                    bl.Enabled = true;
                    bl.Visible = true;
                }
            }
            open = !open;
        }

        private void CollectionChangedHandler(Object o, EventArgs e)
        {
            if (_children.Count > 0)
            {
                // mosta icona
                openable = true;
                open = false;
                _label.Icon = Image.FromFile("../../icon/closed.png");
            }
            else
            {
                _label.Icon = null;
                openable = false;
            }

            _backPanel.Controls.Clear();
            _backPanel.Controls.Add(_label);
            foreach(Object obj in _children)
            {
                BorderLabel bl = new BorderLabel(obj.ToString(), Color.Black, Color.White, Color.White, 0);
                _childrenLabel.Add(bl);
                _backPanel.Controls.Add(bl);
            }
        }

        private void RefreshControl(Object o, EventArgs e)
        {
            _label.Size = _backPanel.Size;
        }
    }
}
