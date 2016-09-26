using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.Helpers;
using Xunit;

namespace Workforce.Logic.Grace.Tests
{
  public class TestDeletes
  {

    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// Test method to delete apartment
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_DeleteApartment()
    {
      ApartmentDto aptDto = new ApartmentDto()
      {
        RoomNumber = 53
      };
      bool passed = await logicHelper.DeleteApartment(aptDto);
      Assert.True(passed);
    }

    /// <summary>
    ///  Test method to delete HousingComplex
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_DeleteComplex()
    {
      HousingComplexDto complexDto = new HousingComplexDto()
      {
        HotelID = 56,
        Address = "ha ha ha",
        IsHotel = true,
        Name = "2 star motel",
        PhoneNumber = "1-800-123-4567",

      };
      bool passed = await logicHelper.DeleteComplex(complexDto);
      Assert.True(passed);
    }

    /// <summary>
    ///  Test method to delete HousingData
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_DeleteHousingData()
    {
      HousingDataDto dataDto = new HousingDataDto()
      {
        RoomID = 1
      };
      bool passed = await logicHelper.DeleteHousingData(dataDto);
      Assert.True(passed);
    }

    /// <summary>
    ///  Test method to delete Status
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_DeleteStatus()
    {
      StatusDto statusDto = new StatusDto()
      {
        StatusID = 4
      };
      bool passed = await logicHelper.DeleteStatus(statusDto);
      Assert.True(passed);

    }



  }
}
