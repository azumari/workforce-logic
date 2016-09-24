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

    #region GetAlls()

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
      var daoDatas = await graceService.GetHousingDataAsync();
      var dtoDatas = housingDataVnM.getDtoList(daoDatas);

      //STILL NEED TO VALIDATE
      return dtoDatas;
    }

    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns> List<StatusDto> </returns>
    public async Task<List<StatusDto>> StatusesGetAll()
    {
      Status statusVnM = new Status();
      var daoStatuses = await graceService.GetStatusesAsync();
      var dtoStatuses = statusVnM.getDtoList(daoStatuses);

      //STILL NEED TO VALIDATE
      return dtoStatuses;
    }

    #endregion


    #region Insert methods for all models

    /// <summary>
    /// this method inserts a new apartment by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newApt"></param>
    /// <returns></returns>
    public async Task<bool> AddApartment(ApartmentDto newApt)
    {
      Apartment apartmentVnM = new Apartment();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE
           
      return await graceService.InsertApartmentAsync(apartmentVnM.MapToDao(newApt));      
    }
    /// <summary>
    /// this method inserts a new complex by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newComplex"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> AddHousingComplex(HousingComplexDto newComplex)
    {
      HousingComplex housingComplexVnM = new HousingComplex();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE

      HousingComplexDao daoMappedComp = housingComplexVnM.MapToDao(newComplex);

      return await graceService.InsertHousingComplexAsync(daoMappedComp);     
    }
    /// <summary>
    /// this method inserts a new housingData by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newData"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> AddHousingData(HousingDataDto newData)
    {
      HousingData housingDataVnM = new HousingData();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE

      return await graceService.InsertHousingDataAsync(housingDataVnM.MapToDao(newData));
    }
    /// <summary>
    /// this method inserts a new status by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newStatus"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> AddStatus(StatusDto newStatus)
    {
      Status statusVnM = new Status();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE
       
      return await graceService.InsertStatusAsync(statusVnM.MapToDao(newStatus));   
    }


    #endregion

  }
}
