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
  public class ApartmentController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// CRUD: Read calls logicHelper to get all Apartments from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.ApartmentsGetAll());
    }

    public async Task<HttpResponseMessage> Post([FromBody]object o)
    {
      var newApartmentDto = JsonConvert.DeserializeObject<ApartmentDto>(o.ToString());
      await logicHelper.AddApartment(newApartmentDto);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}
