using ImageGalleryApp.DAL.Dependencies;
using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.DAL.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ImageGalleryApp.Web.Resolvers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private string _connectionString;

        private readonly IUnityContainer _container;

        public UnityDependencyResolver(string connectionString)
        {
            _connectionString = connectionString;
            _container = new UnityContainer();
            UnityServiceModule module = new UnityServiceModule(_container);
            module.AddDependency(_connectionString);
            _container.RegisterType<IPhotoService, PhotoService>(new InjectionConstructor(typeof(IRepository<Photo>)));
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}
