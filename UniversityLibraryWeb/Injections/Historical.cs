using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Injections
{
    /// <summary>
    /// Provides access to operations that can be performed over book demand historical collection
    /// </summary>
    public class Historical : IHistorical
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;        

        public DemandModel GetDemand(string id)
        {
            var collection = GetDemandsCollection();
            DemandModel demand = null;

            if (collection != null)
            {
                demand = (from e in collection.AsQueryable()
                        where e.bookid.ToString().ToLower().Contains(id.ToLower())
                        select e) as DemandModel;
            }
            return demand;
        }

        public IEnumerable<DemandModel> GetDemands()
        {
            var collection = GetDemandsCollection();
            if (DbIsConnected())
            {
                return (from e in collection.AsQueryable() select e).ToList();
            }
            return null;
        }

        public bool CancelDemand(string id)
        {
            var collection = GetDemandsCollection();
            if (DbIsConnected())
            {                
                var filter = Builders<DemandModel>.Filter.Eq("bookid", id);
                var result = collection.DeleteMany(filter);
                return result.IsAcknowledged;
            }
            return false;
        }

        /// <summary>
        /// Provides access to the database so a collection can be queried
        /// </summary>
        /// <returns>Collection of Book Demands from MongoDB database instance</returns>
        private IMongoCollection<DemandModel> GetDemandsCollection()
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
            return _database.GetCollection<DemandModel>(ConfigurationManager.AppSettings["DemandCollectionName"]);
        }

        private bool DbIsConnected()
        {
            return _client.Cluster.Description.State == MongoDB.Driver.Core.Clusters.ClusterState.Connected;
        }
    }
}
