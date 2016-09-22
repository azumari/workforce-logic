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
            options.Add("get all locations", "api/location/get/");
            options.Add("get all rides", "api/ride/get/1/1");
            options.Add("get all requests", "api/request/get/1/1");
            options.Add("get rides by departure location id", "api/ride/get/2/{id}");
            options.Add("get requests by departure location id", "api/request/get/2/{id}");
            options.Add("get rides by destination location id", "api/ride/get/3/{id}");
            options.Add("get requests by destination location id", "api/request/get/3/{id}");
            return Request.CreateResponse(HttpStatusCode.OK, options);
        }

    }
}
