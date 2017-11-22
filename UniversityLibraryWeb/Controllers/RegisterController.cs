using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversityLibraryWeb.Injections;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Controllers
{
    /// <summary>
    /// Service that exposes queries through HTTP to allow Members registration
    /// </summary>    
    public class RegisterController : ApiController
    {
        //Interface to provide IoC and implementation of dependency injection
        private readonly IRegister registerHandler;

        public RegisterController(IRegister registerHandlerInjection)
        {
            registerHandler = registerHandlerInjection; //Injection of dependency
        }

        [HttpPost]
        public IHttpActionResult Post(string dataA, string dataB)
        {
            var memberRegistered = registerHandler.RegisterMember(dataA, dataB);        
            return Ok();
        }        

        [HttpGet]
        public IHttpActionResult GetLoginMember(string dataA, string dataB)
        {
            UserModel user = registerHandler.LoginMember(dataA, dataB);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
