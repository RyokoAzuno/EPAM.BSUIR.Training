using ImageGalleryApp.DAL.EFContexts;
using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.DAL.Repositories;
using System.Collections.Generic;
using System.Drawing;

namespace ImageGalleryApp.DAL.Services
{
    public class PhotoService : IPhotoService
    {
        private IRepository<Photo> _photoRepository;

        public PhotoService(IRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
            //if (_photoRepository == null)
            //{
            //    _photoRepository = new PhotoRepository(new GalleryContext(connectionString));
            //}
        }

        public void SaveToDatabase(Photo photo)
        {
            _photoRepository.Create(photo);
        }

        public Photo Get(int id)
        {
            return _photoRepository.GetById(id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _photoRepository.GetAll();
        }

        public Size Resize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;

            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                {
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                }
                else
                {
                    tempval = newSize.Width / (imageSize.Width * 1.0);
                }

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
            {
                finalSize = imageSize; // image is already small size
            }

            return finalSize;
        }

        public void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave)
        {
            // Get new resolution
            Size imgSize = Resize(img.Size, newSize);

            using (Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                newImg.Save(pathToSave, img.RawFormat);
            }
        }

        public byte[] ImageToBytes(Image img)
        {
            ImageConverter converter = new ImageConverter();

            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
