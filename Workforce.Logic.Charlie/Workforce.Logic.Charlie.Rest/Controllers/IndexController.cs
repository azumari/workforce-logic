using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    public class IndexController : ApiController
    {
        /// <summary>
        /// Display menu of available Get options
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            var options = new Dictionary<string, string>();
            options.Add("get all locations", "api/location/Get/1/all");
            return Request.CreateResponse(HttpStatusCode.OK, options);
        }

    }
}
