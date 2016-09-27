using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.Helpers;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;
using Xunit;

namespace Workforce.Logic.Grace.Tests
{
  public class TestUpdate
  {

    private readonly LogicHelper logicHelper = new LogicHelper();


    /// <summary>
    ///  Test method to Insert Apartment
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_UpdateHousingData()
    {
      HousingDataDto aptDto = new HousingDataDto()
      {


      };

      Assert.True(true);
    }

    [Fact]
    public async Task Test_UpdateApartment()
    {
      ApartmentDto aptDto = new ApartmentDto()
      {
        RoomID = 33,
        ActiveBit = true 
      }; 

      bool passed = await logicHelper.UpdateApartment(aptDto);
      Assert.True(passed);
    }

    [Fact]
    public async Task Test_UpdateHousingComplex()
    {
      HousingComplexDto comDto = new HousingComplexDto()
      {
        HotelID = 23,
        ActiveBit = true,
        Address = "CHANGED ADDRESS",
        Name = "CHANGED NAME",
        PhoneNumber = "CHANGED PHONE nUM",
        IsHotel = false
      };
      bool passed = await logicHelper.UpdateHousingComplex(comDto);
      Assert.True(passed);
      //Assert.True(await logicHelper.UpdateHousingComplex(new HousingComplexDto() {  HotelID = 23, ActiveBit = true}));
    }

    [Fact]
    public async Task Test_UpdateStatus()
    {
      StatusDto statDto = new StatusDto()
      {
        ActiveBit = true,
        StatusColor = "CHANGED COLOR",
        StatusMessage = "CHANGED MESSAGE",
        StatusID = 4
      };
      bool passed = await logicHelper.UpdateStatus(statDto);
      Assert.True(passed);
//      Assert.True(await logicHelper.UpdateStatus(new StatusDto() { ActiveBit = true, StatusID = 6 , StatusMessage = "new disease", StatusColor = "magenta"}));
    }

  }
}
