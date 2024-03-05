using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom.CuCustomWndAPI;

namespace customwebbridge.Libinterface
{
    internal class PrintableBarcode
    {
        string barcode_data;
        PrintBarcodeSettings barcodeSettings=new PrintBarcodeSettings();

        public PrintableBarcode(Barcode2D barcode2D)
        {
            Barcode_data = barcode2D.Data;
            convert_barcode2dType(barcode2D);
            BarcodeSettings.BarcodeHeight=Convert.ToUInt32(barcode2D.Height);
            BarcodeSettings.BarcodeWidth = Convert.ToUInt32(barcode2D.Width);
        }
        public PrintableBarcode(Barcode1D barcode1D) 
        {
            Barcode_data=barcode1D.Data;    
            convert_barcode1dType(barcode1D);
            convert_HRI(barcode1D);
            BarcodeSettings.BarcodeHeight = Convert.ToUInt32(barcode1D.Height);
            BarcodeSettings.BarcodeWidth = Convert.ToUInt32(barcode1D.Width);
        }

        public string Barcode_data { get => barcode_data; set => barcode_data = value; }
        public PrintBarcodeSettings BarcodeSettings { get => barcodeSettings; set => barcodeSettings = value; }

        //convert the barcode1d type of the BarcodeItem in the barcode1d type of windows api
        private void convert_barcode1dType(Barcode1D barcode1D)
        {
            if(barcode1D.BarcodeType==Barcode1D.Type.codabar)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_CODABAR;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.upc_a)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_UPCA;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.upc_e)
            {
                BarcodeSettings.BType=PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_UPCE;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.ean13)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_EAN13;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.ean8)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_EAN8;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.code39)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_CODE39;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.code128)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_CODE128;
            }
            else if(barcode1D.BarcodeType==Barcode1D.Type.itf)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_ITF;
            }
        }
        //convert the barcode2d type of the BarcodeItem in the barcode2d type of windows api
        private void convert_barcode2dType(Barcode2D barcode2D)
        {
            if(barcode2D.TypeQRCode==Barcode2D.Type.pdf417_standard) 
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_PDF417;
            }
            else if(barcode2D.TypeQRCode == Barcode2D.Type.azteccode_compact)
            {
                BarcodeSettings.BType=PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_AZTEC;
            }
            else if(barcode2D.TypeQRCode ==Barcode2D.Type.qrcode_model_1)
            {
                BarcodeSettings.BType = PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_QRCODE;
            }
            else
            {
                BarcodeSettings.BType=PrintBarcodeSettings.BarcodeType.BARCODE_TYPE_DATAMATRIX;
            }

        }
        private void convert_HRI(Barcode1D barcode1D)
        {
            if(barcode1D.Hri1==Barcode1D.HRI.None)
            {
                BarcodeSettings.HRIPosition = PrintBarcodeSettings.BarcodeHRIPosition.BARCODE_HRI_NONE;
            }
            else if(barcode1D.Hri1==Barcode1D.HRI.Below)
            {
                BarcodeSettings.HRIPosition = PrintBarcodeSettings.BarcodeHRIPosition.BARCODE_HRI_BOTTOM;
            }
            else if(barcode1D.Hri1==Barcode1D.HRI.Above)
            {
                BarcodeSettings.HRIPosition = PrintBarcodeSettings.BarcodeHRIPosition.BARCODE_HRI_TOP;
            }
            else
            {
                BarcodeSettings.HRIPosition = PrintBarcodeSettings.BarcodeHRIPosition.BARCODE_HRI_TOPBOTTOM;
            }
        }
        /*private void convert_align()
        {
            if()
                {
                    
                }
            else if()
                {
                    
                }
             else
        }*/
    }
}
