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
      
        //Default constructor 
        public EscItem() : base(ItemType.command)
        {
            this.Esc = "";
        }
        //Parameterized constructor 
        public EscItem(string esc):base(ItemType.command) 
        {
            this.Esc = esc;
        }

        //Getter and Setter
        public string Esc
        {
            get => esc; set => esc = value;
        }

    }
}
