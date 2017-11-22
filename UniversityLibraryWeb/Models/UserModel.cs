using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityLibraryWeb.Models
{
    public class UserModel
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}