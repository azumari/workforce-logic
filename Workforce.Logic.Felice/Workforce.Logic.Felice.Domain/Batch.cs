using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;

namespace Workforce.Logic.Felice.Domain
{
   class Batch
   {
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
      public void MapToDomain()
      {

      }

      /// <summary>
      /// Validates the data that is passed in through on client side
      /// </summary>
      public bool ValidateClient(BatchDto batch)
      {
         DateTime _StartDate, _EndDate;

         if (batch.BatchID <= 0 || batch.InstructorID <= 0)
            return false;
         else if (String.IsNullOrWhiteSpace(batch.Name))
            return false;
         else if (!DateTime.TryParse(batch.StartDate.ToString(), out _StartDate) || !DateTime.TryParse(batch.EndDate.ToString(), out _EndDate))
            return false;
         else if (batch.StartDate <= DateTime.UtcNow || batch.EndDate <= batch.StartDate || batch.EndDate <= DateTime.UtcNow)
            return false;
         else
            return true;
      }

      /// <summary>
      /// After validation has occurred, this method will map the data passed through the Dto back to the Data Layer
      /// </summary>
      public void MapToData()
      {

      }
   }
}
