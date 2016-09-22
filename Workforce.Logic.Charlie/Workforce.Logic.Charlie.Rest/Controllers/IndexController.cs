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
            options.Add("getAllLocations", "api/location");
            options.Add("getAllRides", "api/ride/findall");
            options.Add("getAllRequests", "api/request/findall");
            options.Add("getRidesByDepartureLocationId", "api/ride/findbydeparture/{id}");
            options.Add("getRequestsByDepartureLocationId", "api/request/findbydeparture/{id}");
            options.Add("getRidesByDestinationLocationId", "api/ride/findbydestination/{id}");
            options.Add("getRequestsByDestinationLocationId", "api/request/findbydestination/{id}");
            return Request.CreateResponse(HttpStatusCode.OK, options);
        }

    }
}
