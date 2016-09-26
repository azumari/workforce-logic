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
    public class Request
    {

        CharlieServiceClient client = new CharlieServiceClient();

        private readonly MapperConfiguration mapperReq = new MapperConfiguration(l => l.CreateMap<RequestDao, RequestDto>());
        private readonly MapperConfiguration mapperReq2 = new MapperConfiguration(l => l.CreateMap<RequestDto, RequestDao>());

        /// <summary>
        /// map a request Dto to a Dao
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public RequestDao MapToSoap(RequestDto req)
        {
            var mapper = mapperReq2.CreateMapper();
            var dao = mapper.Map<RequestDao>(req);
            dao.RequestID = req.RequestId;
            //change when we can consume Associate!!
            dao.Associate = 6;
            return dao;
        }

        /// <summary>
        /// map a request Dao to a Dto
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<RequestDto> MapToRest(RequestDao req)
        {
            var mapper = mapperReq.CreateMapper();
            var dto = mapper.Map<RequestDto>(req);
            dto.RequestId = req.RequestID;
            var sched = await ScheduleById(req.Schedule);
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
