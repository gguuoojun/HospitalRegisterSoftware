using System;
using System.Drawing;

namespace Hangzhou12580
{
    class Common
    {
        public static Image ConvertbyteArrayToImage(byte[] Bytes)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(Bytes);
            Image result = Image.FromStream(memoryStream);
            memoryStream.Close();
            return result;
        }

        public static string GetLocalTime()
        {
            System.Globalization.CultureInfo provider = new System.Globalization.CultureInfo("en-US");
            return DateTime.Now.ToString("ddd MMM dd yyyy HH:mm:ss", provider) + " GMT 0800 (中国标准时间)";
        }
    }
}
