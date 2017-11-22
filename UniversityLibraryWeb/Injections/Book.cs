using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UniversityLibraryWeb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace UniversityLibraryWeb.Injections
{
    /// <summary>
    /// Provides access to operations that can be performed over book collection
    /// </summary>
    public class Book : IBook
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public BookModel GetBook(string id)
        {
            var collection = GetBooksCollection();
            BookModel book = null;

            if (collection != null)
            {
                book = (from e in collection.AsQueryable()
                        where e.Id.ToString().ToLower().Contains(id.ToLower())
                        select e) as BookModel;
            }
            return book;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable() select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooks(string title, string publisher, string author)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Title.ToLower().Contains(title.ToLower())
                        || e.Publisher.ToLower().Contains(publisher.ToLower())
                        || e.Authors.Contains(author.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooksByTitle(string title)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Title.ToLower().Contains(title.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooksByPublisher(string publisher)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Publisher.ToLower().Contains(publisher.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooksByAuthor(string author)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Authors.Contains(author.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooksByTitleAndPublisher(string title, string publisher)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Title.ToLower().Contains(title.ToLower())
                        || e.Publisher.ToLower().Contains(publisher.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooksByTitleAndAuthor(string title, string author)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Title.ToLower().Contains(title.ToLower())
                        || e.Authors.Contains(author.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public IEnumerable<BookModel> GetBooksByPublisherAndAuthor(string publisher, string author)
        {
            var collection = GetBooksCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable()
                        where e.Publisher.ToLower().Contains(publisher.ToLower())
                        || e.Authors.Contains(author.ToLower())
                        select e).ToList();
            }
            return null;
        }

        public bool PlaceBookDemand(string id)
        {
            var collection = _database.GetCollection<BsonDocument>(ConfigurationManager.AppSettings["DemandCollectionName"]);
            if (DbIsConnected())
            {
                var document = new BsonDocument
                {
                    { "bookid", id },
                    { "username", "Dummy" },
                    { "date", DateTime.UtcNow }
                };                
                collection.InsertOne(document);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provides access to the database so a collection can be queried
        /// </summary>
        /// <returns>Collection of Books from MongoDB database instance</returns>
        private IMongoCollection<BookModel> GetBooksCollection()
        {
            try
            {
                _client = new MongoClient();
                _database = _client.GetDatabase(ConfigurationManager.AppSettings["DatabaseName"]);
            }
            catch (TimeoutException)
            {
                // Possible steps to cover the error 
                // 1: Throw the exception and handle it in the upper layers to display a message
                // 2: Save information on the error to a log file, database, etc
                // 3: As for now we return a null collection so the error don't stop the execution of the application
                return null;
            }
            return _database.GetCollection<BookModel>(ConfigurationManager.AppSettings["BookCollectionName"]);
        }

        private bool DbIsConnected()
        {
            return _client.Cluster.Description.State == MongoDB.Driver.Core.Clusters.ClusterState.Connected;
        }
    }
}