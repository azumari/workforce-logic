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
      HousingDataDto dataDto = new HousingDataDto()
      {
        AssociateID = 0,
        RoomID = 52
      };
      bool passed = await logicHelper.UpdateHousingData(dataDto);

      Assert.True(true);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_UpdateApartment()
    {

      List<ApartmentDto> listApt = await logicHelper.ApartmentsGetActvie();
      bool passed = true;
      foreach (var item in listApt)
      {
        item.GenderID = 9;
        if (await logicHelper.UpdateApartment(item))
        {
          passed = false;
        }
      } 
     
      Assert.True(passed);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_UpdateHousingComplex()
    {
      HousingComplexDto comDto = new HousingComplexDto()
      {
        HotelID = 23,
        ActiveBit = false,
        Address = "798798",
        Name = "798987798789",
        PhoneNumber = "987899897987",
        IsHotel = false
      };
      bool passed = await logicHelper.UpdateHousingComplex(comDto);
      Assert.True(passed);
      //Assert.True(await logicHelper.UpdateHousingComplex(new HousingComplexDto() {  HotelID = 23, ActiveBit = true}));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_UpdateStatus()
    {
      StatusDto statDto = new StatusDto()
      {

        StatusColor = "CHANGED COLOR",
        StatusMessage = "CHANGED MESSAGE",
        StatusID = 7
      };
      bool passed = await logicHelper.UpdateStatus(statDto);
      Assert.True(passed);
      //      Assert.True(await logicHelper.UpdateStatus(new StatusDto() { ActiveBit = true, StatusID = 6 , StatusMessage = "new disease", StatusColor = "magenta"}));
    }

  }
}
