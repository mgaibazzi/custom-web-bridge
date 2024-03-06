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
        public void MonoChromeBitMap(byte[] bytes, int width, int height, PixelFormat px = PixelFormat.Format1bppIndexed)
        {
            Bitmap bitmap = CreateBitmap(width, height, bytes,px);
            bitmap.Save("outputMonoChrome.bmp", ImageFormat.Bmp);
        }
        public void GreyScale4Bit(Byte[] bytes, int width, int height, PixelFormat px = PixelFormat.Format4bppIndexed)
        {
            Bitmap bitmap = CreateBitmap(width, height, bytes, px);
            bitmap.Save("outputGreyScale4bit.bmp", ImageFormat.Bmp);
        }
        public void GreyScale8Bit(Byte[] bytes, int width, int height, PixelFormat px = PixelFormat.Format8bppIndexed)
        {
            Bitmap bitmap = CreateBitmap(width, height, bytes, px);
            bitmap.Save("outputGreyScale8bit.bmp", ImageFormat.Bmp);
        }
        public  Bitmap CreateBitmap(int width, int height, byte[] data,PixelFormat px)
        {
            // Crea una Bitmap con le dimensioni specificate
            Bitmap bitmap = new Bitmap(width, height, px);
            //Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format4bppIndexed);
            // Copia i dati nell'immagine
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
    
}
