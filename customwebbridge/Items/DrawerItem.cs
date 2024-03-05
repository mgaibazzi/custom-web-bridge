using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class DrawerItem : BaseItem
    {
        public enum ONTime//drawer
        {
            pulse_100,
            pulse_200,
            pulse_300,
            pulse_400,
            pulse_500
        }
        public enum Connector//drawer
        {
            drawer_1,
            drawer_2
        }
        ONTime onTime;
        Connector connector;

        public ONTime OnTime { get => onTime; set => onTime = value; }
        public Connector Connector1 { get => connector; set => connector = value; }

        public DrawerItem():base(ItemType.pulse)
        {
            OnTime = ONTime.pulse_100;
            Connector1 = Connector.drawer_1;
        }
        public DrawerItem(ONTime onTime, Connector connector) : base(ItemType.pulse)
        {
            this.OnTime = onTime;
            this.Connector1 = connector;
        }
    }
}

