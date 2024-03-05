using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class CutItem : BaseItem
    {
        public enum Type//cut
        {
            feed,
            no_feed,
            reserve
        }
        Type type;
        public Type Type1 { get => type; set => type = value; }

        public CutItem():base(ItemType.cut)
        {
            Type1 = Type.feed;
        }
        public CutItem(Type type):base(ItemType.cut)
        {
            this.Type1 = type;
        }
    }
}
