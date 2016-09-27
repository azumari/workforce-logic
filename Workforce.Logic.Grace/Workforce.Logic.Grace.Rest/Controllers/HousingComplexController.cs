﻿
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
  public class HousingComplexController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// CRUD: Read calls logicHelper to get all housingComplexes from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()//[FromUri] bool getActive)
    {
      bool getActive = true;
      if (getActive)
      {
        return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingComplexsGetActive());
      }
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
 