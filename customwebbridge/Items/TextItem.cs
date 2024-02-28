using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace customwebbridge
{
    internal class TextItem:BaseItem
    { 
    // Enum to represent text alignment options
        public enum TextAlign
        {
            Left,
            Center,
            Right
        }

        // Enum to represent supported languages
        public enum Language
        {
            en,
            ja,
            ko,
            zh_cn,
            zh_hans,
            zh_tw,
            zh_hant

        }

        // Enum to represent font styles
        public enum FontStyle
        {
            font_a,
            font_b,
            font_c,
            font_d,
            font_e,
            special_a,
            special_b
        }

        // Enum to represent color styles
        public enum ColorStyle
        {
            Color_1,
            Color_2,
            Color_3,
            Color_4,
            None
        }

        // Private fields to store the properties of TextForm
        private string text = "";
        private TextAlign align = TextAlign.Left;
        private int x;
        private int y;
        private int width;
        private int height;
        private Language lang = Language.en;
        private FontStyle font = FontStyle.font_a;
        private bool smooth;
        private bool doubleHeight;
        private bool doubleWidth;
        private bool reverse;
        private bool underLine;
        private bool emphasized;
        private ColorStyle color = ColorStyle.Color_1;
        private int linespace;
        private bool rotate;

        // Default constructor
        public TextItem() : base(BaseItem.ItemType.text)
        {
            Text = "";
            Align = TextAlign.Left;
            X = 0;
            Y = 0;
            Width = 1;
            Height = 1;
            Lang = Language.en;
            Font = FontStyle.font_a;
            Smooth = false;
            DoubleHeight = false;
            DoubleWidth = false;
            Reverse = false;
            UnderLine = false;
            Emphasized = false;
            Color = ColorStyle.Color_1;
            Linespace = 30;
            Rotate = false;
        }

        // Parameterized constructor
        public TextItem(string text, TextAlign align, int x, int y, int width, int height, Language lang, FontStyle font, bool smooth, bool doubleHeight, bool doubleWidth, bool reverse, bool underLine, bool emphasized, ColorStyle color, int linespace, bool rotate) : base(BaseItem.ItemType.text)
        {
            this.Text = text;
            this.Align = align;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Lang = lang;
            this.Font = font;
            this.Smooth = smooth;
            this.DoubleHeight = doubleHeight;
            this.DoubleWidth = doubleWidth;
            this.Reverse = reverse;
            this.UnderLine = underLine;
            this.Emphasized = emphasized;
            this.Color = color;
            this.Linespace = linespace;
            this.Rotate = rotate;
        }
        //Main constructor

        //public Barcode2D( int width, int height, string data) : base( width, height, data)
        public TextItem(string text, FontStyle font, int linespace, ColorStyle color, TextAlign align) : base(BaseItem.ItemType.text)
        {
            this.Text = text;
            this.Font = font;
            this.Color = color;
            this.Linespace = linespace;
            this.Align = align;
        }

        // Properties with getter and setter methods for each field
        //public string Text { get => text; set => text = value; }
        public string Text
        {
            get { return text; }
            set
            {
                if (value != null) text = value;
                else throw new Exception("Stringa vuota");
            }
        }
        public TextAlign Align { get => align; set => align = value; }
        public int X
        {
            get { return x; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Valore non corretto");
                }
                else x = value;

            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Valore non corretto");
                }
                else y = value;

            }
        }
        public int Width
        {
            get { return width; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Valore non corretto");
                }
                else width = value;

            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Valore non corretto");
                }
                else height = value;

            }
        }
        public int Linespace
        {
            get { return linespace; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Valore non corretto");
                }
                else linespace = value;

            }
        }
        public Language Lang { get => lang; set => lang = value; }
        public FontStyle Font { get => font; set => font = value; }
        public bool Smooth { get => smooth; set => smooth = value; }
        public bool DoubleHeight { get => doubleHeight; set => doubleHeight = value; }
        public bool DoubleWidth { get => doubleWidth; set => doubleWidth = value; }
        public bool Reverse { get => reverse; set => reverse = value; }
        public bool UnderLine { get => underLine; set => underLine = value; }
        public bool Emphasized { get => emphasized; set => emphasized = value; }
        public ColorStyle Color { get => color; set => color = value; }
        public bool Rotate { get => rotate; set => rotate = value; }
    }
}
