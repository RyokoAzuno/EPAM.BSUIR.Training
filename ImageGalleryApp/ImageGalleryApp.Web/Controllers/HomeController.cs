using ImageGalleryApp.DAL.Entities;
using ImageGalleryApp.DAL.Interfaces;
using ImageGalleryApp.DAL.Mappers;
using ImageGalleryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageGalleryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPhotoService _photoService;

        public HomeController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public ActionResult Index(string filter = null, int page = 1, int pageSize = 33)
        {
            var records = new PagedList<ImageViewModel>();
            ViewBag.filter = filter;

            records.Content = CustomMapper<Photo, ImageViewModel>.Map(_photoService.GetAll())
                        .Where(x => filter == null || (x.Description.Contains(filter)))
                        .OrderByDescending(x => x.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = _photoService.GetAll()
                            .Where(x => filter == null || (x.Description.Contains(filter))).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var image = new ImageViewModel();

            return View(image);
        }

        [HttpPost]
        public ActionResult Create(ImageViewModel image, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                return View(image);
            }

            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";

                return View(image);
            }

            var model = new Photo();

            foreach (var file in files)
            {
                if (file.ContentLength == 0)
                {
                    continue;
                }

                model.Description = image.Description;
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

                using (var img = Image.FromStream(file.InputStream))
                {
                    model.ThumbPath = string.Format("/Content/GalleryImages/thumbs/{0}{1}", fileName, extension);
                    model.ImagePath = string.Format("/Content/GalleryImages/{0}{1}", fileName, extension);
                    model.MimeType = file.ContentType;
                    model.Data = _photoService.ImageToBytes(img);
                    // Save thumbnail size image, 100 x 100
                    _photoService.SaveToFolder(img, fileName, extension, new Size(100, 100), Server.MapPath(model.ThumbPath));
                    // Save record to database
                    model.CreatedOn = DateTime.Now;
                    _photoService.SaveToDatabase(model);
                    // Save large size image, 800 x 800
                    _photoService.SaveToFolder(img, fileName, extension, new Size(600, 600), Server.MapPath(model.ImagePath));
                }
            }

            return RedirectPermanent("/home");
        }
    }
}