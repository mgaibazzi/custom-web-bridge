using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class DrawerItem : BaseItem
    {
        //ON time Enum
        public enum ONTime//drawer
        {
            pulse_100,
            pulse_200,
            pulse_300,
            pulse_400,
            pulse_500
        }
        //Connector Enum
        public enum Connector//drawer
        {
            drawer_1,
            drawer_2
        }
        ONTime onTime;
        Connector connector;


        //default constructor 
        public DrawerItem():base(ItemType.pulse)
        {
            OnTime = ONTime.pulse_100;
            Connector1 = Connector.drawer_1;
        }
        //parameterized constructor 
        public DrawerItem(ONTime onTime, Connector connector) : base(ItemType.pulse)
        {
            this.OnTime = onTime;
            this.Connector1 = connector;
        }


        //getter and setter
        public ONTime OnTime { get => onTime; set => onTime = value; }
        public Connector Connector1 { get => connector; set => connector = value; }
    }
}

