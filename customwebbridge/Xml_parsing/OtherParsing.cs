using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static customwebbridge.OthersItem;
using static customwebbridge.TextItem;

namespace customwebbridge.Xml_parsing
{
    internal class OtherParsing
    {
        public void BuzzerParser(XmlNode textNode, List<BaseItem> items)//Parsing Buzzer
        {
            OthersItem.Pattern pattern = OthersItem.Pattern.pattern_a;
            int repeat = 1;
            string pt = "";//support variables that we use to cast an enum

            OthersItem item= new OthersItem();

            try
            {                
                if (textNode.Attributes["repeat"]?.Value != null)
                {
                    repeat = Convert.ToInt32(textNode.Attributes["repeat"]?.Value);
                    item.Repeat = repeat;
                }
                if (textNode.Attributes["pattern"]?.Value != null)
                {
                    pt = textNode.Attributes["pattern"]?.Value;
                    pattern = (OthersItem.Pattern)Enum.Parse(typeof(OthersItem.Pattern), pt);//Casting from string to enum
                    item.Pattern1 = pattern;
                }
                items.Add(item);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CutParser(XmlNode textNode, List<BaseItem> items)//Parsing CUT
        {
            OthersItem.Type type = OthersItem.Type.feed;
            string ty = "";//support variables that we use to cast an enum

            OthersItem item = new OthersItem();

            try
            {
                if (textNode.Attributes["type"]?.Value != null)
                {
                    ty = textNode.Attributes["type"]?.Value;
                    type = (OthersItem.Type)Enum.Parse(typeof(OthersItem.Type), ty);//Casting from string to enum
                    item.Type1 = type;
                }
                items.Add(item);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DrawerParser(XmlNode textNode, List<BaseItem> items)//parsing DRAWER
        {
            OthersItem.ONTime oNTime = OthersItem.ONTime.pulse_100;
            OthersItem.Connector connector = OthersItem.Connector.drawer_1;
            string ot = "";//support variables that we use to cast an enum
            string cn = "";//support variables that we use to cast an enum

            OthersItem item = new OthersItem();

            try
            {
                if (textNode.Attributes["drawer"]?.Value != null)
                {
                    cn = textNode.Attributes["drawer"]?.Value;
                    connector = (OthersItem.Connector)Enum.Parse(typeof(OthersItem.Connector), cn);//Casting from string to enum
                    item.Connector1 = connector;
                }
                if (textNode.Attributes["time"]?.Value != null)
                {
                    ot = textNode.Attributes["time"]?.Value;
                    oNTime = (OthersItem.ONTime)Enum.Parse(typeof(OthersItem.ONTime), ot);//Casting from string to enum
                    item.OnTime = oNTime;
                }
                
                items.Add(item);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        public void ResetParser(XmlNode textNode, List<BaseItem> items)//Parsing RESET
        {
            bool reset = false;

            OthersItem item = new OthersItem();

            try
            {
                item.Reset = true;
                items.Add(item);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EscParser(XmlNode textNode, List<BaseItem> items)//parsing ESC
        {
            string esc = "1b2a210100555550a";

            OthersItem item = new OthersItem();

            try
            {
                esc = textNode.InnerText;
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