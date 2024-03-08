using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace customwebbridge
{
    public class BaseItem
    {
        //Align type enume
        public enum TextAlign
        {
            left,
            center,
            right
        }
        //Item type enum
        public enum ItemType
        {
            text,
            image,
            feed,
            cut,
            pulse,
            command,
            reset,
            sound,
            other,
            esc,
            barcode,
            qrcode,
            none
        }
        //variables 
        ItemType itemtype;
        TextAlign textAlign;
        public int linespace;
        public bool rotate;


        //constructor

        public BaseItem(ItemType itemtype)
        {
            this.itemtype = itemtype;

            this.TextAlign1 = TextAlign.left;
            this.rotate = false;
            this.linespace = 30;
        }
        //getter and setter 
        public ItemType Itemtype { get => itemtype; set => itemtype = value; }
        public int Linespace
        {
            get { return linespace; }
            set
            {
                if (value < 0 && value > 255)
                {
                    throw new Exception("Uncorrect value");
                }
                else linespace = value;

            }
        }
        public bool Rotate { get => rotate; set => rotate = value; }
        public TextAlign TextAlign1 { get => textAlign; set => textAlign = value; }


        
        //this variable is used to get the value of rotate,linespace,textalign from a BaseItem object
        public void setCommonVariabiles(BaseItem bitem) 
        { 
            this.Rotate= bitem.Rotate;
            this.Linespace = bitem.Linespace;
            this.TextAlign1 = bitem.TextAlign1;
        }
        //ToString of the BaseItem class
        public override string ToString()
        {
            string str;
                str= "Align:" + TextAlign1.ToString()
                + "Linespace: " +Linespace.ToString() + "\n"
                +"Rotate:"+Rotate.ToString() + "\n";
            return str;
        }
    }
}
