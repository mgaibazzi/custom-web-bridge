using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;

namespace customwebbridge.Libinterface
{
    internal class PrintableImage
    {
        string ImagePath = "";
        PrintImageSettings Settings = new PrintImageSettings();
        //getter and setter
        public string ImagePath1 { get => ImagePath; set => ImagePath = value; }
        public PrintImageSettings Settings1 { get => Settings; set => Settings = value; }

        //Default Constructor 
        public PrintableImage(string path,ImageItem item) 
        {
            ImagePath1 = path;
            Settings1.PrintScaleWidthValue = (UInt32)item.Width;
            ConvertImgScaleMode(item);
            ConvertImageAlign(item); 
        }
        public void ConvertImgScaleMode(ImageItem item) 
        {
            if(item.Scale==true)
            {
                Settings1.PrintScaleMode = PrintImageSettings.ImageScale.IMAGE_SCALE_TO_FIT;
            }
            else
            {
                Settings1.PrintScaleMode = PrintImageSettings.ImageScale.IMAGE_SCALE_TO_WIDTH;

            }
        }
        //convert the align type form the basItem class to the windows api align type
        public void ConvertImageAlign(ImageItem item)   
        {
            if(item.TextAlign1==BaseItem.TextAlign.right)
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
