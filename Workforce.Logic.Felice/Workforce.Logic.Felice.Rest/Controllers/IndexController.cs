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
      /// collects all methods within a namespace; attempt 1
      /// </summary>
      private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
      {
         return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
      }
    
      /// <summary>
      /// This is the base 'Get' method for Index
      /// The primary purpose of Index will be to provide the available "Menu" when an Api call is made to Felice.Rest
      /// </summary>
      public HttpResponseMessage Get()
      {
         Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "MyNamespace");
         var options = new Dictionary<string, string>();

         for (int i = 0; i < typelist.Length; i++)
         {
            options.Add("", typelist[i].Name);
         }

         return Request.CreateResponse(HttpStatusCode.OK, options);
      }
   }
}
