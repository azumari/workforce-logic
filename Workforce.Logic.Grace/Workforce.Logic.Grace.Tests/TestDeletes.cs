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

    [Fact] 
    public async Task Test_DeleteApartment()
    { 
      ApartmentDto aptDto = new ApartmentDto()
      {
        RoomNumber = 71
      };
      bool passed = await logicHelper.DeleteApartment(aptDto);
      Assert.True(passed);
    }
  }
} 
