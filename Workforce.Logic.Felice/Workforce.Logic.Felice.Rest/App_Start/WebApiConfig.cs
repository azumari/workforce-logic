﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Workforce.Logic.Felice.Rest
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
               routeTemplate: "api/{controller}/{action}/{status}",
               defaults: new { controller = "index", action = RouteParameter.Optional, status = RouteParameter.Optional }
         );
      }
   }
}
