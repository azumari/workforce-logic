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
        /// Get all active requests with given departure and destination locations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> FindByEndpoints(string dept, string dest)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await logHelp.RequestsByEndpoints(dept, dest));
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
