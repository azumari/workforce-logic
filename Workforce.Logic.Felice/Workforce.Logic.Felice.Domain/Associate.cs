using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Domain.WorkforceServiceReference;

namespace Workforce.Logic.Felice.Domain
{
   public class Associate
   {
      FeliceServiceClient client = new FeliceServiceClient();

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateData()
      {
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public void MapToSoap()
      {

      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateClient(AssociateDto associate)
      {
         if (String.IsNullOrWhiteSpace(associate.FirstName) || String.IsNullOrWhiteSpace(associate.LastName) || String.IsNullOrWhiteSpace(associate.Gender))
            return false;
         else if (String.IsNullOrWhiteSpace(associate.PhoneNumber) || String.IsNullOrWhiteSpace(associate.Email))
            return false;
         else if (associate.BatchID <= 0)
            return false;
         else if (associate.HasCar.GetType() != typeof(bool) || associate.HasKeys.GetType() != typeof(bool) || associate.IsComing.GetType() != typeof(bool))
            return false;
         else
            return true;
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public void MapToSoap(AssociateDto a)
      {
         
      }
   }
}
