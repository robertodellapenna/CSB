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
        private int _borderSize;
        private bool _swapped;
        private Color _backColor, _foreColor, _textColor;
        private Color _backColorHover, _foreColorHover, _textColorHover;

        #region Proprietà
        
        public Image Icon
        {
            set
            {
                if (value == null)
                {
                    _innerLabel.TextAlign = ContentAlignment.MiddleCenter;
                    _innerLabel.Padding = new Padding(0);
                    _innerLabel.Image = value;
                }
                else
                {
                    _innerLabel.TextAlign = ContentAlignment.MiddleRight;
                    _innerLabel.ImageAlign = ContentAlignment.MiddleLeft;
                    _innerLabel.Padding = new Padding(Convert.ToInt32(Size.Width*0.1), 0, Convert.ToInt32(Size.Width*0.1), 0);
                    _innerLabel.Image = new Bitmap(value, new Size(32, 32));
                }
            }
        }

        public int BorderSize
        {
            get => _borderSize;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("border < 0");
                }
                _borderSize = value;
                _innerLabel.Size = new Size(Width - 2 * value, Height - 2 * value);
                _innerLabel.Location = new Point(value, value);
            }
        }

        public override Color BackColor
        {
            get => _backColor;
            set {
                _backColor = value;
                ApplyColor();
            }
        }

        public Style Style
        {
            set => this.ApplyStyle(value);
        }

        public override Color ForeColor
        {
            get => _foreColor;
            set
            {
                _foreColor = value;
                ApplyColor();
            }
        }

        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                ApplyColor();
            }
        }

        public Color BackColorHover {
            get => _backColorHover;
            set
            {
                _backColorHover = value;
                ApplyColor();
            }
        }

        public Color ForeColorHover
        {
            get => _foreColorHover;
            set
            {
                _foreColorHover = value;
                ApplyColor();
            }
        }
        public Color TextColorHover
        {
            get => _textColorHover;
            set
            {
                _textColorHover = value;
                ApplyColor();
            }
        }

        public override string Text
        {
            get => _innerLabel.Text;
            set => _innerLabel.Text = value;
        }
        #endregion

        

        public BorderLabel(string text, Color textColor, Color backColor, Color foreColor, int borderSize,  Style s = null)
        {
            InitializeComponent();
            _borderLabel.Size = new Size(Width, Height);
            _borderSize = borderSize;
            _borderLabel.MouseEnter += HoverHandler;
            _backColor = backColor;
            _foreColor = foreColor;
            _textColor = textColor;
            _backColorHover = BackColor;
            _foreColorHover = ForeColor;
            _textColorHover = TextColor;
            _swapped = false;
            ApplyColor();
            Text = text;
            // Ridirezione dei click sugli handler registrati presso il controllo
            _borderLabel.Click += (obj, e) => InvokeOnClick(this, e);
            _innerLabel.Click += (obj, e) => InvokeOnClick(this, e);

            _borderLabel.DoubleClick += (obj, e) => OnDoubleClick(e);
            _innerLabel.DoubleClick += (obj, e) => OnDoubleClick(e);
            Style = s;
        }

        public BorderLabel(string text) : this (text, Color.Black, Color.Black, Color.White, 3) { }

        public BorderLabel() : this("") { }

        private void HoverHandler(Object obj, EventArgs e)
        {
            _swapped = !_swapped;
            ApplyColor();
        }

        private void ApplyColor()
        {
            _borderLabel.BackColor = !_swapped ? BackColor : BackColorHover;
            _innerLabel.BackColor = !_swapped ? ForeColor : ForeColorHover;
            _innerLabel.ForeColor = !_swapped ? TextColor : TextColorHover;
        }
    }
}
