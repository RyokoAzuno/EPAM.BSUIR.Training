using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.DAL.Services;
using Ninject.Modules;

namespace ImageGalleryApp.DAL.Dependencies
{
    public class NinjectServiceModule : NinjectModule
    {
        private string _connectionString;

        public NinjectServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IPhotoService>().To<PhotoService>().WithConstructorArgument(_connectionString);
        }
    }
}
