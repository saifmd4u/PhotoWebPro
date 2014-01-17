using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;


namespace PhotoWebPro
{
    public class PhotoHelper
    {
        public static void CreateThumbnail(string ImageFrom, string ImageTo, int ImageHeight)
        {
            System.Drawing.Image i = System.Drawing.Image.FromFile(ImageFrom);

            i.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            i.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            System.Drawing.Image th = i.GetThumbnailImage
                                (
                                ImageHeight * i.Width / i.Height,
                                ImageHeight,
                                new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback),
                                IntPtr.Zero
                                );
            i.Dispose();

            EncoderParameters ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)80);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            th.Save(ImageTo, ici, ep);
            th.Dispose();
            return;
        }

        public static void CreateThumbnail(string ImageFrom, string ImageTo, int ImageWidth, int ImageHeight)
        {
            System.Drawing.Image i = System.Drawing.Image.FromFile(ImageFrom);

            i.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            i.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            System.Drawing.Image th = i.GetThumbnailImage
                                (
                                ImageWidth,
                                ImageHeight,
                                new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback),
                                IntPtr.Zero
                                );
            i.Dispose();

            EncoderParameters ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)80);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            th.Save(ImageTo, ici, ep);
            th.Dispose();
            return;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public static bool ThumbnailCallback()
        {
            return true;
        }
    }
}