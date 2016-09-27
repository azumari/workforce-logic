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
        //email confirmation
        EmailService email = new EmailService();
        var destination = req.AssociateEmail;
        var body = "Thank you for requesting a ride";
        var subject = "Ride Request";

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
    public async Task<HttpResponseMessage> Put([FromBody]RequestDto req,[FromBody]RideDto ride)
    {
      if (await logHelp.InviteToRide(req,ride))
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