using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    public class RequestController : ApiController
    {

        /// <summary>
        /// Get all active requests  
        /// </summary>
        /// <returns></returns>
       
        public HttpResponseMessage FindAll()
        {
                return Request.CreateResponse(HttpStatusCode.OK, "return all active requests");
        }

        /// <summary>
        /// Get all active requests with given departure location id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage FindByDeparture(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active requests with departure location id " + id);
        }

        /// <summary>
        /// Get all active requests with given destination location id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage FindByDestination(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active requests with destination location id " + id);
        }

    }
}
