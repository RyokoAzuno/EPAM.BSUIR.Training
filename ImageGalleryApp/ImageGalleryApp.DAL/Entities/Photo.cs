using ImageGalleryApp.DAL.Interfaces;
using System;

namespace ImageGalleryApp.DAL.Entities
{
    public class Photo : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string ThumbPath { get; set; }

        public DateTime CreatedOn { get; set; }

        public string MimeType { get; set; }

        public byte[] Data { get; set; }
    }
}
