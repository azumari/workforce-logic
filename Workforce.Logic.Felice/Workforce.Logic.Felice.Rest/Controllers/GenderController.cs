using System;
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
    public class GenderController : ApiController
    {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This is the base 'Get' method for Gender
      /// It is understood that 'Get' calls to gender will come through here
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllGenders());
      }

      /// <summary>
      /// This is the base Insert (Post) method for Gender
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]GenderDto gender)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewGender(gender));
      }

      /// <summary>
      /// This is the base 'Delete' method for Gender
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]GenderDto gender)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateGender(gender));
      }

      /// <summary>
      /// This is the base Update (Put) method for Gender
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]GenderDto gender)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateGender(gender));
      }
   }
}
