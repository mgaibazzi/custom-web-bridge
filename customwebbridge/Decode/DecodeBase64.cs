using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customwebbridge.Decode
{
    internal class DecodeBase64
    {
        string str;
        bool invertColor = true;
        DrawBitMap drawbitmap = new DrawBitMap();
        public void Decode(ImageItem imageItem)
        {
            str = "";
            byte[] bytes = System.Convert.FromBase64String(imageItem.StrImage);
            if (imageItem.Mode1 == ImageItem.Mode.mono)
            {
                if (invertColor == true)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = (byte)(bytes[i] ^ Convert.ToByte(0xff));
                    }
                }
                drawbitmap.MonoChromeBitMap(bytes, imageItem);
            }
            else if (imageItem.Mode1 == ImageItem.Mode.gray16)
            {
                drawbitmap.GreyScale4Bit(bytes, imageItem);
            }
            else
                drawbitmap.GreyScale8Bit(bytes, imageItem);


        }
    }
}
    

