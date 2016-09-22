using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Grace.Domain.Helpers;

namespace Workforce.Logic.Grace.Rest.Controllers
{
  public class IndexController : ApiController
  {

    /// <summary>
    /// This adds all entries into the dictionary for api controllers 
    /// </summary>
    /// <returns>key value pairs of method names and api/controller location</returns>
    public HttpResponseMessage Get()
    {
      var options = new Dictionary<string, string>();
      options.Add("getAllApartments", "api/Apartment");
      options.Add("getAllHousingComplexes", "api/HousingComplex");
      options.Add("getAllHousingData", "api/HousingData");
      options.Add("getAllStatuses", "api/Status");

      return Request.CreateResponse(HttpStatusCode.OK, options);
    }
  }
}
