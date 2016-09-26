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

      AssociateDto newAssociate;

      public TestDomain()
      {
         client = new FeliceServiceClient();
         logic = new LogicHelper();
         expected = 1;

         newAssociate = new AssociateDto()
         {
            FirstName = "John",
            LastName = "Cena",
            Email = "john.cena@gmail.com"
         };
      }

      [Fact]
      public async void Test_GetAllAssociates()
      {
         var actual = await logic.GetAllAssociates();

         Assert.True(actual.Count >= expected);
      }

      [Fact]
      public async void Test_AddNewAssociate()
      {
         Assert.True(await logic.AddNewAssociate(newAssociate));
      }
   }
}
