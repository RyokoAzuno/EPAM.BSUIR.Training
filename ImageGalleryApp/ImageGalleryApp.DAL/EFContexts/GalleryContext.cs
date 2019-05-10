using ImageGalleryApp.DAL.Entities;
using System.Data.Entity;

namespace ImageGalleryApp.DAL.EFContexts
{
    public class GalleryContext : DbContext
    {
        public GalleryContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GalleryContext>());
        }

        public DbSet<Photo> Photos { get; set; }
    }
}
