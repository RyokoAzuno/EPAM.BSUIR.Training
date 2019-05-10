using ImageGalleryApp.DAL.Entities;
using System.Collections.Generic;
using System.Drawing;

namespace ImageGalleryApp.DAL.Interfaces
{
    public interface IPhotoService
    {
        void SaveToDatabase(Photo photo);

        IEnumerable<Photo> GetAll();

        Photo Get(int id);

        Size Resize(Size imageSize, Size newSize);

        void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave);

        byte[] ImageToBytes(Image img);
    }
}
