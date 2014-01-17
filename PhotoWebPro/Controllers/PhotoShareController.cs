using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq.Expressions;

namespace PhotoWebPro.Controllers
{
    public class PhotoShareController : Controller
    {
        public ActionResult PhotoShare()
        {
            return View();
        }

       

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Upload(HttpPostedFileBase uploadFile)
        {
            JsonResult returnResult = null;
            if (uploadFile.ContentLength > 0)
            {
                
                string uniqueFileName = DateTime.Now.ToFileTimeUtc().ToString();
                //string filePath = Path.Combine(uploadRoot, Path.GetFileName(uploadFile.FileName));
                string uploadRoot = WebConfigHelper.UploadPath;

                string filePath = Path.Combine(uploadRoot, uniqueFileName + ".pho");
                string thumbNailfilePath = Path.Combine(uploadRoot, uniqueFileName + ".tbn");

                uploadFile.SaveAs(filePath);

                PhotoHelper.CreateThumbnail(filePath, thumbNailfilePath, 75);
                PhotoHelper.CreateThumbnail(filePath, thumbNailfilePath, WebConfigHelper.ThumbnailWidth, WebConfigHelper.ThumbnailHeight);

                //PhotoTracker.LastUpdatePhotoThumbnail = Path.GetFileName(thumbNailfilePath);
                PhotoTracker.LastUploadedPhoto = Path.GetFileNameWithoutExtension(filePath);
                returnResult = new JsonResult
                {
                    Data = PhotoTracker.LastUploadedPhoto,
                    ContentType = "text/html",
                    ContentEncoding = null
                };

                PhotoTracker.Count++;
            }
            return returnResult;
        }

        public ActionResult DisplayPhoto(string Filename)
        {
            //Bitmap bmp = ;
            //Graphics g = Graphics.FromImage(bmp);
            //g.FillRectangle(Brushes.White, 0, 0, 200, 50);
            //g.DrawString(DateTime.Now.ToShortTimeString(), new Font("Arial", 32), Brushes.Red, new PointF(0, 0));
            //string uploadRoot = GetUploadsDirectory();
            string uploadRoot = WebConfigHelper.UploadPath;

            return new ImageResult { Image = Bitmap.FromFile(Path.Combine(uploadRoot, Filename)), ImageFormat = ImageFormat.Jpeg };
        }

    }



    public class ImageResult : ActionResult
    {        
        public ImageResult() { }
        public System.Drawing.Image Image { get; set; }
        public ImageFormat ImageFormat { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            // verify properties 
            if (Image == null)
            {
                throw new ArgumentNullException("Image");
            }
            if (ImageFormat == null)
            {
                throw new ArgumentNullException("ImageFormat");
            }
            // output 
            context.HttpContext.Response.Clear();
            if (ImageFormat.Equals(ImageFormat.Bmp)) context.HttpContext.Response.ContentType = "image/bmp";
            if (ImageFormat.Equals(ImageFormat.Gif)) context.HttpContext.Response.ContentType = "image/gif";
            if (ImageFormat.Equals(ImageFormat.Icon)) context.HttpContext.Response.ContentType = "image/vnd.microsoft.icon";
            if (ImageFormat.Equals(ImageFormat.Jpeg)) context.HttpContext.Response.ContentType = "image/jpeg";
            if (ImageFormat.Equals(ImageFormat.Png)) context.HttpContext.Response.ContentType = "image/png";
            if (ImageFormat.Equals(ImageFormat.Tiff)) context.HttpContext.Response.ContentType = "image/tiff";
            if (ImageFormat.Equals(ImageFormat.Wmf)) context.HttpContext.Response.ContentType = "image/wmf";
            Image.Save(context.HttpContext.Response.OutputStream, ImageFormat);
        }
    }
}
