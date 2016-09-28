using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.Helpers;

namespace Workforce.Logic.Grace.Rest.Controllers
{

  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class GetAssociatesController : ApiController
    {

    Consumers traineeConsumer = new Consumers();
    public async Task<HttpResponseMessage> Get([FromUri] ApartmentDto apartment)
    { 
      
      return Request.CreateResponse(HttpStatusCode.OK, await traineeConsumer.ConsumeAssociatesFromAPI());
    }
  }
}
