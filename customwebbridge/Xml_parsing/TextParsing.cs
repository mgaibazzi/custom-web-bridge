﻿using System;
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
        TextItem itemFormat = new TextItem();
        //ItemFormat = new TextItem();
        public TextParsing()
        {
            ItemFormat = new TextItem();
        }
        //get itemformat
        private TextItem ItemFormat { get => itemFormat; set => itemFormat = value; }
        public TextItem GetFormat()
        {
            return ItemFormat;
        }

        public void ParseNodeXml(XmlNode textNode, List<BaseItem> items)
        {
            TextItem.ColorStyle style = TextItem.ColorStyle.color_1;
            BaseItem.TextAlign textAlign = BaseItem.TextAlign.left;
            TextItem.FontStyle fontStyle = TextItem.FontStyle.font_a;
            TextItem.Language language = TextItem.Language.en;
            string textContent = null;
            string align = "left";//support variables that we use to cast an enum
            int x = 0;
            int y = 0;
            int width = 1;
            int height = 1;
            string lang = "en";//support variables that we use to cast an enum
            string font = "font_a";//support variables that we use to cast an enum
            bool smooth = false;
            bool doubleHeight = false;
            bool doubleWidth = false;
            bool reverse = false;
            bool underLine = false;
            bool emphasized = false;
            string color = "Color_1";//support variables that we use to cast an enum
            int linespace = 30;
            bool rotate = false;
            try
            {
                // Extract text content and display
                textContent = textNode.InnerText;

                if (!String.IsNullOrEmpty(textContent))
                {
                    TextItem item_copy = new TextItem(ItemFormat);
                    item_copy.Text = textContent;
                    itemFormat.X = 0;
                    items.Add(item_copy);
                }
                //thid if check what type of attributes the xml give you and give the value to the correct variable
                if (textNode.Attributes["width"]?.Value != null)
                {
                    width = Convert.ToInt32(textNode.Attributes["width"]?.Value);
                    ItemFormat.Width = width;
                }
                 if (textNode.Attributes["height"]?.Value != null)
                {
                    height = Convert.ToInt32(textNode.Attributes["height"]?.Value);
                    ItemFormat.Height = height;
                }
                 if (textNode.Attributes["lang"]?.Value != null)
                {
                    lang = textNode.Attributes["lang"]?.Value;
                    if(lang!="en"&&lang!="ja"&&lang!="ko")
                    {
                        lang = lang.Replace("-", "_");
                    }
                    language = (Language)Enum.Parse(typeof(Language), lang);//Casting from string to enum
                    ItemFormat.Lang = language;
                }
                 if (textNode.Attributes["font"]?.Value != null)
                {
                    font = Convert.ToString(textNode.Attributes["font"]?.Value);
                    fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), font);//Casting from string to enum
                    ItemFormat.Font = fontStyle;
                }
                if (textNode.Attributes["dh"]?.Value != null)
                {
                    doubleHeight = Convert.ToBoolean(textNode.Attributes["dh"]?.Value);
                    ItemFormat.DoubleHeight = doubleHeight;
                    if (ItemFormat.DoubleHeight == false)
                        ItemFormat.Height = 1;
                    else
                        ItemFormat.Height = 1;
                    
                    if (textNode.Attributes["dw"]?.Value != null)
                    {
                        doubleWidth = Convert.ToBoolean(textNode.Attributes["dw"]?.Value);
                        ItemFormat.DoubleWidth = doubleWidth;
                        if (ItemFormat.DoubleWidth == false)
                            ItemFormat.Width = 1;
                        else
                            ItemFormat.Width = 1;
                    }
                }
                 if (textNode.Attributes["y"]?.Value != null)
                {
                    y = Convert.ToInt32(textNode.Attributes["y"]?.Value);
                    ItemFormat.Y = y;
                }
                 if (textNode.Attributes["x"]?.Value != null)
                {
                    x = Convert.ToInt32(textNode.Attributes["x"]?.Value);
                    ItemFormat.X = x;
                }
                 if (textNode.Attributes["smooth"]?.Value != null)
                {
                    smooth = Convert.ToBoolean(textNode.Attributes["smooth"]?.Value);
                    ItemFormat.Smooth = smooth;
                }
                if (textNode.Attributes["align"]?.Value != null)
                {
                    align = textNode.Attributes["align"]?.Value;
                    textAlign = (BaseItem.TextAlign)Enum.Parse(typeof(BaseItem.TextAlign), align);//Casting from string to enum
                    ItemFormat.TextAlign1 = textAlign;//
                }
                if (textNode.Attributes["linespc"]?.Value != null)
                {
                    linespace = Convert.ToInt32(textNode.Attributes["linespc"]?.Value);
                    ItemFormat.Linespace = linespace;//
                }
                 if (textNode.Attributes["rotate"]?.Value != null)
                {
                    rotate = Convert.ToBoolean(textNode.Attributes["rotate"]?.Value);
                    ItemFormat.Rotate = rotate;//
                }
                 if (textNode.Attributes["color"]?.Value != null)
                {
                    color = Convert.ToString(textNode.Attributes["color"]?.Value);
                    style = (ColorStyle)Enum.Parse(typeof(ColorStyle), color);//Casting from string to enum
                    ItemFormat.Color = style;
                }
                 if (textNode.Attributes["em"]?.Value != null)
                {
                    emphasized = Convert.ToBoolean(textNode.Attributes["em"]?.Value);
                    ItemFormat.Emphasized = emphasized;
                    //MessageBox.Show("em");
                }
                 if (textNode.Attributes["ul"]?.Value != null)
                {
                    underLine = Convert.ToBoolean(textNode.Attributes["ul"]?.Value);
                    ItemFormat.UnderLine = underLine;
                    //MessageBox.Show("ul");
                }
                else
                {
                    reverse = Convert.ToBoolean(textNode.Attributes["reverse"]?.Value);
                    ItemFormat.Reverse = reverse;
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
