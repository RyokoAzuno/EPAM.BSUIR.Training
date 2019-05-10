using ImageGalleryApp.DAL.EFContexts;
using ImageGalleryApp.DAL.Repositories;
using ImageGalleryApp.DAL.Services;
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

            //routes.Add(new Route("handler/{*path}", new ImageRouteHandler(
            //                    new PhotoService(
            //                        new PhotoRepository(
            //                            new GalleryContext("MyDefaultConnection"))))));
            //routes.MapRoute(
            //    name: "ImageRoute",
            //    url: "images",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //).RouteHandler = new ImageRouteHandler(
            //                    new PhotoService(
            //                        new PhotoRepository(
            //                            new GalleryContext("MyDefaultConnection"))));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
