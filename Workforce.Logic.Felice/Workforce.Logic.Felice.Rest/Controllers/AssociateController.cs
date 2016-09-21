using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Workforce.Logic.Felice.Rest.Controllers
{
   public class AssociateController : ApiController
   {
      public HttpResponseMessage Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK);
      } 
   }
}
