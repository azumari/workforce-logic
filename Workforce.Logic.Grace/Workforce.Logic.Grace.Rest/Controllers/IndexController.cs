using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Workforce.Logic.Grace.Rest.Controllers
{
  public class IndexController : ApiController
  {

    /// <summary>
    /// This adds all entries into the dictionary for api controllers 
    /// </summary>
    /// <returns>key value pairs of method names and api/controller location</returns>
    public Dictionary<string, string> Get()
    {
      var options = new Dictionary<string, string>();
      options.Add("getAllComplexes", "api/HousingComplex");
      return options;
    }
  }
}
