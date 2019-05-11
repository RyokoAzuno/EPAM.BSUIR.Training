using System.Web;
using System.Web.Mvc;

namespace ImageGalleryApp.Web.Handlers
{
    public class ImageRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            return new ImageHandler(requestContext);
        }
    }
}