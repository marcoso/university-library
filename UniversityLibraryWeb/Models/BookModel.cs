using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace UniversityLibraryWeb.Models
{
    public class BookModel
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }
    }

}