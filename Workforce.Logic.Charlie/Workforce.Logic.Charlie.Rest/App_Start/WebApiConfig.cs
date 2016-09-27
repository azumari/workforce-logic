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
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{dept}/{dest}",
                defaults: new { controller = "index", action = RouteParameter.Optional,
                    dept = RouteParameter.Optional, dest = RouteParameter.Optional }
            );
        }
    }
}
