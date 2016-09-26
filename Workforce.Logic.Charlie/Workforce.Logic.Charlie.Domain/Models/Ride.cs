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
            var dao =  mapper.Map<RideDao>(ride);
            dao.RideID = ride.RideId;
            //change this when we can consume Associates! 
            dao.Associate = 5;
            return dao;
        }

        /// <summary>
        /// map a ride Dao to a Dto
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<RideDto> MapToRest(RideDao ride)
        {
            var mapper = mapperRide.CreateMapper();
            var dto = mapper.Map<RideDto>(ride);
            dto.RideId = ride.RideID;
            var sched = await ScheduleById(ride.Schedule);
            if (sched == null)
            {
                dto.DestinationLoc = "no destination";
                dto.DepartureLoc = "no departure location";
                dto.DepartureTime = new DateTime(2063, 4, 5, 0, 0, 0);
            }
            else
            {
                var deptloc = await LocationById(sched.DepartureLoc);
                dto.DepartureLoc = deptloc.StopName;
                var destloc = await LocationById(sched.DestinationLoc);
                dto.DestinationLoc = destloc.StopName;
                dto.DepartureTime = sched.DepartureTime;
            }
            return dto;
        }

        /// <summary>
        /// Returns the schedule with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ScheduleDao> ScheduleById(int id)
        {
            var scheds = await client.GetScheduleAsync();
            return Array.Find(scheds, sc => sc.ScheduleID == id);
        }

        /// <summary>
        /// Returns the location with the given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LocationDao> LocationById(int id)
        {
            var locs = await client.GetLocationsAsync();
            return Array.Find(locs, lc => lc.LocationId == id);
        }
    }
}
