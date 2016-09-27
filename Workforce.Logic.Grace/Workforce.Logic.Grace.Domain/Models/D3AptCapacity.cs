using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.GraceServiceReference;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Grace.Domain.Models
{
  public class D3AptCapacity
  {

    private readonly GraceServiceClient graceService = new GraceServiceClient();

    //method to give the max capacity of the given apartment 
    public async Task<int> returnComplexCurCap(HousingComplexDto hotApt)
    {
      int Total = 0;
      foreach (var item in await graceService.GetApartmentsAsync())
      {
        if (item.ActiveBit && (item.HotelID == hotApt.HotelID))
        {
          Total += item.CurrentCapacity;
        }
      }
      return Total;
    }

    //method to give the current capacity of the given apartment complex
    public async Task<int> returnComplexMaxCap(HousingComplexDto hotApt)
    {
      int Total = 0;
      foreach (var item in await graceService.GetApartmentsAsync())
      {
        if (item.ActiveBit && (item.HotelID == hotApt.HotelID))
        {
          Total += item.MaxCapacity;
        }
      }
      return Total;
    }

    public async Task<List<GraphAptCapacityDto>> getNewModel()
    {
      HousingComplex mapper = new HousingComplex();
      List<GraphAptCapacityDto> returnGraph = new List<GraphAptCapacityDto>();
      foreach (var item in await graceService.GetComplexesAsync())
      {
        returnGraph.Add(
          new GraphAptCapacityDto()
          {
            name = item.Name,
            maxCapacity = await returnComplexMaxCap(mapper.MapToDto(item)),
            currentCapacity = await returnComplexCurCap(mapper.MapToDto(item))
          });
      }
      return returnGraph;
    }
  }
}
