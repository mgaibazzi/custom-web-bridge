using customwebbridge.Items;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static customwebbridge.TextItem;

namespace customwebbridge.Xml_parsing
{
    internal class OtherParsing
    {
        //this funtion is used to parse the Item Buzzer
        public void BuzzerParser(XmlNode textNode, List<BaseItem> items)//Parsing Buzzer
        {
            BuzzerItem.Pattern pattern = BuzzerItem.Pattern.pattern_a;
            int repeat = 1;
            string pt = "";//support variables that we use to cast an enum
            BuzzerItem item= new BuzzerItem();

            try
            {//check if the value are null                
                if (textNode.Attributes["repeat"]?.Value != null)
                {
                    repeat = Convert.ToInt32(textNode.Attributes["repeat"]?.Value);
                    item.Repeat = repeat;
                }
                else if (textNode.Attributes["pattern"]?.Value != null)
                {
                    pt = textNode.Attributes["pattern"]?.Value;
                    pattern = (BuzzerItem.Pattern)Enum.Parse(typeof(BuzzerItem.Pattern), pt);//Casting from string to enum
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
        //this funtion is used to parse the Item Cut
        public void CutParser(XmlNode textNode, List<BaseItem> items)//Parsing CUT
        {
            CutItem.Type type = CutItem.Type.feed;
            string ty = "";//support variables that we use to cast an enum

            CutItem item = new CutItem();

            try
            {//check if the value are null
                if (textNode.Attributes["type"]?.Value != null)
                {
                    ty = textNode.Attributes["type"]?.Value;
                    type = (CutItem.Type)Enum.Parse(typeof(CutItem.Type), ty);//Casting from string to enum
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
        //this funtion is used to parse the Item Drawer
        public void DrawerParser(XmlNode textNode, List<BaseItem> items)//parsing DRAWER
        {
            DrawerItem.ONTime oNTime = DrawerItem.ONTime.pulse_100;
            DrawerItem.Connector connector = DrawerItem.Connector.drawer_1;
            string ot = "";//support variables that we use to cast an enum
            string cn = "";//support variables that we use to cast an enum

            DrawerItem item = new DrawerItem();

            try
            { //check if the value are null
                if (textNode.Attributes["drawer"]?.Value != null)
                {
                    cn = textNode.Attributes["drawer"]?.Value;
                    connector = (DrawerItem.Connector)Enum.Parse(typeof(DrawerItem.Connector), cn);//Casting from string to enum
                    item.Connector1 = connector;
                }
                else if (textNode.Attributes["time"]?.Value != null)
                {
                    ot = textNode.Attributes["time"]?.Value;
                    oNTime = (DrawerItem.ONTime)Enum.Parse(typeof(DrawerItem.ONTime), ot);//Casting from string to enum
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
        //this funtion is used to parse the Item Reset
        public void ResetParser(XmlNode textNode, List<BaseItem> items)//Parsing RESET
        {
            //bool reset = false;

            ResetItem item = new ResetItem();

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
        //this funtion is used to parse the Item Esc
        public void EscParser(XmlNode textNode, List<BaseItem> items)//parsing ESC
        {
            string esc = "1b2a210100555550a";

            EscItem item = new EscItem();

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