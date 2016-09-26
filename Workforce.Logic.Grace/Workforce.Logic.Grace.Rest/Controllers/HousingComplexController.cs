 
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
  public class HousingComplexController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// CRUD: Read calls logicHelper to get all housingComplexes from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingComplexsGetAll());
    }

    /// <summary>
    /// post method to insert a new complex
    /// </summary>
    /// <param name="newHousingComDto"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]HousingComplexDto newHousingComDto)
    { 
      if(await logicHelper.AddHousingComplex(newHousingComDto))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
    }
  }
}
 