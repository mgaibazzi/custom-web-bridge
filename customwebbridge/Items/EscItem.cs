using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Items
{
    public class EscItem : BaseItem
    {
        string esc;
        public string Esc
        {
            get => esc; set => esc = value;
        }

        public EscItem() : base(ItemType.command)
        {
            this.Esc = "1b2a2101005555550a";
        }

        public EscItem(string esc):base(ItemType.command) 
        {
            this.Esc = esc;
        }

    }
}
