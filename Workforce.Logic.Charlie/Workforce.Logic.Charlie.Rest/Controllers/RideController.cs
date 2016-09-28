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
                var locs = await logHelp.GetAllLocations();
                var deptLoc = locs.Find(l => l.LocationId == ride.DepartureLoc);
                var destLoc = locs.Find(l => l.LocationId == ride.DestinationLoc);
                //email confirmation
              EmailService email = new EmailService();
              var destination = ride.AssociateEmail;
              var body = "You have offered a ride from "+deptLoc.StopName+" to "+destLoc.StopName+
                    " on "+ride.DepartureTime.ToString()
                    +" with "+ride.SeatsAvailable.ToString()+
                    " seats available. You will receive email confirmation if any of your colleagues are matched as riders.";
              var subject = "Thank you for offering a ride!";

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
                var locs = await logHelp.GetAllLocations();
                var deptLoc = locs.Find(l => l.LocationId == match.DeptLoc);
                var destLoc = locs.Find(l => l.LocationId == match.DestLoc);
                var remaining = match.Seats - 1;

                EmailService email1 = new EmailService();
                var destination1 = match.ReqEmail;
                var body1 = "You have joined a ride from " + deptLoc.StopName + " to " + destLoc.StopName +
                      " on " + match.DeptTime.ToString() + "! Your driver may be reached at "
                      + match.RideEmail;
                var subject1 = "Ride joined!";

                await email1.SendAsync(destination1, body1, subject1);

                EmailService email2 = new EmailService();
                var destination2 = match.RideEmail;
                var body2 = "A passenger has joined your ride from " + deptLoc.StopName + " to " + destLoc.StopName +
                      " on " + match.DeptTime.ToString() + "! Your passenger may be reached at "
                      + match.ReqEmail + " and you have " + remaining.ToString() + " remaining open seats.";
                var subject2 = "You have a passenger!";

                await email1.SendAsync(destination2, body2, subject2);
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
