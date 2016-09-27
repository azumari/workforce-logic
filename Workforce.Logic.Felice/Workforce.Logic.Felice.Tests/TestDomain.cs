using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Domain.WorkforceServiceReference;
using Xunit;

namespace Workforce.Logic.Felice.Tests
{
   public class TestDomain
   {
      public int expected;
      private LogicHelper logic;
      private FeliceServiceClient client;

      public TestDomain()
      {
         client = new FeliceServiceClient();
         logic = new LogicHelper();
         expected = 1;
      }

      /// <summary>
      /// Tests the primary 'Insert' function for Associate
      /// </summary>
      [Fact]
      public async Task Test_AddAssociate()
      {
         var associate = new AssociateDto()
         {
            FirstName = "Katherine",
            LastName = "Pryde",
            Email = "kpryde1@gmail.com",
            Gender = "Female"
         };

         bool passed = await logic.AddNewAssociate(associate);
         Assert.True(passed);
      }

      /// <summary>
      /// Tests the primary 'Get' function for Associates
      /// </summary>
      [Fact]
      public async void Test_GetAllAssociates()
      {
         var actual = await logic.GetAllAssociates();

         Assert.True(actual.Count >= expected);
      }

      /*
      [Fact]
      public async void Test_UpdateAssociate()
      {
         Assert.True(await logic.UpdateAssociate());
      }
      */
   }
}
