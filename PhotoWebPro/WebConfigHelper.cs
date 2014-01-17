using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.IO;

namespace PhotoWebPro
{
    public class WebConfigHelper
    {
        public static int ThumbnailWidth = Convert.ToInt32(WebConfigurationManager.AppSettings["ThumbnailWidth"] ?? "100");
        public static int ThumbnailHeight = Convert.ToInt32(WebConfigurationManager.AppSettings["ThumbnailHeight"] ?? "78");

        public static string UploadPath
        {
            get
            {
                return GetUploadsDirectory();                
            }
        }

        private static string GetUploadsDirectory()
        {
            string websiteLocation = System.Web.HttpContext.Current.Server.MapPath("~");
            string uploadRoot = Directory.GetParent(websiteLocation).Parent.FullName;
            uploadRoot = Path.Combine(uploadRoot, "Uploads");
            return uploadRoot;
        }
    }
}