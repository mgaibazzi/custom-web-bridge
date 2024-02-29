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

        public BaseItem(ItemType itemtype)//constructor
        {
            this.itemtype = itemtype;
        }
        //getter & setter
        public ItemType Itemtype { get => itemtype; set => itemtype = value; }
    }
}
