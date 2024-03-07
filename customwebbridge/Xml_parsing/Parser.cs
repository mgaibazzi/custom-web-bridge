using customwebbridge.Decode;
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
        /*public enum TextAlign
        {
            left,
            center,
            right
        }
        public int linespace = 30;
        public bool rotate = false;
        TextAlign textAlign = TextAlign.left;*/
        public Parser(string selectedFilePath)
        { this.selectedFilePath = selectedFilePath; }


        TextParsing textParsing = new TextParsing();
        FeedParsing feedParsing = new FeedParsing();
        BarcodeParsing barcodeParsing = new BarcodeParsing();
        ImageParsing imageParsing = new ImageParsing();
        //DecodeBase64 decodeBase64 = new DecodeBase64();
        public void Parsing(List<BaseItem> items)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(selectedFilePath);
            
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                
                //MessageBox.Show(node.Name);
                if (node.Name == "text")
                {
                    textParsing.ParseNodeXml(node, items);

                }
                else
                {
                    if (node.Name == "feed")
                    {
                        feedParsing.ParseNodeXml(items, node, textParsing.GetFormat());
                    }
                    else 
                    {
                        if (node.Name == "barcode")
                        {
                            barcodeParsing.Barcode1DParsing(node,items, textParsing.GetFormat());
                        }
                        else
                        {
                            if(node.Name == "symbol")
                            {
                                barcodeParsing.Barcode2DParsing(node, items, textParsing.GetFormat());
                            }
                            else
                            {
                                OtherParsing otherParsing = new OtherParsing();
                                if(node.Name =="sound")
                                    otherParsing.BuzzerParser(node, items);
                                else
                                {
                                    if(node.Name == "cut" )
                                        otherParsing.CutParser(node, items);
                                    else 
                                    { 
                                        if(node.Name == "pulse")
                                            otherParsing.DrawerParser(node, items); 
                                        else
                                        {
                                            if(node.Name == "reset")
                                                otherParsing.ResetParser(node, items);
                                            else
                                            {
                                                if (node.Name == "command")
                                                    otherParsing.EscParser(node, items);
                                                else
                                                {
                                                    if (node.Name == "image")
                                                    {
                                                        imageParsing.ParseNodeXml(node, items);
                                                        //decodeBase64.Decode(items)
                                                    }
                                                    else throw new Exception("Value not found!");
                                                } 
                                            }
                                        }    
                                    }
                                }
                            }
                        }
                    }
                }
            }               
        }
    }
}
