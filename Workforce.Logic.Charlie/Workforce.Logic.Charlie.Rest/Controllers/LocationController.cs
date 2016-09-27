using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Charlie.Domain;
using Workforce.Logic.Charlie.Domain.BusinessModels;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationController : ApiController
    {

        LogicHelper logHelp = new LogicHelper();

        /// <summary>
        /// Get locations filtered according to input parameter 
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await logHelp.GetAllLocations());
        }

        /// <summary>
        /// Insert new location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post([FromBody]LocationDto loc)
        {
            var success = await logHelp.InsertLocation(loc);
            if (success)
            {
                //email confirmation
                return Request.CreateResponse(HttpStatusCode.OK, "success!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
            }
        }

        /// <summary>
        /// update given location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Put([FromBody]LocationDto loc)
        {
            var success = await logHelp.UpdateLocation(loc);
            if (success)
            {
                //email confirmation
                return Request.CreateResponse(HttpStatusCode.OK, "success!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
            }
        }

        /// <summary>
        /// Delete given location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Delete([FromBody]LocationDto loc)
        {
            var success = await logHelp.DeleteLocation(loc);
            if (success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "success!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "failed to delete");
            }
        }

    }
}
