using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.GraceServiceReference;
using Workforce.Logic.Grace.Domain.Models;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Grace.Domain.Helpers
{
  public class D3jsHelper
  {

    /// <summary>
    /// this is the logic for getting the name of each apartment and the current and max capacity of each apartment complex
    /// </summary>
    /// <returns></returns>
    public async Task<List<GraphAptCapacityDto>> ReturnGraphAptCapacity()
    {
      D3AptCapacity aptCapacity = new D3AptCapacity();
      return await aptCapacity.getNewModel();


    }

    public async Task<List<D3Projection>> ReturnGraphProjection(DateTime projectionDate)
    {
      D3DateProjection d3DateProjection = new D3DateProjection();

      return await d3DateProjection.getNewModel(projectionDate);

       
    }
  }
}
