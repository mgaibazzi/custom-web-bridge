using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Barcode2D;
using static customwebbridge.TextItem;

namespace customwebbridge.Xml_parsing
{
    internal class BarcodeParsing
    {
        public void Barcode1DParsing(XmlNode textNode, List<BaseItem> items) 
        {
            Barcode1D.Type type = Barcode1D.Type.code39;
            Barcode1D.HRI hri = Barcode1D.HRI.none;
            Barcode1D.FontStyle font = Barcode1D.FontStyle.font_a;
            int width = 2;
            int height = 32;
            string data = "";

            Barcode1D itemFormat = new Barcode1D(2, 32, "");
            string ty;
            string h;
            string fnt;
            try
            {
                data = textNode.InnerText;
                if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["width"]?.Value);
                    itemFormat.Width = width;
                }
                if (textNode.Attributes["height"]?.Value != null)
                {
                    height = Convert.ToInt32(textNode.Attributes["height"]?.Value);
                    itemFormat.Height = height;
                }
                
                if (textNode.Attributes["hri"]?.Value != null)
                {
                    h = textNode.Attributes["hri"]?.Value;
                    hri = (Barcode1D.HRI)Enum.Parse(typeof(Barcode1D.HRI), h);//Casting from string to enum
                    itemFormat.Hri1 = hri;
                }
                if (textNode.Attributes["font"]?.Value != null)
                {
                    fnt = textNode.Attributes["font"]?.Value;
                    font = (Barcode1D.FontStyle)Enum.Parse(typeof(Barcode1D.FontStyle),fnt);//Casting from string to enum
                    itemFormat.Font1 = font;
                }
                if (textNode.Attributes["type"]?.Value != null)
                {
                    ty = textNode.Attributes["type"]?.Value;
                    type = (Barcode1D.Type)Enum.Parse(typeof(Barcode1D.Type), ty);//Casting from string to enum
                    itemFormat.BarcodeType = type;
                }
                items.Add(itemFormat);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Barcode2DParsing(XmlNode textNode, List<BaseItem> items) 
        {
            Barcode2D.ErrorCorrectionLevel errorconnectionlevel = Barcode2D.ErrorCorrectionLevel.Default;
            Barcode2D.Type type = Barcode2D.Type.pdf417_standard;
            int width=2;
            int height=2;
            string data="";
            //int errorCorrectionLevelAztecCode = 23;
            int s_size = 0;
            Barcode2D itemFormat = new Barcode2D(2,2,"");
            string ty;
            string ecl;

            try
            {
                
                // Extract text content and display
                data = textNode.InnerText;
                itemFormat.Data = data;
                if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["width"]?.Value);
                    itemFormat.Width = width;
                }
                if (textNode.Attributes["height"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["height"]?.Value);
                    itemFormat.Height = height;
                }
                if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["size"]?.Value);
                    itemFormat.S_size = s_size;
                }
                /*if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["size"]?.Value);
                    itemFormat.ErrorCorrectionLevelAztecCode = errorCorrectionLevelAztecCode ;
                }*/



                if (textNode.Attributes["type"]?.Value != null)
                {
                    ty = textNode.Attributes["type"]?.Value;
                    type = (Barcode2D.Type)Enum.Parse(typeof(Barcode2D.Type), ty);//Casting from string to enum
                    itemFormat.TypeQRCode = type;
                }
                if (textNode.Attributes["level"]?.Value != null)
                {
                    ecl = textNode.Attributes["level"]?.Value;
                    errorconnectionlevel = (Barcode2D.ErrorCorrectionLevel)Enum.Parse(typeof(Barcode2D.ErrorCorrectionLevel), ecl);//Casting from string to enum
                    itemFormat.ErrorCorrectionLevel1 = errorconnectionlevel;
                }
                items.Add(itemFormat);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
