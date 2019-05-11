using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.Web.Resolvers;
using System.Collections.Generic;
using System.Web;

namespace ImageGalleryApp.Web.Handlers
{
    public class ImagesHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var resolver = new UnityDependencyResolver("MyDefaultConnection");
            var photoService = (IPhotoService)resolver.GetService(typeof(IPhotoService));
            IEnumerable<Photo> imgs = photoService.GetAll();
            string result = "<div>";

            foreach (var item in imgs)
            {
                result += $"<img src={item.ImagePath} />";
            }

            result += "</div>";
            context.Response.ContentType = "text/html";
            context.Response.Write(result);
        }
    }
}