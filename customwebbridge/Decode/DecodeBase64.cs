using System;
using System.Collections.Generic;
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
        DrawBitMap drawbitmap=new DrawBitMap();
        public void Decode(ImageItem imageItem) 
        {
            str = "";
            byte[] bytes = System.Convert.FromBase64String(imageItem.StrImage);
            
            
            MessageBox.Show(str);
            if (imageItem.Mode1 == ImageItem.Mode.mono)
            {
                if (invertColor == true)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = (byte)(bytes[i] ^ Convert.ToByte(0xff));
                    }
                }
                imageItem.Path=drawbitmap.MonoChromeBitMap(bytes, imageItem.Width, imageItem.Height);
            }
            else if (imageItem.Mode1 == ImageItem.Mode.gray16)
            {
                imageItem.Path= drawbitmap.GreyScale4Bit(bytes, imageItem.Width, imageItem.Height);
            }
            else
                imageItem.Path = drawbitmap.GreyScale8Bit(bytes, imageItem.Width, imageItem.Height);


        }
    }
}
