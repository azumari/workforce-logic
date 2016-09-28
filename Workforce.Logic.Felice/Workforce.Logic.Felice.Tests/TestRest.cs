using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Rest.Controllers;
using Xunit;

namespace Workforce.Logic.Felice.Tests
{
   public class TestRest
   {
      //private bool worked;
      private HttpClient client;

      public TestRest()
      {
         client = new HttpClient();
      }

      /// <summary>
      /// this is a dud test for the time being
      /// research into proper testing of rest service in near future
      /// </summary>
      [Fact]
      public void Test_AddAssociate()
      {
         using (client)
         {
            var associate = new AssociateDto()
            {
               FirstName = "Katherine",
               LastName = "Pryde",
               Email = "kpryde1@gmail.com",
               Gender = "Female"
            };

            Assert.True(true);
         }
      }
   }
}
