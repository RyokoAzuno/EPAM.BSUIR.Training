using ImageGalleryApp.DAL.Interfaces;
using System.Web;
using System.Web.Mvc;

namespace ImageGalleryApp.Web.Handlers
{
    public class ImageRouteHandler : MvcRouteHandler
    {
        private IPhotoService _photoService;

        public ImageRouteHandler(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            return new ImageHandler(_photoService, requestContext);
        }
    }
}