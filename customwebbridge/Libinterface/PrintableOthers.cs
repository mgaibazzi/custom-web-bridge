using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;

namespace customwebbridge.Libinterface
{
    internal class PrintableOthers
    {
        CuCustomWndDevice.CutType cutType;
        CuCustomWndDevice.CashDrawerType cashDrawerType;
        //default constructor
        public PrintableOthers(OthersItem othersItem)
        {
            SelectCutType();
            SelectDrawer(othersItem);
        }
        //Getter and setter
        public CuCustomWndDevice.CutType CutType { get => cutType; set => cutType = value; }
        public CuCustomWndDevice.CashDrawerType CashDrawerType { get => cashDrawerType; set => cashDrawerType = value; }

        private void SelectCutType()
        {
            cutType = CuCustomWndDevice.CutType.CUT_PARTIAL;
        }
        private void SelectDrawer(OthersItem othersItem)
        {
            if(othersItem.Connector1==OthersItem.Connector.drawer_1)
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
