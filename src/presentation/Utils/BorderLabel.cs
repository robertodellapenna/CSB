using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation.Utils
{
    public partial class BorderLabel : UserControl
    {
        private Color _borderColor, _innerColor;
        private int _borderSize;

        public Color BorderColor { get; }
        public BorderLabel()
        {
            InitializeComponent();
        }
    }
}
