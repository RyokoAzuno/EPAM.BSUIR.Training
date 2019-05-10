using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ImageGalleryApp.Web.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Thumb Path")]
        public string ThumbPath { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public Image Image { get; set; }
    }
}