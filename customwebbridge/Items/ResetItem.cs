using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class ResetItem : BaseItem
    {
        bool reset;
        public bool Reset { get => reset; set => reset = value; }

        public ResetItem():base(ItemType.reset) 
        {
            this.Reset = false;
        }
        public ResetItem(bool reset):base(ItemType.reset) 
        { 
            this.Reset = reset;
        }
    }
}
