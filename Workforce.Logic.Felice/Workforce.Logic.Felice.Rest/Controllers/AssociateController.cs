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
      /// <summary>
      /// This is the base 'Get' method for Associate
      /// It is understood that 'Get' calls to associate will come through here
      /// </summary>
      public HttpResponseMessage Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK);
      } 
   }
}
