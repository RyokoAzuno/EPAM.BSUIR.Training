using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.Web.Resolvers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace ImageGalleryApp.Web.Modules
{
    public class ImagesCountModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += OnEndRequest;
        }

        private void OnEndRequest(object src, EventArgs args)
        {
            var resolver = new UnityDependencyResolver("MyDefaultConnection");
            var photoService = (IPhotoService)resolver.GetService(typeof(IPhotoService));
            IEnumerable<Photo> imgs = photoService.GetAll();
            int pngCount = 0;
            int jpegCount = 0;

            foreach (var item in imgs)
            {
                if (item.MimeType.Equals("image/png"))
                {
                    pngCount++;
                }
                else if(item.MimeType.Equals("image/jpeg"))
                {
                    jpegCount++;
                }
            }
            
            string result = $" Total images: {pngCount + jpegCount}; PNG images: {pngCount}; JPEG images: {jpegCount};";
            string path = (src as HttpApplication).Server.MapPath("/App_Data/info.txt");

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(DateTime.Now.ToString() + result);
            }
                
        }

    }
}