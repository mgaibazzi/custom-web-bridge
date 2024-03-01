using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace customwebbridge.Xml_parsing
{
    internal class Parser
    {
        string selectedFilePath;
        public Parser(string selectedFilePath)
        { this.selectedFilePath = selectedFilePath; }


        TextParsing textParsing = new TextParsing();
        FeedParsing feedParsing = new FeedParsing();
        BarcodeParsing barcodeParsing = new BarcodeParsing();
        public void Parsing(List<BaseItem> items)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(selectedFilePath);
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                
                MessageBox.Show(node.Name);
                if (node.Name == "text")
                {
                    textParsing.ParseNodeXml(node, items);
                }
                else
                {
                    if (node.Name == "feed")
                    {
                        feedParsing.ParseNodeXml(items, node);
                    }
                    else 
                    {
                        if (node.Name == "barcode")
                        {
                            barcodeParsing.Barcode1DParsing(node,items);
                        }
                        else
                        {
                            if(node.Name == "symbol")
                            {
                                barcodeParsing.Barcode2DParsing(node, items);
                            }
                        }
                    }
                }
            }               

        }
    }
}
