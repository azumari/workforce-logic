﻿using System;
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
        public async Task<HttpResponseMessage> Get(int id1, string id2)
        {
            if (id1 == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, await logHelp.GetAllLocations());
            }
            if (id1 == 2)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "this will be some other option");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "invalid request");
            }
            
        }

    }
}
