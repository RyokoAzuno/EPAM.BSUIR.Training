using ImageGalleryApp.DAL.Dependencies;
using ImageGalleryApp.DAL.EFContexts;
using ImageGalleryApp.DAL.Repositories;
using ImageGalleryApp.DAL.Services;
using ImageGalleryApp.Web.Handlers;
using ImageGalleryApp.Web.Resolvers;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImageGalleryApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver("MyDefaultConnection"));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            RouteTable.Routes.Add("ImagesRoute", new Route("images/{id}", new ImageRouteHandler(
                                new PhotoService(
                                    new PhotoRepository(
                                        new GalleryContext("MyDefaultConnection"))))));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //// Ninject service modules registration
            //NinjectModule serviceModule = new NinjectServiceModule("MyDefaultConnection");
            //var kernel = new StandardKernel(serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
