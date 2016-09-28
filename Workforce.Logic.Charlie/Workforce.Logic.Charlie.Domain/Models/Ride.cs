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
        AssociateAccess asac = new AssociateAccess();

        private readonly MapperConfiguration mapperRide = new MapperConfiguration(l => l.CreateMap<RideDao, RideDto>());
        private readonly MapperConfiguration mapperRide2 = new MapperConfiguration(l => l.CreateMap<RideDto, RideDao>());

        /// <summary>
        /// map a ride Dto to a Dao
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<RideDao> MapToSoap(RideDto ride)
        {
            var mapper = mapperRide2.CreateMapper();
            var dao =  mapper.Map<RideDao>(ride);
            dao.RideID = ride.RideId;
            dao.Associate = await AssocByEmail(ride.AssociateEmail);
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
                dto.DestinationLoc = 0;
                dto.DepartureLoc = 0;
                dto.DepartureTime = new DateTime(2063, 4, 5, 0, 0, 0);
            }
            else
            {
                dto.DepartureLoc = sched.DepartureLoc;
                dto.DestinationLoc = sched.DestinationLoc;
                dto.DepartureTime = sched.DepartureTime;
            }
            var assoc = await AssocById(ride.Associate);
            dto.AssociateEmail = assoc.Email;
            dto.AssociateFirst = assoc.FirstName;
            dto.AssociateLast = assoc.LastName;
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

        /// <summary>
        /// Returns associate with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Associate> AssocById(int id)
        {
            var assoc = new Associate();
            var list = await asac.GrabFromFelice();
            var result = list.Find(a => a.AssociateId == id);
            if (result != null)
            {
                assoc.AssociateId = id;
                assoc.Email = result.Email;
                assoc.FirstName = result.FirstName;
                assoc.LastName = result.LastName;
            }
            else
            {
                assoc.AssociateId = id;
                assoc.Email = "noemail";
                assoc.FirstName = "nofirstname";
                assoc.LastName = "nolastname";
            }
            return assoc;
        }

        /// <summary>
        /// Returns an associate id corresponding to given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<int> AssocByEmail(string email)
        {
            var associates = new List<Associate>();
            associates = await asac.GrabFromFelice();
            var result = associates.Find((a => a.Email == email));
            if (result != null)
            {
                return result.AssociateId;
            }
            else
            {
                return 0;
            }
        }
    }
}
