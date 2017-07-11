using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation.Utils
{
    public sealed class Style : IDisposable
    {
        private Font _font;
        private HorizontalAlignment _textAlign;

        public Font Font
        {
            get => _font;
            set => _font = value;
        }

        public HorizontalAlignment TextAlign
        {
            get => _textAlign;
            set => _textAlign = value;
        }

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

        public void Dispose()
        {
            _font.Dispose();
        }
    }
}
