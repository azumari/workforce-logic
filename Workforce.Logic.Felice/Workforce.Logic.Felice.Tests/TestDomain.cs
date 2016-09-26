using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain;
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

      [Fact]
      public async void Test_GetAllAssociates()
      {
         var actual = await logic.GetAllAssociates();

         Assert.True(actual.Count >= expected);
      }
   }
}
