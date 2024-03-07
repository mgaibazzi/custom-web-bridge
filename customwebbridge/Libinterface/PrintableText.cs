using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;
namespace customwebbridge.Libinterface
{
    internal class PrintableText
    {
        TextItem testo;
        bool bAddLF;
        PrintFontSettings FontSettings;
        //constructor
        public PrintableText(TextItem testo)
        {
            this.testo = testo;
            if (testo.Linespace != 0)
            {
                BAddLF = true;
            }
            else
            {
                BAddLF = false;
            }
            FontSettings1 = new PrintFontSettings();
            FontSettings1.Underline = this.testo.UnderLine;
            FontSettings1.Emphasized = this.testo.Emphasized;
            Font_size_table_Height(this.testo.Height);
            Font_size_table_width(this.testo.Width);
            Font_Type_table();
            FontJustification(this.testo);
            XPosition(this.testo);
            if (testo.DoubleHeight == true) 
            {
                if(this.testo.Height>4)
                    Font_size_table_Height(8);
                else
                    Font_size_table_Height(this.testo.Height * 2);
            }

            if (testo.DoubleWidth == true)
            {
                if(this.testo.Width>4)
                    Font_size_table_width(8);
                else
                    Font_size_table_width(this.testo.Width * 2);
            }
        }
        //getter and setter 
        internal TextItem Testo { get => testo; set => testo = value; }
        public bool BAddLF { get => bAddLF; set => bAddLF = value; }
        public PrintFontSettings FontSettings1 { get => FontSettings; set => FontSettings = value; }

        //Convert TextItem font widht to windows api font widht
        private void  Font_size_table_width(int num)/////da mettere a posto i valori
        {
            switch(num)
            {
                case 1:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X1;
                    break;
                case 2:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X2;
                    break;
                case 3:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X3;
                    break;
                case 4:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X4;
                    break;
                case 5:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X5;
                    break;
                case 6:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X6;
                    break;
                case 7:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X7;
                    break;
                case 8:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X8;
                    break;
                default:
                    FontSettings1.CharWidth = PrintFontSettings.FontSize.FONT_SIZE_X1;
                    break;
            }
        }
        //Convert TextItem font Height to windows api font Height
        private void Font_size_table_Height(int num)
        {
            switch (num)
            {
                case 1:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X1;
                    break;
                case 2:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X2;
                    break;
                case 3:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X3;
                    break;
                case 4:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X4;
                    break;
                case 5:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X5;
                    break;
                case 6:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X6;
                    break;
                case 7:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X7;
                    break;
                case 8:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X8;
                    break;
                default:
                    FontSettings1.CharHeight = PrintFontSettings.FontSize.FONT_SIZE_X1;
                    break;
            }
        }
        //Convert TextItem font type to windows api font type
        private void Font_Type_table()/////da mettere a posto i valori
        {
            if (testo.Font==TextItem.FontStyle.font_a)
            {
                FontSettings1.CharFontType = PrintFontSettings.FontType.FONT_TYPE_1;
            }
            else if(testo.Font == TextItem.FontStyle.font_b)
            {
                FontSettings1.CharFontType = PrintFontSettings.FontType.FONT_TYPE_2;
            }
            else if (testo.Font == TextItem.FontStyle.font_c)
            {
                FontSettings1.CharFontType = PrintFontSettings.FontType.FONT_TYPE_3;
            }
            else if (testo.Font == TextItem.FontStyle.font_d)
            {
                FontSettings1.CharFontType = PrintFontSettings.FontType.FONT_TYPE_4;
            }
            else
            {
                FontSettings1.CharFontType = PrintFontSettings.FontType.FONT_TYPE_1;
            }
        }
        private void FontJustification(TextItem testo)
        {
            if(testo.TextAlign1==TextItem.TextAlign.left)    
            { 
                FontSettings1.Justification= PrintFontSettings.FontJustification.FONT_JUSTIFICATION_LEFT;
            }
            else if (testo.TextAlign1 == TextItem.TextAlign.center)
            {
                FontSettings1.Justification = PrintFontSettings.FontJustification.FONT_JUSTIFICATION_CENTER;
            }
            else FontSettings1.Justification = PrintFontSettings.FontJustification.FONT_JUSTIFICATION_RIGHT;

        }
        private void XPosition(TextItem testo)
        {
            FontSettings.LeftMarginValue = (short)testo.X;
        }
    }
}
