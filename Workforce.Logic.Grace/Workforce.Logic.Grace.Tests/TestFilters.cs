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
  public class TestFilters
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// this method tests the count of the list of apartments in a particular complex
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test_FilterApartments()
    {
      HousingComplexDto complexDto = new HousingComplexDto()
      {
        HotelID = 19
      };
      var actual = await logicHelper.FilterAptByComplex(complexDto);
      Assert.True(actual.Count.Equals(10));
    }

  }



}
