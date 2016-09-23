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
      private readonly Associate associatelogic = new Associate();

      public async Task<List<AssociateDto>> GetAllAssociates()
      {
         var associate = new List<AssociateDto>();
         var serviceAssociates = await client.GetAssociatesAsync();

         foreach (var item in serviceAssociates)
         {
            if (associatelogic.ValidateSoapData(item))
            {
               associate.Add(associatelogic.MapToRest(item));
            }
         }
         return associate;
      }
   }
}
