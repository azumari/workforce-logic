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
  public class RequestController : ApiController
  {

    LogicHelper logHelp = new LogicHelper();

    ///<summary>
    ///Get all active requests  
    ///</summary>
    ///<returns></returns>
    [HttpGet]
    public async Task<HttpResponseMessage> FindAll()
    {
      return Request.CreateResponse(HttpStatusCode.OK, await logHelp.GetAllRequests());
    }

    ///<summary>
    ///Get all active requests with given departure and destination locations
    ///</summary>
    ///<param name="id"></param>
    ///<returns></returns>
    [HttpGet]
    public async Task<HttpResponseMessage> FindByEndpoints(int dept, int dest)
    {
      return Request.CreateResponse(HttpStatusCode.OK, await logHelp.RequestsByEndpoints(dept, dest));
    }

    /// <summary>
    ///Insert new request
    ///</summary>
    ///<param name="req"></param>
    ///<returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]RequestDto req)
    {
      if (await logHelp.InsertRequest(req))
      {
                var locs = await logHelp.GetAllLocations();
                var deptLoc = locs.Find(l => l.LocationId == req.DepartureLoc);
                var destLoc = locs.Find(l => l.LocationId == req.DestinationLoc);
                //email confirmation
                EmailService email = new EmailService();
                var destination = req.AssociateEmail;
                var body = "You have requested a ride from " + deptLoc.StopName + " to " + destLoc.StopName +
                      " on " + req.DepartureTime.ToString()
                      + ". You will receive email confirmation if any of your colleagues offers to drive!.";
                var subject = "Successful Ride Request";

                await email.SendAsync(destination, body, subject);
                return Request.CreateResponse(HttpStatusCode.OK, "success!");
      }
      else
      {
        return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
      }
    }
    
    
    ///<summary>
    ///create a ride corresponding to an existing request 
    ///</summary>
    ///<param name="req"></param>
    ///<param name="ride"></param>
    ///<returns></returns>
    public async Task<HttpResponseMessage> Put([FromBody]MatchDto match)
    {
      if (await logHelp.InviteToRide(match))
      {
                var locs = await logHelp.GetAllLocations();
                var deptLoc = locs.Find(l => l.LocationId == match.DeptLoc);
                var destLoc = locs.Find(l => l.LocationId == match.DestLoc);
                var remaining = match.Seats - 1;

                EmailService email1 = new EmailService();
                var destination1 = match.ReqEmail;
                var body1 = "Your request of a ride from " + deptLoc.StopName + " to " + destLoc.StopName +
                      " on " + match.DeptTime.ToString()+" has been filled! Your driver may be reached at "
                      +match.RideEmail;
                var subject1 = "Request filled!";

                await email1.SendAsync(destination1, body1, subject1);

                EmailService email2 = new EmailService();
                var destination2 = match.RideEmail;
                var body2 = "You have offered a ride from " + deptLoc.StopName + " to " + destLoc.StopName +
                      " on " + match.DeptTime.ToString() + "! Your passenger may be reached at "
                      + match.ReqEmail + " and you have " + remaining.ToString() + " remaining open seats.";
                var subject2 = "Thank you for offering a ride!";

                await email1.SendAsync(destination2, body2, subject2);

                return Request.CreateResponse(HttpStatusCode.OK, "success!");
      }
      else
      {
        return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
      }
    }

    /// <summary>
    ///Delete given request
    ///</summary>
    ///<param name="req"></param>
    ///<returns></returns>
    public async Task<HttpResponseMessage> Delete([FromBody]RequestDto req)
    {
      if (await logHelp.DeleteRequest(req))
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