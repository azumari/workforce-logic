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
      private readonly MapperConfiguration batchMapper = new MapperConfiguration(b => b.CreateMap<BatchDao, BatchDto>());
      private readonly MapperConfiguration batchReverseMapper = new MapperConfiguration(b => b.CreateMap<BatchDto, BatchDao>());
      private CoreValidator val = new CoreValidator();

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(BatchDao batch)
      {
         int maxName = 50;
         int maxSection = 100;

         if (val.ValidateInt(batch.BatchID)
            && val.ValidateDate(batch.EndDate)
            && val.ValidateInt(batch.Instructor)
            && val.ValidateRequiredString(batch.Name, maxName)
            && val.ValidateRequiredString(batch.Section, maxSection)
            && val.ValidateDate(batch.StartDate))
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public BatchDto MapToRest(BatchDao b)
      {
         var mapper = batchMapper.CreateMapper();
         return mapper.Map<BatchDto>(b);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateRestData(BatchDto batch)
      {
         var context = new ValidationContext(batch);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(batch, context, results);
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public BatchDao MapToSoap(BatchDto b)
      {
         var mapper = batchReverseMapper.CreateMapper();
         return mapper.Map<BatchDao>(b);
      }
   }
}