using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Injections
{
    public class Register : IRegister
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public bool RegisterMember(string user, string password)
        {
            var collection = GetUserCollection();
            if (DbIsConnected())
            {
                var document = new BsonDocument
                {                    
                    { "Username", user },
                    { "Password", password }
                };                
                collection.InsertOne(document);
                return true;
            }
            return false;            
        }

        public UserModel LoginMember(string user, string password)
        {
            var collection = GetUserForLoginCollection();
            UserModel userModel = null;
            if (DbIsConnected())
            {
                userModel = (from e in collection.AsQueryable()
                        where e.Username.ToLower() == user.ToLower()
                        && e.Password.ToLower() == password.ToLower()                        
                        select e).FirstOrDefault();
            }
            return userModel;
        }

        /// <summary>
        /// Provides access to the database so a collection can be queried
        /// </summary>
        /// <returns>Collection of Users from MongoDB database instance</returns>
        private IMongoCollection<BsonDocument> GetUserCollection()
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
            return _database.GetCollection<BsonDocument>(ConfigurationManager.AppSettings["UserCollectionName"]);
        }

        /// <summary>
        /// Provides access to the database so a collection can be queried
        /// </summary>
        /// <returns>Collection of Users from MongoDB database instance</returns>
        private IMongoCollection<UserModel> GetUserForLoginCollection()
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
            return _database.GetCollection<UserModel>(ConfigurationManager.AppSettings["UserCollectionName"]);
        }

        private bool DbIsConnected()
        {
            return _client.Cluster.Description.State == MongoDB.Driver.Core.Clusters.ClusterState.Connected;
        }        
    }
}