using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace UniversityLibraryWeb.Controllers
{
    public class SearchBooksController : Controller
    {       
        // GET: SearchBooks
        public ViewResult Index()
        {
            ViewBag.Title = "University Library";
            return View("SearchBooks");
        }        
    }
}