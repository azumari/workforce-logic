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
      private readonly MapperConfiguration associateMapper = new MapperConfiguration(i => i.CreateMap<InstructorDao, InstructorDto>());
      private readonly MapperConfiguration associateReverseMapper = new MapperConfiguration(i => i.CreateMap<InstructorDto, InstructorDao>());

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(InstructorDao instructor)
      {
         //reserved for validating information coming from the Data Layer
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public InstructorDto MapToRest(InstructorDao i)
      {
         var mapper = associateMapper.CreateMapper();
         return mapper.Map<InstructorDto>(i);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateRestData(InstructorDto instructor)
      {
         var context = new ValidationContext(instructor);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(instructor, context, results);
      }
      
      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public InstructorDao MapToSoap(InstructorDto i)
      {
         var mapper = associateReverseMapper.CreateMapper();
         return mapper.Map<InstructorDao>(i);
      }
   }
}
