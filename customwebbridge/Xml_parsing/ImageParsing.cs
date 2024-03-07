using customwebbridge.Decode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static customwebbridge.ImageItem;
using static customwebbridge.TextItem;

namespace customwebbridge.Xml_parsing
{
    public class ImageParsing
    {
        DecodeBase64 decodeBase64 = new DecodeBase64();
        //this funtion is used to parse the Item Image
        public void ParseNodeXml(XmlNode imageNode, List<BaseItem> items)
        {
            Mode mode = new Mode();
            Color color = new Color();
            Scale scale = new Scale();
            int width;
            int height;
            string md,cl,sc;


            try
            {
                ImageItem imageItem = new ImageItem();
                imageItem.StrImage = imageNode.InnerText;
                if (imageNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(imageNode.Attributes["width"].Value);
                    imageItem.Width = width;
                }
                else if (imageNode.Attributes["height"]?.Value != null)
                {
                    height = Convert.ToInt32(imageNode.Attributes["height"].Value);
                    imageItem.Height = height;
                }
                else if (imageNode.Attributes["color"]?.Value != null)
                {
                    cl = Convert.ToString(imageNode.Attributes["color"]?.Value);
                    color = (Color)Enum.Parse(typeof(Color), cl);//Casting from string to enum
                    imageItem.Color1 = color;
                }
                else if (imageNode.Attributes["scale"]?.Value != null)
                {
                    sc = Convert.ToString(imageNode.Attributes["scale"]?.Value);
                    scale = (Scale)Enum.Parse(typeof(Scale), sc);//Casting from string to enum
                    imageItem.Scale1 = scale;
                }
                else if (imageNode.Attributes["mode"]?.Value != null)
                {
                    md = Convert.ToString(imageNode.Attributes["mode"]?.Value);
                    mode = (Mode)Enum.Parse(typeof(Mode), md);//Casting from string to enum
                    imageItem.Mode1 = mode;
                }
                decodeBase64.Decode(imageItem);
                items.Add(imageItem);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
