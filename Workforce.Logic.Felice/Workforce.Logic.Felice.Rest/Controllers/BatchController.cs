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
    public class BatchController : ApiController
    {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This 'Get' method will get every Associate that exists in the database
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllBatches());
      }

      /// <summary>
      /// This is the base 'Get' method for Associate that returns results based on active status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetBatchesByStatus(status));
      }

      /// <summary>
      /// Adds a new Batch to the database
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]BatchDto batch)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewBatch(batch));
      }

      /// <summary>
      /// Deactivates (Deletes) an active Batch
      /// Must confirm if this will reactivate it too
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]BatchDto batch)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateBatch(batch));
      }

      /// <summary>
      /// takes in key information to update a specific Batch
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]BatchDto batch)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateBatch(batch));
      }
   }
}
