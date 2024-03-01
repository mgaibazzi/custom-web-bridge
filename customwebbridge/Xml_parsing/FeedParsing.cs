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
        

        public FeedParsing()
        {
        }
        public string Path
        {
            get { return path; }
            set { if (value != null) path = value; else throw new Exception("String null"); }
        }
        public void ParseNodeXml(List<BaseItem> items,XmlNode feedNode)
        {
            int line;
            int unit;
            try
            {


                unit = 0;
                    line = 0;
                    if (feedNode.Attributes["line"]?.Value != null)
                        line = Convert.ToInt32(feedNode.Attributes["line"].Value);
                    else
                    {
                        if (feedNode.Attributes["unit"]?.Value != null)
                            unit = Convert.ToInt32(feedNode.Attributes["unit"].Value);
                        else
                        {
                            if (feedNode.Attributes[""]?.Value == null)
                                line++;
                        }
                    }

                FeedItem feedItem = new FeedItem(line, unit);
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
