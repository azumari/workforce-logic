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
    public class InstructorController : ApiController
    {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This 'Get' method returns all Instructors regardless of status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllInstructors());
      }

      /// <summary>
      /// This is the base 'Get' method for Instructors that retrieves based on status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetInstructorsByStatus(status));
      }

      /// <summary>
      /// Adds a new Instructor to the database
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]InstructorDto instructor)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewInstructor(instructor));
      }

      /// <summary>
      /// Deactivates (Deletes) an active Instructor
      /// Must confirm if this will reactivate it too
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]InstructorDto instructor)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateInstructor(instructor));
      }

      /// <summary>
      /// takes in key information to update a specific Instructor
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]InstructorDto instructor)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateInstructor(instructor));
      }
   }
}
