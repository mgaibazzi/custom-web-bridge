using customwebbridge.Items;
using System;

namespace customwebbridge.Libinterface
{
    internal class PrintableEsc
    {
        private byte[] data;

        public PrintableEsc(EscItem esc)
        {
            this.Data = ConvertToByte(esc.Esc);
        }

        public byte[] Data { get => data; set => data = value; }

        private byte[] ConvertToByte(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException("Hex string length must be even.");
            }

            byte[] byteArray = new byte[hexString.Length / 2];

            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteArray;
        }
    }
}