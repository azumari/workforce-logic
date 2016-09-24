using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.TransferModels;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain.Models
{
    public class Ride
    {
        CharlieServiceClient client = new CharlieServiceClient();

        private readonly MapperConfiguration mapperRide = new MapperConfiguration(l => l.CreateMap<RideDao, RideDto>());
        private readonly MapperConfiguration mapperRide2 = new MapperConfiguration(l => l.CreateMap<RideDto, RideDao>());

        /// <summary>
        /// map a ride Dto to a Dao
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public RideDao MapToSoap(RideDto ride)
        {
            var mapper = mapperRide2.CreateMapper();
            return mapper.Map<RideDao>(ride);
        }

        /// <summary>
        /// map a ride Dao to a Dto
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public RideDto MapToRest(RideDao ride)
        {
            var mapper = mapperRide.CreateMapper();
            return mapper.Map<RideDto>(ride);
        }

    }
}
