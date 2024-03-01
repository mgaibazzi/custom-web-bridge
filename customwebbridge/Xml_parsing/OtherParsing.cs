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
        public void BuzzerParser(XmlNode textNode, List<BaseItem> items)
        {
            OthersItem.Pattern pattern = OthersItem.Pattern.pattern_a;
            int repeat = 1;
            string pt = "";

            OthersItem itemFormat = new OthersItem();

            try
            {                
                if (textNode.Attributes["repeat"]?.Value != null)
                {
                    repeat = Convert.ToInt32(textNode.Attributes["repeat"]?.Value);
                    itemFormat.Repeat = repeat;
                }
                if (textNode.Attributes["pattern"]?.Value != null)
                {
                    pt = textNode.Attributes["pattern"]?.Value;
                    pattern = (OthersItem.Pattern)Enum.Parse(typeof(OthersItem.Pattern), pt);//Casting from string to enum
                    itemFormat.Pattern1 = pattern;
                }
                items.Add(itemFormat);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CutParser(XmlNode textNode, List<BaseItem> items)
        {
            OthersItem.Type type = OthersItem.Type.feed;
            string ty = "";

            OthersItem itemFormat = new OthersItem();

            try
            {
                if (textNode.Attributes["pattern"]?.Value != null)
                {
                    ty = textNode.Attributes["pattern"]?.Value;
                    type = (OthersItem.Type)Enum.Parse(typeof(OthersItem.Type), ty);//Casting from string to enum
                    itemFormat.Type1 = type;
                }
                items.Add(itemFormat);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DrawerParser(XmlNode textNode, List<BaseItem> items)
        {
            OthersItem.ONTime oNTime = OthersItem.ONTime.pulse_100;
            OthersItem.Connector connector = OthersItem.Connector.drawer_1;
            string ot = "";
            string cn = "";

            OthersItem itemFormat = new OthersItem();

            try
            {
                if (textNode.Attributes["time"]?.Value != null)
                {
                    ot = textNode.Attributes["time"]?.Value;
                    oNTime = (OthersItem.ONTime)Enum.Parse(typeof(OthersItem.ONTime), ot);//Casting from string to enum
                    itemFormat.OnTime = oNTime;
                }
                if (textNode.Attributes["drawer"]?.Value != null)
                {
                    ot = textNode.Attributes["drawer"]?.Value;
                    connector = (OthersItem.Connector)Enum.Parse(typeof(OthersItem.Connector), cn);//Casting from string to enum
                    itemFormat.Connector1 = connector;
                }
                items.Add(itemFormat);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ResetParser(XmlNode textNode, List<BaseItem> items)
        {
            bool reset = false;
            string rt = "";

            OthersItem itemFormat = new OthersItem();

            try
            {
                if (textNode.Attributes[""]?.Value != null)
                {
                    reset = Convert.ToBoolean(textNode.Attributes[""]?.Value);
                    itemFormat.Reset = reset;
                }
                items.Add(itemFormat);
            }
            catch (Exception ex)
            {
                // Handle XML parsing errors
                MessageBox.Show("Error parsing XML: " + ex.Message, "XML Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EscParser(XmlNode textNode, List<BaseItem> items)
        {
            string esc = "1b2a210100555550a";

            OthersItem itemFormat = new OthersItem();

            try
            {
                esc = textNode.InnerText;
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
