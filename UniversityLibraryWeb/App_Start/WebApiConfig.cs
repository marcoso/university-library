using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UniversityLibraryWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",                
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ControllerApiTwoParameters",
                routeTemplate: "api/{controller}/{dataA}/{dataB}"                
            );

            config.Routes.MapHttpRoute(
                name: "ActionApiDefault",
                routeTemplate: "api/{controller}/{action}/{title}/{publisher}/{author}"
            );

            config.Routes.MapHttpRoute(
                name: "ActionApiByParameterTitle",
                routeTemplate: "api/{controller}/{action}/{filter}"
            );            

            config.Routes.MapHttpRoute(
                name: "ActionApiByParameterTitleAndPublisher",
                routeTemplate: "api/{controller}/{action}/{filterA}/{filterB}"
            );            
        }
    }
}
