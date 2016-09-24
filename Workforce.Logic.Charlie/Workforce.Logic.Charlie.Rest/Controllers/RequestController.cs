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
    public class RequestController : ApiController
    {

        LogicHelper logHelp = new LogicHelper();

        /// <summary>
        /// Get all active requests  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> FindAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await logHelp.GetAllRequests());
        }

        /// <summary>
        /// Get all active requests with given departure location id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage FindByDeparture(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active requests with departure location id " + id);
        }

        /// <summary>
        /// Get all active requests with given destination location id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage FindByDestination(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "return all active requests with destination location id " + id);
        }

        /// <summary>
        /// Insert new request
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post([FromBody]RequestDto req)
        {
            if (await logHelp.InsertRequest(req))
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
