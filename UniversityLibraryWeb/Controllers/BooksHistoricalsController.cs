using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityLibraryWeb.Controllers
{
    public class BooksHistoricalsController : Controller
    {
        // GET: BooksHistoricals
        public ViewResult Index()
        {
            ViewBag.Title = "University Library";
            return View("Historical");
        }
    }
}