using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge
{
    public class FeedItem : BaseItem
    {
        int line;//0-255
        int unit;//0-255

        public FeedItem() : base(BaseItem.ItemType.feed)
        {
            line = 0;
            unit = 0;
        }

        public FeedItem(int line, int unit) : base(BaseItem.ItemType.feed)
        {
            this.Line = line;
            this.Unit = unit;
        }

        public int Line
        {
            get { return line; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Uncorrect value");
                }
                else line = value;

            }
        }


        public int Unit
        {
            get { return unit; }
            set
            {
                if (value < 0 && value > 2399)
                {
                    throw new Exception("Valore non corretto");
                }
                else unit = value;

            }
        }
        public override string ToString()
        {
            string str = "Unit: " + Unit + "\n"
                    +"Line: " + Line + "\n"
                    + base.ToString();
            return str;
        }
    }
}
