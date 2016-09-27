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
      /// Tests the primary Update function for Associate
      /// NOTE: Presently Failing; Reason: Unknown
      /// </summary>
      [Fact]
      public async Task Test_UpdateAssociate()
      {
         var associate = new AssociateDto()
         {
            AssociateID = 3,
            FirstName = "Yuma",
            LastName = "Tsukumo",
            Email = "yuma.tsukumo334@gmail.com",
            Gender = "Male",
            IsComing = true,
            BatchID = 1,
         };

         bool passed = await logic.UpdateAssociate(associate);
         Assert.True(passed);
      }

      /// <summary>
      /// Tests the primary 'Delete' function for Associate
      /// </summary>
      [Fact]
      public async Task Test_DeleteAssociate()
      {
         var associate = new AssociateDto()
         {
            AssociateID = 15,
            FirstName = "FN1",
            LastName = "LN",
            Email = "dummy 9/17/2016 9:03:00 PM",
            Gender = "Male"
         };

         bool passed = await logic.DeactivateAssociate(associate);
         Assert.True(passed);
      }


      [Fact]
      public async Task Test_DeleteBatch()
      {
         var batch = new BatchDto()
         {
            BatchID = 40,
            Name = "FN1",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow
         };

         bool passed = await logic.DeactivateBatch(batch);
         Assert.True(passed);
      }

      [Fact]
      public async Task Test_UpdateBatch()
      {
         var batch = new BatchDto()
         {
            BatchID = 41,
            Name = "Stealing Knives",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow,
            Instructor = 2
         };

         bool passed = await logic.UpdateBatch(batch);
         Assert.True(passed);
      }

      [Fact]
      public async Task Test_AddBatch()
      {
         var batch = new BatchDto()
         {
            Name = "Stealing Knives",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow,
            Instructor = 2
         };

         bool passed = await logic.AddNewBatch(batch);
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

      [Fact]
      public async void Test_GetAllInstructors()
      {
         var actual = await logic.GetAllInstructors();

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
