﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using Custom.CuCustomWndAPI;

namespace customwebbridge
{
    internal class TextItem:BaseItem
    {
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
            color_1,
            color_2,
            color_3,
            color_4,
            none
        }

        // Private fields to store the properties of TextForm
        private string text = "";
        private int x;
        private int y;
        private int width;//
        private int height;//
        private Language lang = Language.en;
        private FontStyle font = FontStyle.font_a;//
        private bool smooth;
        private bool doubleHeight;
        private bool doubleWidth;
        private bool reverse;
        private bool underLine;
        private bool emphasized;
        private ColorStyle color = ColorStyle.color_1;

        BaseItem bi = new BaseItem(BaseItem.ItemType.text);
        // Default constructor
        public TextItem() : base(BaseItem.ItemType.text)
        {
            Text = "";
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
            Color = ColorStyle.color_1;
        }

        // Parameterized constructor
        public TextItem(string text, TextAlign align, int x, int y, int width, int height, Language lang, FontStyle font, bool smooth, bool doubleHeight, bool doubleWidth, bool reverse, bool underLine, bool emphasized, ColorStyle color, int linespace, bool rotate) : base(BaseItem.ItemType.text)
        {
            this.Text = text;
            this.TextAlign1 = align;
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
        //Constructor 
        public TextItem(string text, FontStyle font, ColorStyle color ) : base(BaseItem.ItemType.text)
        {
            this.Text = text;
            this.Font = font;
            this.Color = color;
        }
        //Copy constructor 
        public TextItem( TextItem ti):base(BaseItem.ItemType.text)
        {
            this.Text = ti.Text;
            this.Font = ti.Font;
            this.Color = ti.Color;
            this.Linespace = ti.Linespace;
            this.TextAlign1 = ti.TextAlign1;
            this.X = ti.X;
            this.Y = ti.Y;
            this.Width = ti.Width;
            this.Height = ti.Height;
            this.Lang = ti.Lang;
            this.Smooth = ti.Smooth;
            this.DoubleHeight = ti.DoubleHeight;
            this.DoubleWidth = ti.DoubleWidth;
            this.Reverse = ti.Reverse;
            this.UnderLine = ti.UnderLine;
            this.Emphasized = ti.Emphasized;
            this.Rotate = ti.Rotate;

        }
        // Properties with getter and setter methods for each field
        public string Text
        {
            get { return text; }
            set
            {
                if (value != null) text = value;
                else throw new Exception("String null");
            }
        }
        public int X
        {
            get { return x; }
            set
            {
                if (value < 0 && value > 500)
                {
                    throw new Exception("Uncorrect value");
                }
                else x = value;

            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0 && value > 500)
                {
                    throw new Exception("Uncorrect value");
                }
                else y = value;

            }
        }
        public int Width
        {
            get { return width; }
            set
            {
                if (value < 0 && value > 8)
                {
                    throw new Exception("Uncorrect value");
                }
                else width = value;

            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0 && value > 8)
                {
                    throw new Exception("Uncorrect value");
                }
                else height = value;

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
        //ToString of the TextItem class
        public override string ToString()
        {
            string str;
            str = "Text: " + text
                //+ "Align:" + bi.TextAlign1.ToString()
                + "X: " + x.ToString() + "\n"
                + "Y: " + y.ToString() + "\n"
                + "Width: " + width.ToString() + "\n"
                + "Height: " + height.ToString() + "\n"
                + "language: " + lang.ToString() + "\n"
                + "FontStyle: " + font.ToString() + "\n"
                + "Smooth: " + smooth.ToString() + "\n"
                + "DoubleHeight: " + doubleHeight.ToString() + "\n"
                + "DoubleWidth: " + doubleWidth.ToString() + "\n"
                + "Reverse: " + reverse.ToString() + "\n"
                + "Underline: " + underLine.ToString() + "\n"
                + "Emphasized: " + emphasized.ToString() + "\n"
                + "Color: " + color.ToString() + "\n"
                + base.ToString()
                ;
                 //+ "Linespace: " + bi.Linespace.ToString() + "\n"
                 //+ "Rotate: " + bi.Rotate.ToString() + "\n";
            return str;
        }





    }
}
