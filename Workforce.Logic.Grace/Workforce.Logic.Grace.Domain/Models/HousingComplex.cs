using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.GraceServiceReference;

namespace Workforce.Logic.Grace.Domain.Models
{
  public class HousingComplex
  {
    //have a method here to mapToDao and mapToDto
    //Have a method here to validate both the DAO's and DTO's



    //private readonly GraceServiceClient f = new GraceServiceClient();
    private readonly MapperConfiguration complexMapper = new MapperConfiguration(m => m.CreateMap<HousingComplexDao, HousingComplexDto>().ReverseMap());


    private bool validate(IEnumerable<HousingComplexDao> temp)
    {
      return true;
    }
    /// <summary>
    /// This method maps from a HousingComplexDao to a HousingComplexDto
    /// </summary>
    /// <param name="complex"></param>
    /// <returns>HousingComplexDto</returns>
    public HousingComplexDto MapToDto(HousingComplexDao complex)
    {
      var mapper = complexMapper.CreateMapper();
      return mapper.Map<HousingComplexDto>(complex);
    }

    /// <summary>
    /// This method maps from a HousingComplexDto to a HousingComplexDao
    /// </summary>
    /// <param name="complex"></param>
    /// <returns>HousingComplexDao</returns>
    public HousingComplexDao MapToDao(HousingComplexDto complex)
    {
      var mapper = complexMapper.CreateMapper();
      return mapper.Map<HousingComplexDao>(complex);
    }
    /// <summary>
    /// This method recieves an IEnumerable<HousginComplexDao>  and maps it
    /// into a list of List<HousingComplexDto>
    /// </summary>
    /// <param name="daos"></param>
    /// <returns>List<HousingComplexDto></returns>
    public List<HousingComplexDto> getDtoList(IEnumerable<HousingComplexDao> daos)
    {
      var complexes = new List<HousingComplexDto>();
      foreach (var item in daos)
      {
        var temp = MapToDto(item);
        complexes.Add(temp);
      }
      return complexes;
    }
    /// <summary>
    /// This method recieves an IEnumerable<HousingComplexDto> and maps it
    /// into a list of List<HousingComplexDao>
    /// </summary>
    /// <param name="dtos"></param>
    /// <returns> List<HousingComplexDao> </returns>
    public List<HousingComplexDao> getDaoList(IEnumerable<HousingComplexDto> dtos)
    {
      var complexes = new List<HousingComplexDao>();
      foreach (var item in dtos)
      {
        var temp = MapToDao(item);
        complexes.Add(temp);
      }
      return complexes;
    }

  }
}
