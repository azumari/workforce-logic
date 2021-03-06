﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Felice.Domain;
using Workforce.Logic.Felice.Domain.DomainModels;

namespace Workforce.Logic.Felice.Rest.Controllers
{
    public class AddressController : ApiController
   {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This 'Get' method returns all Associates regardless of status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllAddresses());
      }

      /// <summary>
      /// This is the base 'Get' method for Associate that retrieves data based on status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAddressesByStatus(status));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]AddressDto address)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewAddress(address));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]AddressDto address)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateAddress(address));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]AddressDto address)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateAddress(address));
      }
   }
}
