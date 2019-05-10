using ImageGalleryApp.DAL.EFContexts;
using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageGalleryApp.DAL.Repositories
{
    // Class simulates photo repository
    public class PhotoRepository : IRepository<Photo>
    {
        private GalleryContext _galleryDB;

        public PhotoRepository(GalleryContext galleryContext)
        {
            _galleryDB = galleryContext;
        }

        /// <summary>
        /// Get all photos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Photo> GetAll() => _galleryDB.Photos;

        /// <summary>
        /// Get photo by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Photo GetById(int id)
        {
            Photo photo = _galleryDB.Photos.Where(p => p.Id.Equals(id)).FirstOrDefault();

            if (photo != null)
            {
                return photo;
            }

            throw new NullReferenceException("There is no photo with given Id!");
        }

        /// <summary>
        /// Create new photo
        /// </summary>
        public void Create(Photo photo)
        {
            if (photo != null)
            {
                _galleryDB.Photos.Add(photo);
                _galleryDB.SaveChanges();
            }
        }

        /// <summary>
        /// Delete photo by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Photo photo = _galleryDB.Photos.Where(p => p.Id.Equals(id)).FirstOrDefault();

            if (photo != null)
            {
                _galleryDB.Photos.Remove(photo);
                _galleryDB.SaveChanges();
            }
        }
    }
}
