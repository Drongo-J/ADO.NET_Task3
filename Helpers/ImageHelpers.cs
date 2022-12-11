using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ADO.NET_Task3.Models;
using System.Net;
using System.IO;
using System.Drawing;
using System.Net.Http;
using System.Security.Policy;

namespace ADO.NET_Task3.Helpers
{
    public class ImageHelpers
    {
        public static ImageSource StringToImageSource(string source)
        {
            try
            {
                if (!source.Contains("https://"))
                    source = "https://" + source;

                var imgUrl = new Uri(source);
                var imageData = new WebClient().DownloadData(imgUrl);
                return ByteImageConverter.ByteToImage(imageData);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

    public class ByteImageConverter 
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
    }
}
