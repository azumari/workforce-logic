using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Domain.WorkforceServiceReference;

namespace Workforce.Logic.Felice.Domain
{
   public class Batch
   {
      private readonly MapperConfiguration batchMapper = new MapperConfiguration(t => t.CreateMap<BatchDao, BatchDto>());
      private readonly MapperConfiguration batchReverseMapper = new MapperConfiguration(t => t.CreateMap<BatchDto, BatchDao>());

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(BatchDao batch)
      {
         //reserved for validating information coming from the Data Layer
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public BatchDto MapToRest(BatchDao a)
      {
         var mapper = batchMapper.CreateMapper();
         return mapper.Map<BatchDto>(a);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateClient(BatchDto batch)
      {
         var context = new ValidationContext(batch);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(batch, context, results);
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public BatchDao MapToSoap(BatchDto a)
      {
         var mapper = batchReverseMapper.CreateMapper();
         return mapper.Map<BatchDao>(a);
      }
   }
}