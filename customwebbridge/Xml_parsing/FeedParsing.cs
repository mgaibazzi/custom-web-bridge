using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace customwebbridge.Xml_parsing
{
    internal class FeedParsing
    {
        string path;
        
        //defeault constructor 
        public FeedParsing()
        {
        }
        //getter and setter
        public string Path
        {
            get { return path; }
            set { if (value != null) path = value; else throw new Exception("String null"); }
        }
        //this funtion is used to parse the Item Feed
        public void ParseNodeXml(List<BaseItem> items,XmlNode feedNode, BaseItem baseFormat)
        {
            int line;
            int unit;
            try
            {
                FeedItem feedItem = new FeedItem();

                unit = 0;
                line = 0;
                //check if the attributes are null
                if (feedNode.Attributes["line"]?.Value != null)
                { 
                    line = Convert.ToInt32(feedNode.Attributes["line"].Value);
                    feedItem.Line = line;
                }
                else
                {
                    if (feedNode.Attributes["unit"]?.Value != null)
                    {
                        unit = Convert.ToInt32(feedNode.Attributes["unit"].Value);
                        feedItem.Unit = unit;
                    }
                    if(feedNode.Attributes[""]?.Value == null)
                    {
                        line++;
                        feedItem.Line = line; 
                    }
                }
                feedItem.setCommonVariabiles(baseFormat);
                items.Add(feedItem);
            }
            catch (Exception e)
            {
                {
                    MessageBox.Show("Error parsing XML: " + e.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
