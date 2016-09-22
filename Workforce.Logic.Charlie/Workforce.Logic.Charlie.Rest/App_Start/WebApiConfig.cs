using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Workforce.Logic.Charlie.Rest
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
                routeTemplate: "api/{controller}/{action}/{id1}/{id2}",
                defaults: new { controller = "Index", action = "Get", id1 = RouteParameter.Optional, id2 = RouteParameter.Optional}
            );
        }
    }
}
