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

    public async Task<List<HousingComplexDto>> GetHousingComplexs()
    {
      List<HousingComplexDto> hotaps = new List<HousingComplexDto>();

      HousingComplexDto toDelete = new HousingComplexDto()
      {
        ActiveBit = false,
        Address = "123 fake st",
        HotelID = 1,
        IsHotel = false,
        Name = "THIS IS A FAKE NAME",
        PhoneNumber = "956-793-3185"
      };
      hotaps.Add(toDelete);
      return hotaps;
    }
  }
}
