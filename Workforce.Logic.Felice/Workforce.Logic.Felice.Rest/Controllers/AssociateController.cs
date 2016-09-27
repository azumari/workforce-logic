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
   public class AssociateController : ApiController
   {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This is the base 'Get' method for Associate
      /// It is understood that 'Get' calls to associate will come through here
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllAssociates());
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]AssociateDto associate)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewAssociate(associate));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]AssociateDto associate)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateAssociate(associate));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]AssociateDto associate)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateAssociate(associate));
      }
   }
}