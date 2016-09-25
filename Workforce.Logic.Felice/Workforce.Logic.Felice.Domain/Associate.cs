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
      private readonly MapperConfiguration associateMapper = new MapperConfiguration(t => t.CreateMap<AssociateDao, AssociateDto>().ForMember(t1 => t1.Gender, opt => opt.MapFrom(t2 => t2.GenderID.ToString())));
      private readonly MapperConfiguration associateReverseMapper = new MapperConfiguration(t => t.CreateMap<AssociateDto, AssociateDao>().ForMember(train => train.GenderID, m => m.MapFrom(gen => gen.Gender)));

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
      public bool ValidateClient(AssociateDto associate)
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
