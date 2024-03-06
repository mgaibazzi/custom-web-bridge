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
        USBDevice[] usbArray = null;

        string selectedFilePath;

        public Form1()
        {
            InitializeComponent();
            bt_print.Visible = false;
        }

        private void bt_print_Click(object sender, EventArgs e)
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
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                selectedFilePath = openFileDialog.FileName;

                // Assuming XML structure contains <Text> element
                Parser parser = new Parser(selectedFilePath);
                items.Clear();
                parser.Parsing(items);

                str = "";
                for (int i = 0; i < items.Count; i++)
                {
                    str += items[i].ToString();

                }
                //MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                return;
            }
            bt_pair_USB.Visible = true;
        }
        private void PrintXmlList(List<BaseItem> items)
        {


            if ( (cb_select_USB.SelectedIndex != -1) && (usbArray!=null) && (usbArray.Length > 0) )
            {
                try
                {
                    int selected = cb_select_USB.SelectedIndex;
                    //Open the device
                    dev = customWndAPIWrap.OpenPrinterUSB(usbArray[selected]);
                    bt_print.Visible = true;
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                    return;
                }
            }


            try
            {

                Printable printable = new Printable();
                foreach (BaseItem item in items)
                {
                    printable.PrintItem(item, dev);
                }
                dev.Terminate();

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void cb_select_USB_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_print.Visible = true;
        }

        private void bt_pair_USB_Click(object sender, EventArgs e)
        {
            cb_select_USB.SelectedIndex = -1;
            cb_select_USB.Items.Clear();
            cb_select_USB.Visible = true;
            usbArray = customWndAPIWrap.EnumUSBDevices();
            String[] strusbArray = new String[usbArray.Length];

            for (int i = 0; i < usbArray.Length; i++)
            {
                USBDevice u = usbArray[i];
                strusbArray[i] = u.SerialNumber;
                cb_select_USB.Items.Add(strusbArray[i]);
            }
        }
    }
}