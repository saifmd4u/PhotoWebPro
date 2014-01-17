using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using PhotoWebPro;

namespace System.Web.Mvc.Html
{
    public static class HTMLHelperExtensions
    {
        public static string PopulatePhotos(this HtmlHelper helper, string ID)
        {
            string html = string.Empty;
            string[] photos = Directory.GetFiles(WebConfigHelper.UploadPath);

            if (photos.Length > 0)
            {
                html = string.Format("<div id='{0}' class='svwp'>\n", ID);
                html += "\t<ul>\n";
                foreach (string photo in photos)
                {
                    string photoName = Path.GetFileName(photo);
                    html += "<li><img src='/PhotoShare/DisplayPhoto?Filename=" + photoName + "' id='id_" + photoName + "' alt='" + photoName + "' /></li>\n";
                    //html += string.Format(@"\t<li><img alt='{0}' src='{1}' /></li>\n", file, file);
                }
                html += "</ul>\n";
                html += "</div>\n";
            }
            return html;
        }

        private static string GetImagePath(string fileName)
        {
            string imgPath = string.Empty;
            imgPath = "/PhotoShare/DisplayPhoto?Filename=" + fileName;
            return imgPath;
        }

        public static string PopulateGallery(this HtmlHelper helper, string ID)
        {
            string html = string.Empty;
            string[] photos = Directory.GetFiles(WebConfigHelper.UploadPath,"*.tbn");
            if (photos.Length > 0)
            {
                html = string.Format("<div id='{0}' class='svwp'>\n", ID);
                foreach (string photo in photos)
                {
                    string photoName = Path.GetFileName(photo);
                    string photoTag = string.Format("<a href='{0}'><img src='{1}' title='{2}' alt='{3}' /></a>\n",
                        GetImagePath(photoName),
                        GetImagePath(Path.ChangeExtension(photoName, ".pho")),
                        photoName,
                        photoName);
                    html += photoTag;
                }
                html += "</div>\n";
            }
            return html;
        }
    }
}