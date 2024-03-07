using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;

namespace customwebbridge.Libinterface
{
    internal class PrintableImage
    {
        Bitmap bp = null;   
        PrintImageSettings Settings = new PrintImageSettings();
        //getter and setter
        public PrintImageSettings Settings1 { get => Settings; set => Settings = value; }
        public Bitmap Bp { get => bp; set => bp = value; }

        //Default Constructor 
        public PrintableImage(ImageItem item)
        {
            Bp = item.BitMap;
            Settings1.PrintScaleWidthValue = (UInt32)item.Width;
            ConvertImgScaleMode(item);
            ConvertImageAlign(item);
        }
        //this function check if the image scale to fit boc is enabled
        private void ConvertImgScaleMode(ImageItem item)
        {
            if (item.Scale1 == ImageItem.Scale.fit)
            {
                Settings1.PrintScaleMode = PrintImageSettings.ImageScale.IMAGE_SCALE_TO_FIT;
            }
            else if(item.Scale1==ImageItem.Scale.none)
            {
                Settings1.PrintScaleMode = PrintImageSettings.ImageScale.IMAGE_SCALE_NONE;

            }
        }
        //convert the align type form the basItem class to the windows api align type
        private void ConvertImageAlign(ImageItem item)
        {
            if (item.TextAlign1 == BaseItem.TextAlign.right)
            {
                Settings1.ImageAlignMode = PrintImageSettings.ImageAlign.IMAGE_ALIGN_TO_RIGHT;
            }
            else if (item.TextAlign1 == BaseItem.TextAlign.center)
            {
                Settings1.ImageAlignMode = PrintImageSettings.ImageAlign.IMAGE_ALIGN_TO_CENTER;
            }
            else { Settings1.ImageAlignMode = PrintImageSettings.ImageAlign.IMAGE_ALIGN_TO_LEFT; }
        }

    }
}
