using System;
using System.Collections.Generic;
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
            gray
        }
        public enum Color
        {
            color_1,
            color_2,
            color_3,
            color_4,
        }
        public enum Halftone
        {
            dither,
            error_diffusion,
            threshold
        }

        int width;//1-256
        int height;//1-256
        string image = "";   //codified image
        bool scale;
        double brightness;//0.1-10

        Mode mode;
        Color color;
        Halftone halftone;


        public ImageItem() : base(BaseItem.ItemType.image)
        {
            Width = 30;
            Height = 30;
            Path = "";
            Scale = false;
            mode = Mode.mono;
            Brightness = 1.0;
            color = Color.color_1;
            halftone = Halftone.dither;
        }


        public ImageItem(int width, int height, string path, bool scale, Mode md, double brightness, Color col, Halftone half) : base(BaseItem.ItemType.image)
        {
            this.width = width;
            this.height = height;
            this.image = path;
            this.scale = scale;
            this.brightness = brightness;
            this.color = col;
            this.halftone = half;
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

        public double Brightness
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
        }
        public string Path { get => image; set => image = value; }
        public bool Scale { get => scale; set => scale = value; }
        internal Mode Mode1 { get => mode; set => mode = value; }
        internal Color Color1 { get => color; set => color = value; }
        internal Halftone Halftone1 { get => halftone; set => halftone = value; }
    }
}
