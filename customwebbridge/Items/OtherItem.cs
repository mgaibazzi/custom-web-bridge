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
        public OthersItem(int repeat, bool reset, string esc, Pattern pattern, Type type, Connector connector, ONTime onTime) : base(BaseItem.ItemType.other)
        {
            this.repeat = repeat;
            this.reset = reset;
            this.esc = esc;
            this.pattern = pattern;
            this.type = type;
            this.connector = connector;
            this.onTime = onTime;
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
