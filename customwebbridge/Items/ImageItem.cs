using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge
{
    public class ImageItem : BaseItem
    {
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
        //bool scale;
        //double brightness;//0.1-10

        Mode mode;
        Color color;
        //Halftone halftone;


        public ImageItem() : base(BaseItem.ItemType.image)
        {
            Width = 30;
            Height = 30;
            StrImage = "";
            //Scale = false;
            mode = Mode.mono;
            //Brightness = 1.0;
            color = Color.color_1;
        }


        public ImageItem(int width, int height, string strImage,  Mode md, Color col) : base(BaseItem.ItemType.image)
        {
            this.Width = width;
            this.Height = height;
            this.StrImage = strImage;
            //this.scale = scale;
            //this.brightness = brightness;
            this.color = col;
            this.mode = md;
        }

        public int Width
        {
            get { return width; }
            set
            {
                if (value < 1 && value > 256)
                {
                    throw new Exception("Uncorrect value");
                }
                else width = value;

            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value < 1 && value > 256)
                {
                    throw new Exception("Uncorrect value");
                }
                else height = value;

            }
        }

        /*public double Brightness
        {
            get { return brightness; }
            set
            {
                if (value < 0.1 && value > 10)
                {
                    throw new Exception("Uncorrect value");
                }
                else brightness = value;

            }
        }*/
        //public bool Scale { get => scale; set => scale = value; }
        public Mode Mode1 { get => mode; set => mode = value; }
        public Color Color1 { get => color; set => color = value; }
        public string StrImage { get => strImage; set => strImage = value; }

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
