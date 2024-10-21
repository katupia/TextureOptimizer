using System;
using System.Linq;
using System.Text;

namespace TextureOptimizer
{
    public enum DetectedFileType
    {
        Unknown,
        bmp,
        jpeg,
        gif,
        tiff,
        png
    }
    public static class TypeFileDetector
    {
        public static DetectedFileType GetImageFormat(string filePath)
        {//TODO use GetImageFormat(byte[] bytes)
            string lowerCase = filePath.ToLower();
            if (lowerCase.EndsWith("png"))
            {  
                return DetectedFileType.png;
            }
            return DetectedFileType.Unknown;
        }
        public static DetectedFileType GetImageFormat(byte[] bytes)
        {
            //see https://stackoverflow.com/questions/210650/validate-image-from-file-in-c-sharp/9446045
            // see http://www.mikekunz.com/image_file_header.html  
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return DetectedFileType.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return DetectedFileType.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return DetectedFileType.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return DetectedFileType.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return DetectedFileType.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return DetectedFileType.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return DetectedFileType.jpeg;

            return DetectedFileType.Unknown;
        }
    }
}
