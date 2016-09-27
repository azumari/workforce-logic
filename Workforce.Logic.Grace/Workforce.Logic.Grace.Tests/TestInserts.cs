using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.Helpers;
using Workforce.Logic.Grace.Domain.Models;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;
using Xunit;

namespace Workforce.Logic.Grace.Tests
{
  public class TestInserts
  {

    private readonly LogicHelper logicHelper = new LogicHelper();
    private readonly Consumers consumerHelper = new Consumers();

    /// <summary>
    ///  Test method to Insert Apartment
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_InsertApartment()
    {
      ApartmentDto aptDto = new ApartmentDto()
      {
        CurrentCapacity = 0,
        ActiveBit = true,
        GenderID = 2,
        HotelID =  68,
        RoomID = 1432,
        MaxCapacity = 6,
        RoomNumber = 3234
      };
      bool passed = await logicHelper.AddApartment(aptDto);
      Assert.True(passed);
    }

    /// <summary>
    /// Test method to Insert HousingComplex
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_InsertHousingComplex()
    {
      HousingComplexDto comlexDto = new HousingComplexDto()
      {
        Address = "340 Elvira st",
        IsHotel = true,
        Name = "Camden Dulles",
        PhoneNumber = "1-800-123-4567",
        ActiveBit = true
      };
      bool passed = await logicHelper.AddHousingComplex(comlexDto);
      Assert.True(passed);
    }

    /// <summary>
    /// Test method to Insert HousingData
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_InsertHousingData()
    {
      HousingDataDto dataDto = new HousingDataDto()
      {
        AssociateID = 2,
        MoveInDate = DateTime.Now,
        MoveOutDate = DateTime.Now,
        RoomID = 7,
        StatusID = 1
      };
      bool passed = await logicHelper.AddHousingData(dataDto);
      Assert.True(passed);
    }

    /// <summary>
    /// Test method to Insert Status
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_InsertStatus()
    {
      StatusDto statusDto = new StatusDto()
      {
        StatusColor = "purple",
        StatusID = 2,
        StatusMessage = "has diseases, YUK",
        ActiveBit = true
      };
      bool passed = await logicHelper.AddStatus(statusDto);
      Assert.True(passed);
    }


    /// <summary>
    /// this test case test inserting an associate by adding a new HousingData and updating currentCapacity of the room by 1
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_InsertAssociate()
    {

      int associateId = 2;
      int roomId = 7;

      //FIND THE ASSOCIATE FROM A LIST OF ASSOCIATES
      List<AssociateDto> assocList = await consumerHelper.ConsumeAssociatesFromAPI();
      AssociateDto assoc = assocList.Find(id => id.AssociateID.Equals(associateId));

      //FIND THE APARTMENT
      ApartmentDto aptDto = (await logicHelper.ApartmentsGetAll()).Find(id => id.RoomID.Equals(roomId));

      //FIND THE HousingComplex
      HousingComplexDto comDto = (await logicHelper.HousingComplexsGetAll()).Find(id => id.HotelID.Equals(aptDto.HotelID));


      HousingDataDto data = new HousingDataDto()
      {
        AssociateID = assoc.AssociateID,
        MoveInDate = DateTime.Now,
        MoveOutDate = DateTime.Now,
        RoomID = roomId,
        StatusID = 7
      };

      aptDto.CurrentCapacity++;
      aptDto.GenderID = 1;
      bool passed = await logicHelper.UpdateApartment(aptDto);


      bool passed2 = (await logicHelper.AddHousingData(data));

      Assert.True(passed && passed2);


    }

  }
}
