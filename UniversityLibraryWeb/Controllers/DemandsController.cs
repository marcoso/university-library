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
    /// Service that exposes queries through HTTP over Book Demands
    /// </summary>   
    public class DemandsController : ApiController
    {
        //Interface to provide IoC and implementation of dependency injection
        private readonly IHistorical demandsHandler;

        public DemandsController(IHistorical demandsHandlerInjection)
        {
            demandsHandler = demandsHandlerInjection; //Injection of dependency
        }

        [HttpGet]
        public IEnumerable<DemandModel> GetAllDemands()
        {
            return demandsHandler.GetDemands();
        }

        [HttpPost]
        public IHttpActionResult Post(string id)
        {
            var demandCanceled = demandsHandler.CancelDemand(id);            
            return Ok();
        }
    }
}
