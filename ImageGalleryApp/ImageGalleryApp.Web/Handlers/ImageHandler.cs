using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.Web.Resolvers;
using System;
using System.Web;
using System.Web.Routing;

namespace ImageGalleryApp.Web.Handlers
{
    public class ImageHandler : IHttpHandler
    {
        private RequestContext _requestContext;

        public ImageHandler(RequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        // Handler writes image bytes
        public void ProcessRequest(HttpContext context)
        {
            var routeValues = _requestContext.RouteData.Values;
            if (routeValues.ContainsKey("id"))
            {
                var resolver = new UnityDependencyResolver("MyDefaultConnection");
                var photoService = (IPhotoService)resolver.GetService(typeof(IPhotoService));
                Photo img = photoService.Get(Convert.ToInt32(routeValues["id"]));
                string filename = _requestContext.HttpContext.Server.MapPath(img.ImagePath);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
                if (fileInfo.Exists)
                {
                    _requestContext.HttpContext.Response.Clear();
                    _requestContext.HttpContext.Response.AddHeader("Content-Disposition", "inline;attachment; filename=\""
                                                                    + fileInfo.Name + "\"");
                    _requestContext.HttpContext.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    _requestContext.HttpContext.Response.ContentType = img.MimeType; //"application/octet-stream";
                    _requestContext.HttpContext.Response.TransmitFile(fileInfo.FullName);
                    _requestContext.HttpContext.Response.Flush();
                    // I use in to check !=null equation
                    //Int32 id;
                    // Check and get id value from url
                    //if (_requestContext.HttpContext.Request.QueryString["id"] != null)
                    //{
                    //    id = Convert.ToInt32(context.Request.QueryString["id"]);
                    //}
                    //else
                    //{
                    //    throw new ArgumentException("Not specified parameter");
                    //}
                    // Get image by id from database
                    //Photo img = _photoService.Get(id);
                    // Getting image type(png, jpg, jpeg, bmp, gif)
                    //_requestContext.HttpContext.Response.ContentType = img.MimeType;
                    //_requestContext.HttpContext.Response.WriteFile(img.ThumbPath);
                    //// Write image bytes to current stream
                    ////context.Response.OutputStream.Write(data, 0, data.Length);
                    //_requestContext.HttpContext.Response.Flush();
                }
            }
        }
    }
}