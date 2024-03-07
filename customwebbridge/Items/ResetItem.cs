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
        //default constructor
        public ResetItem():base(ItemType.reset) 
        {
            this.Reset = false;
        }
        //parameterized constructor
        public ResetItem(bool reset):base(ItemType.reset) 
        { 
            this.Reset = reset;
        }
        //getter and setter
        public bool Reset { get => reset; set => reset = value; }
    }
}
