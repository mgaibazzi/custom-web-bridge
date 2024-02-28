using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge
{
    public class BaseItem
    {

        public enum ItemType
        {
            text,
            image,
            feed,
            other,
            barcode,
            qrcode,
            none
        }
        //itemType
        ItemType itemtype;

        public BaseItem(ItemType itemtype)
        {
            this.itemtype = itemtype;
        }

        public ItemType Itemtype { get => itemtype; set => itemtype = value; }
    }
}
