using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Workforce.Logic.Felice.Rest.Controllers
{
   public class IndexController : ApiController
   {
      /// <summary>
      /// This is the base 'Get' method for Index
      /// The primary purpose of Index will be to provide the available "Menu" when an Api call is made to Felice.Rest
      /// </summary>
      public HttpResponseMessage Get()
      {
         var options = new Dictionary<string, string>();

         options.Add("Get Associates", "api/associate/");

         return Request.CreateResponse(HttpStatusCode.OK, options);
      }


   }
}
