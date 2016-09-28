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
   public class Gender
   {
      private readonly MapperConfiguration genderMapper = new MapperConfiguration(g => g.CreateMap<GenderDao, GenderDto>());
      private readonly MapperConfiguration genderReverseMapper = new MapperConfiguration(g => g.CreateMap<GenderDto, GenderDao>());
      private CoreValidator val = new CoreValidator();

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(GenderDao gender)
      {
         int maxName = 50;

         if (val.ValidateInt(gender.GenderID)
            && val.ValidateRequiredString(gender.Name, maxName))
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
      public GenderDto MapToRest(GenderDao g)
      {
         var mapper = genderMapper.CreateMapper();
         return mapper.Map<GenderDto>(g);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateRestData(GenderDto gender)
      {
         var context = new ValidationContext(gender);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(gender, context, results);
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public GenderDao MapToSoap(GenderDto g)
      {
         var mapper = genderReverseMapper.CreateMapper();
         return mapper.Map<GenderDao>(g);
      }
   }
}
