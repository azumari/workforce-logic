using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Domain.DomainModels;
using Workforce.Logic.Felice.Domain.WorkforceServiceReference;

namespace Workforce.Logic.Felice.Domain
{
   public class Associate
   {
      private readonly FeliceServiceClient client = new FeliceServiceClient();

      
      private readonly MapperConfiguration associateMapper = new MapperConfiguration(t => t.CreateMap<AssociateDao, AssociateDto>().ForMember(t1 => t1.Gender, opt => opt.MapFrom(t2 => t2.GenderID.ToString())));
      private readonly MapperConfiguration associateReverseMapper = new MapperConfiguration(t => t.CreateMap<AssociateDto, AssociateDao>().ForMember(t2 => t2.GenderID, m => m.MapFrom(t1 => t1.Gender)));
      
      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateData()
      {
         return true;
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public async Task<List<AssociateDto>> GetAllLocations()
      {
         var locs = new List<AssociateDto>();
         var source = await 

         foreach (var item in source)
         {
            locs.Add(logic.MapToBusiness(item));
         }
         return locs;
      }
   }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateClient(AssociateDto associate)
      {
         if (String.IsNullOrWhiteSpace(associate.FirstName) || String.IsNullOrWhiteSpace(associate.LastName) || String.IsNullOrWhiteSpace(associate.Gender))
            return false;
         else if (String.IsNullOrWhiteSpace(associate.PhoneNumber) || String.IsNullOrWhiteSpace(associate.Email))
            return false;
         else if (associate.BatchID <= 0)
            return false;
         else if (associate.HasCar.GetType() != typeof(bool) || associate.HasKeys.GetType() != typeof(bool) || associate.IsComing.GetType() != typeof(bool))
            return false;
         else
            return true;
      }

      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public AssociateDao MapToService(AssociateDto a)
      {
         var mapper = associateReverseMapper.CreateMapper();

         return mapper.Map<AssociateDao>(a);
      }
   }
}
