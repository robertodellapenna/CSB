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

        public static Style DefaultStyle
        {
            get
            {
                Style s = new Style();
                s._font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
                return s;
            }
        }

        public Style()
        {
            _font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        }
    }
}
