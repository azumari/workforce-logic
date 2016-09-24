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
  public class Apartment
  {
    //have a method here to mapToDao and mapToDto
    //Have a method here to validate both the DAO's and DTO's



    //private readonly GraceServiceClient f = new GraceServiceClient();
    private readonly MapperConfiguration apartmentMapper = new MapperConfiguration(m => m.CreateMap<ApartmentDao, ApartmentDto>().ReverseMap());


    private bool validate(IEnumerable<ApartmentDto> temp)
    {

      return true;
    }


    /// <summary>
    /// This method maps from a ApartmentDao to a ApartmentDto
    /// </summary>
    /// <param name="apt"></param>
    /// <returns>ApartmentDto</returns>
    private ApartmentDto MapToDto(ApartmentDao apt)
    {

      var mapper = apartmentMapper.CreateMapper();
      return mapper.Map<ApartmentDto>(apt);
    }

    /// <summary>
    /// This method maps from a ApartmentDto to a ApartmentDao
    /// </summary>
    /// <param name="apt"></param>
    /// <returns>ApartmentDao</returns>
    private ApartmentDao MapToDao(ApartmentDto apt)
    {
      var mapper = apartmentMapper.CreateMapper();
      return mapper.Map<ApartmentDao>(apt);
    }

     


    public List<ApartmentDto> getDtoList(IEnumerable<ApartmentDao> daos)
    {
      var apts = new List<ApartmentDto>();
      foreach (var item in daos)
      {
        var temp = MapToDto(item);
        apts.Add(temp);
      }
      return apts;
    }

  }
}
