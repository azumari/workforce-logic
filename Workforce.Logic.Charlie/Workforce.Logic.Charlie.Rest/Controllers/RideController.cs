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
        /// Get rides filtered according to input parameter 
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id1, int id2)
        {
            if (id1 == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "return all active rides");
            }
            if (id1 == 2)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "return rides with departure location id " + id2);
            }
            if (id1 == 3)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "return rides with destination location id " + id2);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "invalid parameter");
            }

        }

    }
}
