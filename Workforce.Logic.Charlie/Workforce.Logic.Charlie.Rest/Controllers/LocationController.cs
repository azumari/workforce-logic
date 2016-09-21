using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    public class LocationController : ApiController
    {

        public HttpResponseMessage Get(int option)
        {
            return Request.CreateResponse(HttpStatusCode.OK, option);
        }

    }
}
