using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversityLibraryWeb.Injections;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Controllers
{
    /// <summary>
    /// Service that exposes queries through HTTP over Books
    /// </summary>    
    public class BooksController : ApiController
    {
        //Interface to provide IoC and implementation of dependency injection
        private readonly IBook bookHandler;

        public BooksController(IBook bookHandlerInjection) {            
            bookHandler = bookHandlerInjection; //Injection of dependency
        }

        [HttpGet]
        public IHttpActionResult GetBook(string id)
        {
            BookModel book = bookHandler.GetBook(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<BookModel> GetAllBooks()
        {            
            return bookHandler.GetBooks();
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksFiltered(string title, string publisher, string author)
        {
            return bookHandler.GetBooks(title, publisher, author);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksByTitle(string filter)
        {
            return bookHandler.GetBooksByTitle(filter);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksByPublisher(string filter)
        {
            return bookHandler.GetBooksByPublisher(filter);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksByAuthor(string filter)
        {
            return bookHandler.GetBooksByAuthor(filter);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksByTitleAndPublisher(string filterA, string filterB)
        {
            return bookHandler.GetBooksByTitleAndPublisher(filterA, filterB);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksByTitleAndAuthor(string filterA, string filterB)
        {
            return bookHandler.GetBooksByTitleAndAuthor(filterA, filterB);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooksByPublisherAndAuthor(string filterA, string filterB)
        {
            return bookHandler.GetBooksByPublisherAndAuthor(filterA, filterB);
        }
                
        [HttpPost]
        public IHttpActionResult Post(string id)
        {
            var demandPlaced = bookHandler.PlaceBookDemand(id);        
            return Ok();
        }        
    }
}
