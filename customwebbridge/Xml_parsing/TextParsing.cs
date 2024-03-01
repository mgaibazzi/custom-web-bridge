using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static customwebbridge.TextItem;

namespace customwebbridge
{
    internal class TextParsing
    {
        TextItem itemFormat;
        public TextParsing()
        {
            itemFormat = new TextItem();
        }

        


        public void ParseNodeXml(XmlNode textNode, List<BaseItem> items)
        {
            itemFormat = new TextItem();
            TextItem.ColorStyle style = TextItem.ColorStyle.color_1;
            TextItem.TextAlign textAlign = TextItem.TextAlign.left;
            TextItem.FontStyle fontStyle = TextItem.FontStyle.font_a;
            TextItem.Language language = TextItem.Language.en;

            string textContent = "";
            string align = "left";
            int x = 0;
            int y = 0;
            int width = 1;
            int height = 1;
            string lang = "en";
            string font = "font_a";
            bool smooth = false;
            bool doubleHeight = false;
            bool doubleWidth = false;
            bool reverse = false;
            bool underLine = false;
            bool emphasized = false;
            string color = "Color_1";
            int linespace = 30;
            bool rotate = false;
            try
            {


   
                    // Extract text content and display
                    textContent = textNode.InnerText;

                    if (!String.IsNullOrEmpty(textContent))
                    {
                        //copia oggetto
                        //inserisci oggetto in lista
                        TextItem item_copy = new TextItem(itemFormat);
                        item_copy.Text = textContent;
                        items.Add(item_copy);
                    }

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
                    if (textNode.Attributes["lang"]?.Value != null)
                    {
                        lang = textNode.Attributes["lang"]?.Value;
                        language = (Language)Enum.Parse(typeof(Language), lang);//Casting from string to enum
                        itemFormat.Lang = language;
                    }
                    if (textNode.Attributes["font"]?.Value != null)
                    {
                        font = Convert.ToString(textNode.Attributes["font"]?.Value);
                        fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), font);//Casting from string to enum
                        itemFormat.Font = fontStyle;
                    }
                    if (textNode.Attributes["dw"]?.Value != null)
                    {
                        doubleHeight = Convert.ToBoolean(textNode.Attributes["dw"]?.Value);
                        itemFormat.DoubleHeight = doubleHeight;
                    }
                    if (textNode.Attributes["dh"]?.Value != null)
                    {
                        doubleWidth = Convert.ToBoolean(textNode.Attributes["dh"]?.Value);
                        itemFormat.DoubleWidth = doubleWidth;
                    }
                    if (textNode.Attributes["y"]?.Value != null)
                    {
                        y = Convert.ToInt32(textNode.Attributes["y"]?.Value);
                        itemFormat.Y = y;
                    }
                    if (textNode.Attributes["x"]?.Value != null)
                    {
                        x = Convert.ToInt32(textNode.Attributes["x"]?.Value);
                        itemFormat.X = x;
                    }
                    if (textNode.Attributes["smooth"]?.Value != null)
                    {
                        smooth = Convert.ToBoolean(textNode.Attributes["smooth"]?.Value);
                        itemFormat.Smooth = smooth;
                    }
                    if (textNode.Attributes["align"]?.Value != null)//
                    {
                        align = textNode.Attributes["align"]?.Value;
                        textAlign = (TextAlign)Enum.Parse(typeof(TextAlign), align);//Casting from string to enum
                        itemFormat.Align = textAlign;
                    }
                    if (textNode.Attributes["linespc"]?.Value != null)
                    {
                        linespace = Convert.ToInt32(textNode.Attributes["linespc"]?.Value);
                        itemFormat.Linespace = linespace;
                    }
                    if (textNode.Attributes["rotate"]?.Value != null)
                    {
                        rotate = Convert.ToBoolean(textNode.Attributes["rotate"]?.Value);
                        itemFormat.Rotate = rotate;
                    }
                    if (textNode.Attributes["color"]?.Value != null)
                    {
                        color = Convert.ToString(textNode.Attributes["color"]?.Value);
                        style = (ColorStyle)Enum.Parse(typeof(ColorStyle), color);//Casting from string to enum
                        itemFormat.Color = style;
                    }
                    if (textNode.Attributes["em"]?.Value != null)
                    {
                        emphasized = Convert.ToBoolean(textNode.Attributes["em"]?.Value);
                        itemFormat.Emphasized = emphasized;
                        MessageBox.Show("em");
                    }
                    if (textNode.Attributes["ul"]?.Value != null)
                    {
                        underLine = Convert.ToBoolean(textNode.Attributes["ul"]?.Value);
                        itemFormat.UnderLine = underLine;
                        MessageBox.Show("ul");
                    }
                    if (textNode.Attributes["reverse"]?.Value != null)
                    {
                        reverse = Convert.ToBoolean(textNode.Attributes["reverse"]?.Value);
                        itemFormat.Reverse = reverse;
                    }
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}







/*public string Path
        { 
            get { return path; }
            set { if (value != null) path = value; else throw new Exception("String null"); }
        }
        public void ParseXml(List<BaseItem> items)
        {
            TextItem.ColorStyle style = TextItem.ColorStyle.color_1;
            TextItem.TextAlign textAlign = TextItem.TextAlign.left;
            TextItem.FontStyle fontStyle = TextItem.FontStyle.font_a;
            TextItem.Language language = TextItem.Language.en;

            string textContent="";
            string align = "left";
            int x = 0;
            int y = 0;
            int width = 1;
            int height = 1;
            string lang = "en";
            string font = "font_a";
            bool smooth = false;
            bool doubleHeight = false;
            bool doubleWidth = false;
            bool reverse = false;
            bool underLine = false; 
            bool emphasized = false;
            string color = "Color_1";
            int linespace = 30;
            bool rotate = false;
            //List<TextItem> items = new List<TextItem>();
            try
            {
                // Load XML document
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);

                // Assuming XML structure contains <Text> element
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                nsManager.AddNamespace("epos-print", "http://www.epson-pos.com/schemas/2011/03/epos-print");

                // Use the namespace manager in the XPath expression
                XmlNodeList textNodes = xmlDoc.SelectNodes("//epos-print:text", nsManager);

                // Iterate through each <Text> element
                foreach (XmlNode textNode in textNodes)
                {
                    // Extract text content and display
                    textContent = textNode.InnerText;

                    if (!String.IsNullOrEmpty(textContent))
                    {
                        //copia oggetto
                        //inserisvci oggetto iin lista
                        TextItem item_copy = new TextItem(itemFormat);
                        item_copy.Text = textContent;
                        items.Add(item_copy);
                    }

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
                    if (textNode.Attributes["lang"]?.Value != null)
                    {
                        lang = textNode.Attributes["lang"]?.Value;
                        language = (Language)Enum.Parse(typeof(Language), lang);//Casting from string to enum
                        itemFormat.Lang = language;
                    }
                    if (textNode.Attributes["font"]?.Value != null)
                    {
                        font = Convert.ToString(textNode.Attributes["font"]?.Value);
                        fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), font);//Casting from string to enum
                        itemFormat.Font = fontStyle;
                    } 
                    if (textNode.Attributes["dw"]?.Value != null)
                    {
                        doubleHeight = Convert.ToBoolean(textNode.Attributes["dw"]?.Value);
                        itemFormat.DoubleHeight = doubleHeight;
                    }
                    if (textNode.Attributes["dh"]?.Value != null)
                    {
                        doubleWidth = Convert.ToBoolean(textNode.Attributes["dh"]?.Value); 
                        itemFormat.DoubleWidth = doubleWidth;
                    }
                    if (textNode.Attributes["y"]?.Value != null)
                    {
                        y = Convert.ToInt32(textNode.Attributes["y"]?.Value);
                        itemFormat.Y = y;
                    }
                    if (textNode.Attributes["x"]?.Value != null)
                    {
                        x = Convert.ToInt32(textNode.Attributes["x"]?.Value);
                        itemFormat.X = x;
                    }
                    if (textNode.Attributes["smooth"]?.Value != null)
                    {
                        smooth = Convert.ToBoolean(textNode.Attributes["smooth"]?.Value);
                        itemFormat.Smooth = smooth;
                    }
                    if (textNode.Attributes["align"]?.Value != null)//
                    {
                        align = textNode.Attributes["align"]?.Value;
                        textAlign = (TextAlign)Enum.Parse(typeof(TextAlign), align);//Casting from string to enum
                        itemFormat.Align = textAlign;
                    }
                    if (textNode.Attributes["linespc"]?.Value != null)
                    {
                        linespace = Convert.ToInt32(textNode.Attributes["linespc"]?.Value);
                        itemFormat.Linespace = linespace;
                    }
                    if (textNode.Attributes["rotate"]?.Value != null)
                    {
                        rotate = Convert.ToBoolean(textNode.Attributes["rotate"]?.Value);
                        itemFormat.Rotate = rotate;
                    }
                    if (textNode.Attributes["color"]?.Value != null)
                    {
                        color = Convert.ToString(textNode.Attributes["color"]?.Value);
                        style = (ColorStyle)Enum.Parse(typeof(ColorStyle), color);//Casting from string to enum
                        itemFormat.Color = style;
                    } 
                    if (textNode.Attributes["em"]?.Value != null)
                    {
                        emphasized = Convert.ToBoolean(textNode.Attributes["em"]?.Value);
                        itemFormat.Emphasized = emphasized;
                        MessageBox.Show("em");
                    }
                    if (textNode.Attributes["ul"]?.Value != null)
                    {
                        underLine = Convert.ToBoolean(textNode.Attributes["ul"]?.Value);
                        itemFormat.UnderLine = underLine;
                        MessageBox.Show("ul");
                    }
                    if (textNode.Attributes["reverse"]?.Value != null)
                    {
                        reverse = Convert.ToBoolean(textNode.Attributes["reverse"]?.Value);
                        itemFormat.Reverse = reverse;
                    }
              
                }
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

