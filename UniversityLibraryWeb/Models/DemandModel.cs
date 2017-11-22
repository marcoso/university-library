using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityLibraryWeb.Models
{
    public class DemandModel
    {
        public ObjectId Id { get; set; }
        public string bookid { get; set; }
        public string username { get; set; }
        public DateTime date { get; set; }
    }
}