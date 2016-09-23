using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Domain.WorkforceServiceReference;

namespace Workforce.Logic.Felice.Domain
{
   class Instructor
   {
      FeliceServiceClient client = new FeliceServiceClient();

      /// <summary>
      /// Validates the data given by the data layer
      /// </summary>
      public bool ValidateData()
      {
         return true;
      }

      /// <summary>
      /// After validation has occurred, this method will map the data passed through the Data Layer to the Dto
      /// </summary>
      public void MapToRest()
      {

      }

      /// <summary>
      /// Validates the data that is passed in through on client side
      /// </summary>
      public bool ValidateClient(InstructorDto instructor)
      {
         if (instructor.InstructorID <= 0 || instructor.BatchID <= 0)
            return false;
         else if (String.IsNullOrWhiteSpace(instructor.FirstName) || String.IsNullOrWhiteSpace(instructor.LastName))
            return false;
         else
            return true;
      }

      /// <summary>
      /// After validation has occurred, this method will map the data passed through the Dto back to the Data Layer
      /// </summary>
      public void MapToSoap()
      {

      }
   }
}
