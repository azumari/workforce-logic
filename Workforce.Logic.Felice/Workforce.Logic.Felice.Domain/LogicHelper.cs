using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Domain.WorkforceServiceReference;

namespace Workforce.Logic.Felice.Domain
{
   public class LogicHelper
   {
      private readonly FeliceServiceClient client = new FeliceServiceClient();
      private readonly Associate associateLogic = new Associate();
      private readonly Address addressLogic = new Address();
      private readonly Batch batchLogic = new Batch();
      //private readonly Gender genderLogic = new Gender();
      private readonly Instructor instructorLogic = new Instructor();

      #region All Associate Related Methods
      /// <summary>
      /// Basic 'Get' method that retrieves all associates regardless of active status
      /// </summary>
      public async Task<List<AssociateDto>> GetAllAssociates()
      {
         var associate = new List<AssociateDto>();
         var serviceAssociates = await client.GetAssociatesAsync();
         var serviceGenders = await client.GetGenderAsync();

         foreach (var item in serviceAssociates)
         {
            if (associateLogic.ValidateSoapData(item))
            {
               var parse = associateLogic.MapToRest(item);
               parse.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name;

               associate.Add(parse);
            }
         }
         return associate;
      }
     
      /// <summary>
      /// Attempts to add a new associate after ensuring the data being entered is valid
      /// </summary>
      public async Task<bool> AddNewAssociate(AssociateDto newAssociate)
      {
         if (associateLogic.ValidateRestData(newAssociate))
         {
            return await client.InsertAssociateAsync(associateLogic.MapToSoap(newAssociate));
         }
         else
         {
            return false;
         }
      }
      #endregion

      #region All methods related to Address
      /// <summary>
      /// Basic 'Get' method that retrieves all addresses regardless of active status
      /// </summary>
      public async Task<List<AddressDto>> GetAllAddresses()
      {
         var address = new List<AddressDto>();
         var serviceAddress = await client.GetAddressAsync();

         foreach (var item in serviceAddress)
         {
            if (addressLogic.ValidateSoapData(item))
            {
               address.Add(addressLogic.MapToRest(item));
            }
         }
         return address;
      }
      #endregion

      #region All methods related to Batch
      /// <summary>
      /// Basic 'Get' method that retrieves all batches regardless of active status
      /// </summary>
      public async Task<List<BatchDto>> GetAllBatches()
      {
         var batches = new List<BatchDto>();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceBatches)
         {
            if (batchLogic.ValidateSoapData(item))
            {
               batches.Add(batchLogic.MapToRest(item));
            }
         }
         return batches;
      }
      #endregion
   }
}
