using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.Helpers;

namespace Workforce.Logic.Grace.Rest.Controllers
{
  public class StatusController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();
    /// <summary>
    /// CRUD: Read calls logicHelper to get all Apartments from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.StatusesGetAll());
    }

    public async Task<HttpResponseMessage> Post([FromBody]object o)
    {
      var newStatus = JsonConvert.DeserializeObject<StatusDto>(o.ToString());
      await logicHelper.AddStatus(newStatus);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}
