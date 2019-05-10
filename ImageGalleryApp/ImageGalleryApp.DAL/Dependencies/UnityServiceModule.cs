using ImageGalleryApp.DAL.EFContexts;
using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.DAL.Repositories;
using Microsoft.Practices.Unity;

namespace ImageGalleryApp.DAL.Dependencies
{
    public class UnityServiceModule
    {
        private IUnityContainer _container;

        public UnityServiceModule(IUnityContainer container)
        {
            _container = container;
        }

        public void AddDependency(string connectionString)
        {
            _container.RegisterType<IRepository<Photo>, PhotoRepository>(new InjectionConstructor(new GalleryContext(connectionString)));
        }
    }
}
