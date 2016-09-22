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
    /// <returns>  List<ApartmentDto> apartments  </returns>
    public async Task<List<ApartmentDto>> GetApartments()
    {
      List<ApartmentDto> apartments = new List<ApartmentDto>();
      ApartmentDto toDelete = new ApartmentDto()
      {
        
        CurrentCapacity = 4,
        GenderID = 1,
        RoomID = 2,
        MaxCapacity = 10,
        RoomNumber = 1432
      };
      apartments.Add(toDelete);
      return apartments;
    }
    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns> List<HousingComplexDto> </returns>
    public async Task<List<HousingComplexDto>> GetHousingComplexs()
    {
      List<HousingComplexDto> complexes = new List<HousingComplexDto>();
      HousingComplexDto toDelete = new HousingComplexDto()
      {
        
        Address = "123 fake st",

        IsHotel = false,
        Name = "THIS IS A FAKE NAME",
        PhoneNumber = "956-793-3185"
      };
      complexes.Add(toDelete);
      return complexes;
    }
    /// <summary>
    ///  This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns>  List<HousingDataDto> </returns>
    public async Task<List<HousingDataDto>> GetHousingData()
    {
      List<HousingDataDto> temp = new List<HousingDataDto>();
      HousingDataDto toDelete = new HousingDataDto()
      {
        AssociateID = 1,
        RoomID = 2,
        MoveInDate = DateTime.Now,
        MoveOutDate = DateTime.Now,
        StatusID = 3
      };
      temp.Add(toDelete);
      return temp;
    }

    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns> List<StatusDto> </returns>
    public async Task<List<StatusDto>> GetStatuses()
    {
      List<StatusDto> temp = new List<StatusDto>();
      StatusDto toDelete = new StatusDto()
      {
        StatusColor = "Yellow",
        StatusID = 44,
        StatusMessage = "Missing Keys"
      };
      temp.Add(toDelete);
      return temp;
    }
  }
}
