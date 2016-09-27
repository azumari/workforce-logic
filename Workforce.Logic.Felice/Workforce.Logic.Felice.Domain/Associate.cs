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
   public class Associate
   {
      public int result;

      private readonly MapperConfiguration associateMapper = new MapperConfiguration(a => a.CreateMap<AssociateDao, AssociateDto>().ForMember(a1 => a1.Gender, opt => opt.MapFrom(a2 => a2.GenderID.ToString())));
      private readonly MapperConfiguration associateReverseMapper = new MapperConfiguration(a => a.CreateMap<AssociateDto, AssociateDao>().ForMember(a2 => a2.GenderID, m => m.MapFrom(a1 => int.Parse(a1.Gender))));

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(AssociateDao associate)
      {
         //reserved for validating information coming from the Data Layer
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public AssociateDto MapToRest(AssociateDao a)
      {
         var mapper = associateMapper.CreateMapper();
         return mapper.Map<AssociateDto>(a);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateRestData(AssociateDto associate)
      {
         var context = new ValidationContext(associate);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(associate, context, results);
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public AssociateDao MapToSoap(AssociateDto a)
      {
         var mapper = associateReverseMapper.CreateMapper();
         return mapper.Map<AssociateDao>(a);
      }
   }
}