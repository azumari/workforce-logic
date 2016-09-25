﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.Helpers;
using Xunit;

namespace Workforce.Logic.Grace.Tests
{
  public class TestInserts
  {

    private readonly LogicHelper logicHelper = new LogicHelper();



    [Fact]
    public async Task Test_InsertApartment()
    {
      ApartmentDto aptDto = new ApartmentDto()
      {
        CurrentCapacity = 2,
        GenderID = null,
        HotelID = null,
        MaxCapacity = 10,
        RoomNumber = 8460
      };
      bool passed = await logicHelper.AddApartment(aptDto);
      Assert.True(passed);
    }

    [Fact]
    public async Task Test_InsertHousingComplex()
    {
      HousingComplexDto comlexDto = new HousingComplexDto()
      {
        Address = "ha ha ha",
        IsHotel = true,
        Name = "2 star motel",
        PhoneNumber = "1-800-123-4567"
      };
      bool passed = await logicHelper.AddHousingComplex(comlexDto);
      Assert.True(passed);
    }

    [Fact]
    public async Task Test_InsertHousingData()
    {
      HousingDataDto dataDto = new HousingDataDto()
      {
        AssociateID = 20,
        MoveInDate = DateTime.Now,
        MoveOutDate = DateTime.Now,
        RoomID = 2,
        StatusID = 2
      };
      bool passed = await logicHelper.AddHousingData(dataDto);
      Assert.True(passed);
    }

    [Fact]
    public async Task Test_InsertStatus()
    {
      StatusDto statusDto = new StatusDto()
      {
        StatusColor = "Pink",
        StatusID = 2,
        StatusMessage = "YOUR FIRED"
      };
      bool passed = await logicHelper.AddStatus(statusDto);
      Assert.True(passed);

    }

  }
}
