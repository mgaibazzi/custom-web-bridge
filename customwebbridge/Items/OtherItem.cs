using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge
{
    public class OthersItem : BaseItem
    {
        public enum Type//cut
        {
            feed,
            no_feed,
            reserve
        }
        public enum Connector//drawer
        {
            drawer_1,
            drawer_2
        }
        public enum ONTime//drawer
        {
            pulse_100,
            pulse_200,
            pulse_300,
            pulse_400,
            pulse_500
        }
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
        bool reset;
        string esc;
        Pattern pattern;
        Type type;
        Connector connector;
        ONTime onTime;

        public OthersItem() : base(BaseItem.ItemType.other)
        {
            onTime = ONTime.pulse_100;
            pattern = Pattern.pattern_a;
            type = Type.feed;
            connector = Connector.drawer_1;
            repeat = 1;
            reset = false;
            esc = "1b2a210100555550a";
        }

        public OthersItem(int repeat, Pattern pattern1) : base(BaseItem.ItemType.other)//buzzer constructor
        {
            this.repeat = repeat;
            this.pattern = pattern1;
        }
        public OthersItem(Type type1): base(BaseItem.ItemType.other)//cut constructor
        {
            this.type = type1;
        }
        public OthersItem(bool reset) : base(BaseItem.ItemType.other)//reset constructor
        {
            this.reset = reset;
        }
        public OthersItem(string esc) : base(BaseItem.ItemType.other)//esc constructor
        {
            this.esc = esc;
        }
        public OthersItem(ONTime oNTime,Connector connector) : base(BaseItem.ItemType.other)//drawer constructor
        {
            this.connector = connector;
            this.onTime = oNTime;
        }

        

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
        public bool Reset { get => reset; set => reset = value; }
        public string Esc { get => esc; set => esc = value; }
        internal Pattern Pattern1 { get => pattern; set => pattern = value; }
        internal Type Type1 { get => type; set => type = value; }
        internal Connector Connector1 { get => connector; set => connector = value; }
        internal ONTime OnTime { get => onTime; set => onTime = value; }
    }
}
