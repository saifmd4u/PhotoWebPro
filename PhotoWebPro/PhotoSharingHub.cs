using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using SignalR.Hosting.AspNet;
using SignalR.Infrastructure;


namespace PhotoWebPro
{
    public class PhotoTracker
    {
        public static int OldCount = 0;
        //public static string LastUpdatePhotoThumbnail = string.Empty;
        public static string LastUploadedPhoto = string.Empty;
        public static int Count = 0;
    }

    [HubName("photoTracker")]
    public class PhotoSharingHub : Hub
    {
        public string hasAnyOneSharedNewPhotos()
        {
            string retValue = string.Empty;
            if ((PhotoTracker.Count == 0 && PhotoTracker.OldCount == 0)
                || (PhotoTracker.Count == PhotoTracker.OldCount))
            {
                retValue = "No";
            }
            else if (PhotoTracker.Count > PhotoTracker.OldCount)
            {
                PhotoTracker.OldCount = PhotoTracker.Count;
                retValue = PhotoTracker.LastUploadedPhoto;
            }

            return retValue;
        }

        public void uploadedPhoto(string PhotoName)
        {
            try
            {
                //var clients = GetClients();
                Clients.updateSlideView(PhotoName);
                //Clients.displayAlert();
            }
            catch (Exception ex)
            {
                string c = ex.Message;
            }
        }
    }
}