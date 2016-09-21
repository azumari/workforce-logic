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
    public Dictionary<string, string> Get()
    {
      var options = new Dictionary<string, string>();
      options.Add("getAllComplexes", "api/HousingComplex");
      return options;
    }
  }
}
