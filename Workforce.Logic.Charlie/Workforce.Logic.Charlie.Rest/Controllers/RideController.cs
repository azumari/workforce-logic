using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Charlie.Domain;
using Workforce.Logic.Charlie.Domain.Services;
using Workforce.Logic.Charlie.Domain.TransferModels;

namespace Workforce.Logic.Charlie.Rest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        /// Get all active rides with given departure and destination locations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> FindByEndpoints(int dept, int dest)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await logHelp.RidesByEndpoints(dept,dest));
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
              EmailService email = new EmailService();
              var destination = ride.AssociateEmail;
              var body = "Thank you for offering a ride";
              var subject = "Offer Ride";

              await email.SendAsync(destination, body, subject);

                return Request.CreateResponse(HttpStatusCode.OK, "success!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
            }
        }

        /// <summary>
        /// create a request corresponding to an existing ride 
        /// </summary>
        /// <param name="ride"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Put([FromBody]MatchDto match)
        {
            if (await logHelp.JoinRide(match))
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
        /// Delete given ride
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Delete([FromBody]RideDto ride)
        {
            if (await logHelp.DeleteRide(ride))
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
