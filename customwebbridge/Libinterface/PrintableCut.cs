using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;
using customwebbridge.Items;

namespace customwebbridge.Libinterface
{
    internal class PrintableCut
    {
        CuCustomWndDevice.CutType cutType;//windows api cut type object
        //default constructor
        public PrintableCut()
        {
            SelectCutType();
        }
        //Getter and setter
        public CuCustomWndDevice.CutType CutType { get => cutType; set => cutType = value; }
        //select the  Cut type to partial
        private void SelectCutType()
        {
            cutType = CuCustomWndDevice.CutType.CUT_PARTIAL;
        }
    }
}

