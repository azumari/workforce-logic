using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Charlie.Domain;
using Workforce.Logic.Charlie.Domain.TransferModels;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    public class RideController : ApiController
    {

        LogicHelper logHelp = new LogicHelper();

        /// <summary>
        /// Get all active rides  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> FindAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await logHelp.GetAllRides());
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

        /// <summary>
        /// insert new ride 
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post([FromBody]RideDto ride)
        {
            if (await logHelp.InsertRide(ride))
            {
                //email confirmation
                return Request.CreateResponse(HttpStatusCode.OK, "success!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
            }
        }

    }
}
