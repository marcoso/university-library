using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Injections
{
    /// <summary>
    /// Interface provided for dependency injection usage for operations that query Books
    /// </summary>
    public interface IBook
    {
        BookModel GetBook(string id);
        IEnumerable<BookModel> GetBooks();
        IEnumerable<BookModel> GetBooks(string title, string publisher, string author);
        IEnumerable<BookModel> GetBooksByTitle(string title);
        IEnumerable<BookModel> GetBooksByPublisher(string publisher);
        IEnumerable<BookModel> GetBooksByAuthor(string author);
        IEnumerable<BookModel> GetBooksByTitleAndPublisher(string title, string publisher);
        IEnumerable<BookModel> GetBooksByTitleAndAuthor(string title, string author);
        IEnumerable<BookModel> GetBooksByPublisherAndAuthor(string publisher, string author);
        bool PlaceBookDemand(string id);
    }
}
