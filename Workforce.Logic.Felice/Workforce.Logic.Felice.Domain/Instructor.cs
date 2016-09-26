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
   public class Instructor
   {
      private readonly MapperConfiguration associateMapper = new MapperConfiguration(t => t.CreateMap<InstructorDao, InstructorDto>());
      private readonly MapperConfiguration associateReverseMapper = new MapperConfiguration(t => t.CreateMap<InstructorDto, InstructorDao>());

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(InstructorDao associate)
      {
         //reserved for validating information coming from the Data Layer
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public InstructorDto MapToRest(InstructorDao a)
      {
         var mapper = associateMapper.CreateMapper();
         return mapper.Map<InstructorDto>(a);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateClient(InstructorDto associate)
      {
         var context = new ValidationContext(associate);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(associate, context, results);
      }
      
      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public InstructorDao MapToSoap(InstructorDto a)
      {
         var mapper = associateReverseMapper.CreateMapper();
         return mapper.Map<InstructorDao>(a);
      }
   }
}
