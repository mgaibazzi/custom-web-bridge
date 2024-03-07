using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class CutItem : BaseItem
    {
        //Cut type enum
        public enum Type//cut
        {
            feed,
            no_feed,
            reserve
        }
        Type type;
     
        //default constructor 
        public CutItem():base(ItemType.cut)
        {
            Type1 = Type.feed;
        }
        //parameterized constructor 
        public CutItem(Type type):base(ItemType.cut)
        {
            this.Type1 = type;
        }

        //Getter and setter
        public Type Type1 { get => type; set => type = value; }
    }
}
