using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;
using customwebbridge.Items;
using customwebbridge.Xml_parsing;

namespace customwebbridge.Libinterface
{
    internal class PrintableDrawer
    {
        CuCustomWndDevice.CashDrawerType cashDrawerType;//contains which drawer to open
        uint timeOn;
        //default constructor
        public PrintableDrawer(DrawerItem othersItem)
        {
            SelectDrawer(othersItem);
            Ontime(othersItem);
        }
        //Getter and setter
        public CuCustomWndDevice.CashDrawerType CashDrawerType { get => cashDrawerType; set => cashDrawerType = value; }
        public uint TimeOn { get => timeOn; set => timeOn = value; }
        //select wich drawer to open
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
        //convert the on time of the Drawer library in the on time of the windows api
        private void Ontime(DrawerItem othersItem)
        {
            if(DrawerItem.ONTime.pulse_100==othersItem.OnTime)
            {
                TimeOn = 100;
            }
            else if(DrawerItem.ONTime.pulse_200 == othersItem.OnTime)
            {
                TimeOn = 200;
            }
            else if(DrawerItem.ONTime.pulse_300 == othersItem.OnTime)
            {
                TimeOn = 300;
            }
            else if(DrawerItem.ONTime.pulse_400 == othersItem.OnTime)
            {
                TimeOn = 400;
            }
            else
            {
                TimeOn = 500;
            }
        }
    }
}
