using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;

namespace Workforce.Logic.Grace.Domain.Helpers
{
  public class LogicHelper
  {
     

    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns>List<HousingComplexDto></returns>
    public async Task<List<HousingComplexDto>> GetHousingComplexs()
    {
      List<HousingComplexDto> hotaps = new List<HousingComplexDto>();
      HousingComplexDto toDelete = new HousingComplexDto()
      {
        ActiveBit = false,
        Address = "123 fake st",
        
        IsHotel = false,
        Name = "THIS IS A FAKE NAME",
        PhoneNumber = "956-793-3185"
      };  
      hotaps.Add(toDelete);
      return hotaps;
    }
  }
}
