using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Reflection;

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
         //all associate menu items
         options.Add("GetAllAssociate", "api/associate/findall");
         options.Add("GetAllActiveAssociates", "api/associate/findbystatus/true");
         options.Add("GetAllDeactiveAssociates", "api/associate/findbystatus/false");
         //all batch menu items
         options.Add("GetAllBatches", "api/batch/findall");
         options.Add("GetAllActiveBatches", "api/batch/findbystatus/true");
         options.Add("GetAllDeactiveBatches", "api/batch/findbystatus/false");
         //all instructor menu items
         options.Add("GetAllInstructors", "api/instructor/findall");
         options.Add("GetAllActiveInstructors", "api/instructor/findbystatus/true");
         options.Add("GetAllDeactiveInstructors", "api/instructor/findbystatus/false");
         //all gender menu items
         options.Add("GetAllGenders", "api/gender/");
         //all address menu items
         options.Add("GetAllAddresses", "api/address/findall");
         options.Add("GetAllActiveAddresses", "api/address/findbystatus/true");
         options.Add("GetAllDeactiveAddresses", "api/address/findbystatus/false");


         return Request.CreateResponse(HttpStatusCode.OK, options);
      }
   }
}
