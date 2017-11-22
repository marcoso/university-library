using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityLibraryWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ViewResult Index()
        {
            ViewBag.Title = "University Library";
            return View("Login");
        }
    }
}