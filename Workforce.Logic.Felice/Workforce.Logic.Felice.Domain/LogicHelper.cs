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

      #region All methods related to Associate
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
      /// Attempts to add a new associate after ensuring that the data entered is valid
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

      /// <summary>
      /// Changes the active status of an associate
      /// This is essentially the 'Delete' method
      /// </summary>
      public async Task<bool> DeactivateAssociate(AssociateDto delAssociate)
      {
         if (associateLogic.ValidateRestData(delAssociate))
         {
            return await client.DeleteAssociateAsync(associateLogic.MapToSoap(delAssociate));
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// This is the basic 'Update' method for Associate
      /// </summary>
      public async Task<bool> UpdateAssociate(AssociateDto update)
      {
         if (associateLogic.ValidateRestData(update))
         {
            return await client.UpdateAssociateAsync(associateLogic.MapToSoap(update));
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

      /// <summary>
      /// Attempts to add a new address after ensuring that the data entered is valid
      /// </summary>
      public async Task<bool> AddNewAddress(AddressDto newAddress)
      {
         if (addressLogic.ValidateRestData(newAddress))
         {
            return await client.InsertAddressAsync(addressLogic.MapToSoap(newAddress));
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// Changes the active status of an address
      /// This is essentially the 'Delete' method
      /// </summary>
      public async Task<bool> DeactivateAddress(AddressDto delAddress)
      {
         if (addressLogic.ValidateRestData(delAddress))
         {
            return await client.DeleteAddressAsync(addressLogic.MapToSoap(delAddress));
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// This is the basic 'Update' method for Address
      /// </summary>
      public async Task<bool> UpdateAddress(AddressDto update)
      {
         if (addressLogic.ValidateRestData(update))
         {
            return await client.UpdateAddressAsync(addressLogic.MapToSoap(update));
         }
         else
         {
            return false;
         }
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

      /// <summary>
      /// Attempts to add a new batch after ensuring that the data entered is valid
      /// </summary>
      public async Task<bool> AddNewBatch(BatchDto newBatch)
      {
         if (batchLogic.ValidateRestData(newBatch))
         {
            return await client.InsertBatchAsync(batchLogic.MapToSoap(newBatch));
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// Changes the active status of a batch
      /// This is essentially the 'Delete' method
      /// </summary>
      public async Task<bool> DeactivateBatch(BatchDto delBatch)
      {
         if (batchLogic.ValidateRestData(delBatch))
         {
            return await client.DeleteBatchAsync(batchLogic.MapToSoap(delBatch));
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// This is the basic 'Update' method for Batch
      /// </summary>
      public async Task<bool> UpdateBatch(BatchDto update)
      {
         if (batchLogic.ValidateRestData(update))
         {
            return await client.UpdateBatchAsync(batchLogic.MapToSoap(update));
         }
         else
         {
            return false;
         }
      }
      #endregion
   }
}
