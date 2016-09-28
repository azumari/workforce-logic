using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.GraceServiceReference;
using Workforce.Logic.Grace.Domain.Helpers;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Grace.Domain.Models
{
  public class D3DateProjection
  {
    private readonly GraceServiceClient graceService = new GraceServiceClient();
    private readonly LogicHelper logicHelper = new LogicHelper();

    public async Task<List<D3Projection>> getNewModel(DateTime projectionDate)
    {
      int totalMaxCapacity = 0;
      int totalCurCapacity = 2;

      foreach (var item in await logicHelper.HousingComplexsGetActive())
      {
        totalMaxCapacity += await returnComplexMaxCap(item);
        //totalCurCapacity += await returnComplexCurCap(item);
      }

      List<D3Projection> returnList = new List<D3Projection>();
      for (int i = 0; i < 37; i++)
      {
        D3Projection temp = new D3Projection();
        temp.TotalMax = totalMaxCapacity;
        temp.Date = projectionDate.ToString("yyyy-MM-dd");
        temp.CurrentCapacity = totalCurCapacity;
        totalCurCapacity += 3;
        returnList.Add(temp);
        projectionDate = projectionDate.AddDays(1.0);
      }
 

      return returnList;
    }

     
 
    private async Task<int> returnComplexCurCap(HousingComplexDto hotApt)
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


    private async Task<int> returnComplexMaxCap(HousingComplexDto hotApt)
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
  }
}
