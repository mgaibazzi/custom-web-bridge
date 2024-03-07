using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class BuzzerItem : BaseItem
    {
        //buzzer pattern enum
        public enum Pattern
        {
            pattern_a,
            pattern_b,
            pattern_c,
            pattern_d,
            pattern_e,
            pattern_0,
            pattern_1,
            pattern_2,
            pattern_3,
            pattern_4,
            pattern_5,
            pattern_6,
            pattern_7,
            pattern_8,
            pattern_9,
            pattern_10,
            none,
            error,
            paper_end
        }//buzzer
        int repeat; // buzzer  1-255
        Pattern pattern;

        //default constructor 
        public BuzzerItem() : base(ItemType.sound)
        {
            this.Pattern1 = Pattern.pattern_a;
            this.Repeat = 1;
        }
        //parameterized constructor 
        public BuzzerItem(int repeat, Pattern pattern) : base(ItemType.sound)
        {
            this.pattern = pattern;
            Repeat = repeat;
        }


        //GEtter and setter
        public int Repeat
        {
            get { return repeat; }
            set
            {
                if (value < 1 && value > 255)
                {
                    throw new Exception("Uncorrect value");
                }
                else repeat = value;

            }
        }
        internal Pattern Pattern1 { get => pattern; set => pattern = value; }
    }
}
