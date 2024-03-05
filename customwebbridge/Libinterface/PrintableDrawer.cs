using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;
using customwebbridge.Items;

namespace customwebbridge.Libinterface
{
    internal class PrintableDrawer
    {
        CuCustomWndDevice.CashDrawerType cashDrawerType;
        //default constructor
        public PrintableDrawer(DrawerItem othersItem)
        {
            SelectDrawer(othersItem);
        }
        //Getter and setter
        public CuCustomWndDevice.CashDrawerType CashDrawerType { get => cashDrawerType; set => cashDrawerType = value; }
        private void SelectDrawer(DrawerItem othersItem)
        {
            if(othersItem.Connector1==DrawerItem.Connector.drawer_1)
            {
                CashDrawerType = CuCustomWndDevice.CashDrawerType.CASH_DRAWER_1;
            }
            else
            {
                CashDrawerType = CuCustomWndDevice.CashDrawerType.CASH_DRAWER_2;
            }
        }
    }
}
