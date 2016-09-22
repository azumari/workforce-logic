using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    public class RideController : ApiController
    {

        /// <summary>
        /// Get all active rides  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage FindAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active rides");
        }

        /// <summary>
        /// Get all active rides with given departure location id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage FindByDeparture(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active rides with departure location id " + id);
        }

        /// <summary>
        /// Get all active rides with given destination location id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage FindByDestination(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active rides with destination location id " + id);
        }

    }
}
