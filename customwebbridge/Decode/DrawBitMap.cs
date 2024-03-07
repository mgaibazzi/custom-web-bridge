using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Decode
{
    public class DrawBitMap
    {
        Bitmap bitmap;
        //Create and Save a bitmap in different modes 
        public void MonoChromeBitMap(byte[] bytes,ImageItem item,PixelFormat px = PixelFormat.Format1bppIndexed)
        {
            
            bitmap = CreateBitmap(item.Width, item.Height, bytes,px);
            bitmap.Save("outputMonoChrome.bmp", ImageFormat.Bmp);
            item.BitMap = bitmap;
        }
        public void GreyScale4Bit(Byte[] bytes, ImageItem item, PixelFormat px = PixelFormat.Format4bppIndexed)
        {
            bitmap = CreateBitmap(item.Width, item.Height, bytes, px);
            bitmap.Save("outputGreyScale4bit.bmp", ImageFormat.Bmp);
            item.BitMap = bitmap;
        }
        public void GreyScale8Bit(Byte[] bytes, ImageItem item, PixelFormat px = PixelFormat.Format8bppIndexed)
        {
            bitmap = CreateBitmap(item.Width, item.Height, bytes, px);
            bitmap.Save("outputGreyScale8bit.bmp", ImageFormat.Bmp);
            item.BitMap = bitmap;
        }
        // create a bitmap with the specified dimension
        public Bitmap CreateBitmap(int width, int height, byte[] data,PixelFormat px)
        {
           
            Bitmap bitmap = new Bitmap(width, height, px);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
    
}
