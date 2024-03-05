using System;
using Custom.CuCustomWndAPI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using customwebbridge.Libinterface;
using customwebbridge.Xml_parsing;
using System.IO;

namespace customwebbridge
{
    public partial class Form1 : Form
    {
        CuCustomWndAPIWrap customWndAPIWrap = null;
        CuCustomWndDevice dev = null;
        List<BaseItem> items = new List<BaseItem>();
        String str = "";

        string selectedFilePath;
        
        public Form1()
        {
            InitializeComponent();
            bt_usb.Visible = false;

        }

        private void bt_usb_Click(object sender, EventArgs e)
        {
            PrintXmlList(items);
        }
        private void ShowErrorMessage(Exception ex)
        {
            String strErrorDescription = "";
            String strErrorOrigin = "";

            if (ex.GetType() == typeof(CuCustomWndAPIWrapException))
            {
                strErrorOrigin = "CuCustomWndAPIWrapException Error";
                strErrorDescription = ((CuCustomWndAPIWrapException)ex).ErrorDescription;
            }
            else
            {
                strErrorOrigin = "Exception Error";
                strErrorDescription = ex.ToString();
            }

            //Show the messagebox
            MessageBox.Show(strErrorDescription, strErrorOrigin, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Create the Class
                customWndAPIWrap = new CuCustomWndAPIWrap(CuCustomWndAPIWrap.CcwLogVerbosity.CCW_LOG_DEEP_DEBUG, null);
                //Init the library
                customWndAPIWrap.InitLibrary();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                return;
            }
        }

        private void bt_open_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            bt_usb.Visible = true;
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                selectedFilePath = openFileDialog.FileName;

                //textParsing.ParseXml(items);
                //feedParsing.ParseXml(items);
                // Load XML document
                /*XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(selectedFilePath);
                foreach(XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    MessageBox.Show(node.Name);
                    if (node.Name == "text")
                    {
                        textParsing.ParseXml(items);
                    }
                    else
                    {
                        if (node.Name == "feed")
                        {
                            feedParsing.ParseXml(items);
                        }
                    }
                }*/

                // Assuming XML structure contains <Text> element
                Parser parser = new Parser(selectedFilePath);
                parser.Parsing(items);

                //String str = "";
                for(int i=0; i<items.Count; i++)
                {
                    str = items[i].ToString();
                    MessageBox.Show(str);
                }

                MessageBox.Show("count:"+items.Count.ToString());
            }
            catch (Exception ex) 
            {
                ShowErrorMessage(ex); 
                return; 
            }
        }
        private void PrintXmlList(List<BaseItem> items)
        {

            USBDevice[] usbArray = customWndAPIWrap.EnumUSBDevices();
            String[] strusbArray = new String[usbArray.Length];

            for (int i = 0; i < usbArray.Length; i++)
            {
                USBDevice u = usbArray[i];
                strusbArray[i] = u.SerialNumber;
            }

            if (usbArray.Length > 0)
            {
                try
                {
                    dev = customWndAPIWrap.OpenPrinterUSB(usbArray[0]);
                    MessageBox.Show("USB device paired.");
                    try
                    {
                        for (int k = 0; k < items.Count; k++)
                        {
                            PrintableText pt = new PrintableText((TextItem)items[k]);
                            //dev.PrintText(pt.Testo.Text, pt.FontSettings1, pt.BAddLF);

                            PrintFontSettings pfs = new PrintFontSettings();

                            //dev.PrintText(pt.Testo.Text, pfs, pt.BAddLF);
                            dev.PrintText(str, pt.FontSettings1, pt.BAddLF);
                            //Exec the print of the text
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);
                    }
                    try
                    {
                        //Exec Partial Cut
                        dev.Cut(CuCustomWndDevice.CutType.CUT_PARTIAL);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No USB devices found.");
            }
        }
    }
}
