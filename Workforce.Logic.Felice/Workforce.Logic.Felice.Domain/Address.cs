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
   public class Address
   {
      private readonly MapperConfiguration addressMapper = new MapperConfiguration(t => t.CreateMap<AddressDao, AddressDto>());
      private readonly MapperConfiguration addressReverseMapper = new MapperConfiguration(t => t.CreateMap<AddressDto, AddressDao>());

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(AddressDao address)
      {
         //reserved for validating information coming from the Data Layer
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public AddressDto MapToRest(AddressDao a)
      {
         var mapper = addressMapper.CreateMapper();
         return mapper.Map<AddressDto>(a);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateRestData(AddressDto address)
      {
         var context = new ValidationContext(address);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(address, context, results);
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public AddressDao MapToSoap(AddressDto a)
      {
         var mapper = addressReverseMapper.CreateMapper();
         return mapper.Map<AddressDao>(a);
      }
   }
}