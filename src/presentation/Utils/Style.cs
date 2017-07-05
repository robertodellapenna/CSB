using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation.Utils
{
    public class Style
    {
        private Font _font;
        public Font Font => _font;

        public Style()
        {
            _font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        }
    }
}
