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
        public void Barcode1DParsing(XmlNode textNode, List<BaseItem> items, BaseItem baseFormat) 
        {
            Barcode1D.Type type = Barcode1D.Type.code39;
            Barcode1D.HRI hri = Barcode1D.HRI.none;
            Barcode1D.FontStyle font = Barcode1D.FontStyle.font_a;
            int width = 2;
            int height = 32;
            string data = "";

            Barcode1D item = new Barcode1D(2, 32, "");
            string ty;//support variables that we use to cast an enum
            string h;//support variables that we use to cast an enum
            string fnt;//support variables that we use to cast an enum
            try
            {
                data = textNode.InnerText;
                if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["width"]?.Value);
                    item.Width = width;
                }
                if (textNode.Attributes["height"]?.Value != null)
                {
                    height = Convert.ToInt32(textNode.Attributes["height"]?.Value);
                    item.Height = height;
                }
                
                if (textNode.Attributes["hri"]?.Value != null)
                {
                    h = textNode.Attributes["hri"]?.Value;
                    hri = (Barcode1D.HRI)Enum.Parse(typeof(Barcode1D.HRI), h);//Casting from string to enum
                    item.Hri1 = hri;
                }
                if (textNode.Attributes["font"]?.Value != null)
                {
                    fnt = textNode.Attributes["font"]?.Value;
                    font = (Barcode1D.FontStyle)Enum.Parse(typeof(Barcode1D.FontStyle),fnt);//Casting from string to enum
                    item.Font1 = font;
                }
                if (textNode.Attributes["type"]?.Value != null)
                {
                    ty = textNode.Attributes["type"]?.Value;
                    type = (Barcode1D.Type)Enum.Parse(typeof(Barcode1D.Type), ty);//Casting from string to enum
                    item.setCommonVariabiles(baseFormat);
                    item.BarcodeType = type;
                }
                items.Add(item);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Barcode2DParsing(XmlNode textNode, List<BaseItem> items, BaseItem baseFormat) 
        {
            Barcode2D.ErrorCorrectionLevel errorcorrectionlevel = Barcode2D.ErrorCorrectionLevel.Default;
            Barcode2D.Type type = Barcode2D.Type.pdf417_standard;
            int width=2;
            int height=2;
            string data="";
            //int errorCorrectionLevelAztecCode = 23;
            int s_size = 0;
            Barcode2D item = new Barcode2D(2, 2, "");
            string ty;
            string ecl;

            try
            {
                
                // Extract text content and display
                data = textNode.InnerText;
                item.Data = data;
                if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["width"]?.Value);
                    item.Width = width;
                }
                if (textNode.Attributes["height"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["height"]?.Value);
                    item.Height = height;
                }
                if (textNode.Attributes["size"]?.Value != null)
                {
                    s_size = Convert.ToInt32(textNode.Attributes["size"]?.Value);
                    item.S_size = s_size;
                }
                if (textNode.Attributes["type"]?.Value != null)
                {
                    ty = textNode.Attributes["type"]?.Value;
                    type = (Barcode2D.Type)Enum.Parse(typeof(Barcode2D.Type), ty);//Casting from string to enum
                    item.TypeQRCode = type;
                }
                if (textNode.Attributes["level"]?.Value != null)
                {
                    ecl = textNode.Attributes["level"]?.Value;
                    if(ecl=="default")
                    {
                        item.ErrorCorrectionLevel1 = Barcode2D.ErrorCorrectionLevel.Default;
                    }
                    errorcorrectionlevel = (Barcode2D.ErrorCorrectionLevel)Enum.Parse(typeof(Barcode2D.ErrorCorrectionLevel), ecl);//Casting from string to enum
                    item.ErrorCorrectionLevel1 = errorcorrectionlevel;
                }
                item.setCommonVariabiles(baseFormat);
                items.Add(item);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
