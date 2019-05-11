using ImageGalleryApp.Web.Handlers;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImageGalleryApp.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "ImageRoute",
            //    url: "images",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //).RouteHandler = new ImageRouteHandler();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.Add(new Route("images/{id}", new ImageRouteHandler()));
            routes.Add(new Route("images", new ImagesRouteHandler()));
        }
    }
}
