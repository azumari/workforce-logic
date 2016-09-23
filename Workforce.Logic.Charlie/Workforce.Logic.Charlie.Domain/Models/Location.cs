using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain.Models
{
    public class Location
    {

        CharlieServiceClient client = new CharlieServiceClient();

        private readonly MapperConfiguration mapperLocation = new MapperConfiguration(l => l.CreateMap<LocationDao, LocationDto>());
        private readonly MapperConfiguration mapperLocation2 = new MapperConfiguration(l => l.CreateMap<LocationDto, LocationDao>());

        /// <summary>
        /// Check that a Dao describes a valid location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool ValidateDao (LocationDao loc)
        {
            return true;
        }

        /// <summary>
        /// Check that a Dto describes a valid location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool ValidateDto (LocationDto loc)
        {
            return true;
        }

        /// <summary>
        /// map a location Dto to a Dao
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public LocationDao MapToSoap (LocationDto loc)
        {
            var mapper = mapperLocation2.CreateMapper();
            return mapper.Map<LocationDao>(loc);
        }

        /// <summary>
        /// map a location Dao to a Dto
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public LocationDto MapToRest(LocationDao loc)
        {
            var mapper = mapperLocation.CreateMapper();
            return mapper.Map<LocationDto>(loc);
        }



    }
}
