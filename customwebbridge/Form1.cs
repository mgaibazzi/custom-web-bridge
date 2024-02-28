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

namespace customwebbridge
{
    public partial class Form1 : Form
    {
        CuCustomWndAPIWrap customWndAPIWrap = null;
        CuCustomWndDevice dev = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_usb_Click(object sender, EventArgs e)
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
                    
                    
                    String strTextToPrint = "Marco";

                    PrintFontSettings pfs = new PrintFontSettings();
                    try
                    {
                        //Exec the print of the text
                        dev.PrintText(strTextToPrint, pfs, true);
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
    }
}
