using Books.WebApp.Models;
using Books.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books.WebApp.Controllers
{
    public class BookController : ApiController
    {
        private BookService _service;

        public BookController()
        {
            _service = new BookService();
        }
        // GET api/book
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _service.GetAll().ToList();
        }

        // GET api/book/5
        [HttpGet]
        public Book GetBook(string id)
        {
            Book book = _service.GetById(id);
            if (book != null)
            {
                return book;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // POST api/book
        [HttpPost]
        public HttpResponseMessage AddBook([FromBody]Book value)
        {
            if (ModelState.IsValid)
            {
                _service.Create(value);
                return Request.CreateResponse(HttpStatusCode.Created, "Added Successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something goes wrong!");
            }
        }

        // PUT api/book/5
        [HttpPut]
        public HttpResponseMessage UpdateBook(/*string id, */[FromBody]Book value)
        {
            if (ModelState.IsValid)
            {
                _service.Update(value);
                return Request.CreateResponse(HttpStatusCode.Created, "Updated Successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something goes wrong!");
            }
        }

        // DELETE api/book/5
        [HttpDelete]
        public HttpResponseMessage DeleteBook(string id)
        {
            Book book = _service.GetById(id);
            if (book != null)
            {
                _service.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, book);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something goes wrong !");
            }
        }
    }
}
