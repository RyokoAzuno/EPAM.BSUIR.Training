using Books.WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //byte[] bytes = BooksStorage.Serialize();
            //List<Book> books = BooksStorage.Deserialize(bytes);
            BooksStorage.RestoreInitialState();
            return View();
        }
    }
}
