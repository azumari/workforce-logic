using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Charlie.Domain;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
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



    }
}
