﻿using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Workforce.Logic.Felice.Rest.Infrastructure;

namespace Workforce.Logic.Felice.Rest
{

  /// <summary>
  /// Will create a fresh instance from the ApplicationDbContext
  /// and ApplicationUserManager for each request and set it in
  /// the Owin context using the extension method CreatePerOwinContext
  /// </summary>
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      HttpConfiguration httpConfig = new HttpConfiguration();

      ConfigureOAuthTokenGeneration(app);

      ConfigureWebApi(httpConfig);

      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

      app.UseWebApi(httpConfig);
    }

    /// <summary>
    /// //Configure the db context and user manager to use a single instance per request
    /// </summary>
    /// <param name="app"></param>
    private void ConfigureOAuthTokenGeneration(IAppBuilder app)
    {
      
      app.CreatePerOwinContext(ApplicationDbContext.Create);
      app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

      //Plug in the OAuth bearer JSON web token
    }

    private void ConfigureWebApi(HttpConfiguration config)
    {
      config.MapHttpAttributeRoutes();

      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }
}