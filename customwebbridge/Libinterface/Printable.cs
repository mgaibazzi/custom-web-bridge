﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.CuCustomWndAPI;
using customwebbridge.Items;
namespace customwebbridge.Libinterface
{
    internal class Printable
    {
        public Printable() { }
        public void PrintItem(BaseItem Item, CuCustomWndDevice dev)
        {
            if (Item.Itemtype == BaseItem.ItemType.barcode)
            {
                PrintableBarcode pt = new PrintableBarcode((Barcode1D)Item);
                dev.PrintBarcode(pt.Barcode_data, pt.BarcodeSettings);
            }
            else if (Item.Itemtype == BaseItem.ItemType.qrcode)
            {
                PrintableBarcode pt = new PrintableBarcode((Barcode2D)Item);
                dev.PrintBarcode(pt.Barcode_data, pt.BarcodeSettings);
            }
            else if(Item.Itemtype == BaseItem.ItemType.text)
            {
                PrintableText pt = new PrintableText((TextItem)Item);
                dev.PrintText(pt.Testo.Text, pt.FontSettings1, pt.BAddLF);
            }
            else if(Item.Itemtype == BaseItem.ItemType.cut)
            {
                PrintableCut ct = new PrintableCut();
                dev.Cut(ct.CutType);
            }
            else if(Item.Itemtype == BaseItem.ItemType.feed)
            {
                PrintableFeed fe=new PrintableFeed((FeedItem)Item);
                dev.Feed((uint)fe.Feed.Line);
            }
            else 
            {
                PrintableDrawer dr = new PrintableDrawer((DrawerItem)Item);
                dev.OpenCashDrawer(dr.CashDrawerType,dr.TimeOn,dr.TimeOn);
            }
        }  
    }
}