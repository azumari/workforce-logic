using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.GraceServiceReference;
using Workforce.Logic.Grace.Domain.Models;

namespace Workforce.Logic.Grace.Domain.Helpers
{
  public class LogicHelper
  {
     
    private readonly GraceServiceClient graceService = new GraceServiceClient();

    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns>  List<ApartmentDto> apartments  </returns>
    public async Task<List<ApartmentDto>> ApartmentsGetAll()
    {
      Apartment apartmentVnM = new Apartment();
      var daoApartments= await graceService.GetApartmentsAsync();
      var dtoApartments = apartmentVnM.getDtoList(daoApartments);
      
      //STILL NEED TO VALIDATE
      return dtoApartments;
    }
    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns> List<HousingComplexDto> </returns>
    public async Task<List<HousingComplexDto>> HousingComplexsGetAll()
    {
      HousingComplex housingComplexVnM = new HousingComplex();
      var daoComplexes = await graceService.GetComplexesAsync();      
      var dtoComplexes = housingComplexVnM.getDtoList(daoComplexes);
            
      //STILL NEED TO VALIDATE
      return dtoComplexes;


    }
    /// <summary>
    ///  This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns>  List<HousingDataDto> </returns>
    public async Task<List<HousingDataDto>> HousingDataGetAll()
    {
      HousingData housingDataVnM = new HousingData();
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
    public async Task<List<StatusDto>> StatusesGetAll()
    {
      Status statusVnM = new Status();
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
