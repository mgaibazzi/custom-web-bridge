using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge
{
    public class ImageItem : BaseItem
    {
        Bitmap bitMap;
        public enum Scale
        {
            none,
            width,
            fit
        }
        public enum Mode
        {
            mono,
            gray16,
            gray256
        }
        public enum Color
        {
            color_1,
            color_2,
            color_3,
            color_4,
        }
        /*public enum Halftone
        {
            dither,
            error_diffusion,
            threshold
        }*/
         
        int width;//1-256
        int height;//1-256
        string strImage = "";   //codified image

        //double brightness;//0.1-10
        Scale scale;
        Mode mode;
        Color color;
        //Halftone halftone;


        public ImageItem() : base(BaseItem.ItemType.image)
        {
            Width = 30;
            Height = 30;
            StrImage = "";
            Scale1 = Scale.none;
            Mode1 = Mode.mono;
            Color1 = Color.color_1;
        }


        public ImageItem(int width, int height, string strImage,  Mode md, Color col,Scale scale) : base(BaseItem.ItemType.image)
        {
            this.Width = width;
            this.Height = height;
            this.StrImage = strImage;
            this.color = col;
            this.mode = md;
            this.Scale1 = scale;
        }

        public int Width
        {
            get { return width; }
            set
            {
                 width = value;

            }
        }
        public int Height
        {
            get { return height; }
            set
            {

                height = value;

            }
        }



        public Mode Mode1 { get => mode; set => mode = value; }
        public Color Color1 { get => color; set => color = value; }
        public string StrImage { get => strImage; set => strImage = value; }
        public Bitmap BitMap { get => bitMap; set => bitMap = value; }
        public Scale Scale1 { get => scale; set => scale = value; }

        public override string ToString()
        {
            string str = "width: " + Width + "\n"
                    + "height: " + Height + "\n"
                    + base.ToString() 
                    +"color: " + Color1 + "\n"
                    +"Mode: " + Mode1 + "\n"
                    +"str: " + StrImage
                    +"\n\n\n\n";
            return str;
        }

    }
}
