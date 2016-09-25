﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.Models;
using Workforce.Logic.Charlie.Domain.TransferModels;
using Workforce.Logic.Charlie.Domain.Validation;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain
{
    public class LogicHelper
    {
        CharlieServiceClient client = new CharlieServiceClient();
        Location locModel = new Location();
        Ride rideModel = new Ride();
        Request reqModel = new Request();

        /// <summary>
        /// Retreive all active meetup locations.
        /// </summary>
        /// <returns></returns>
        public async Task<List<LocationDto>> GetAllLocations()
        {
            var locs = new List<LocationDto>();
            var source = await client.GetLocationsAsync();

            foreach (var item in source)
            {
                if (locModel.ValidateDao(item))
                {
                    var newLoc = locModel.MapToRest(item);
                    locs.Add(newLoc);
                }
            }
            return locs;
        }

        /// <summary>
        /// Retreive all active rides.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RideDto>> GetAllRides()
        {
            var rides = new List<RideDto>(); 
            var source = await client.GetRideAsync();

            foreach (var item in source)
            { 
                if (item.Active)
                {
                    var newRide = await rideModel.MapToRest(item);
                    rides.Add(newRide);
                }
            }
            return rides;
        }

        /// <summary>
        /// Return all active rides with the given departure and destination locations
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public async Task<List<RideDto>> RidesByEndpoints(string dept, string dest)
        {
            var rides = new List<RideDto>();
            var source = await client.GetRideAsync();

            foreach (var item in source)
            {
                if (item.Active)
                {
                    var newRide = await rideModel.MapToRest(item);
                    if (newRide.DepartureLoc == dept && newRide.DestinationLoc == dest)
                    {
                        rides.Add(newRide);
                    }
                }
            }
            return rides;
        }

        /// <summary>
        /// Retreive all active requests.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RequestDto>> GetAllRequests()
        {
            var reqs = new List<RequestDto>();
            var source = await client.GetRequestAsync();

            foreach (var item in source)
            {
                    var newReq = await reqModel.MapToRest(item);
                    reqs.Add(newReq);
            }
            return reqs;
        }


        /// <summary>
        /// Return all requests with the given departure and destination locations
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public async Task<List<RequestDto>> RequestsByEndpoints (string dept, string dest)
        {
            var reqs = new List<RequestDto>();
            var source = await client.GetRequestAsync();

            foreach (var item in source)
            {
                var newReq = await reqModel.MapToRest(item);
                if (newReq.DepartureLoc == dept && newReq.DestinationLoc == dest)
                {
                    reqs.Add(newReq);
                }
            }
            return reqs;
        }

        /// <summary>
        /// insert new location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<bool> InsertLocation(LocationDto loc)
        {
            //validate locationdto
            //implement exception catching
            var toAdd = locModel.MapToSoap(loc);
            return true;

        }

        /// <summary>
        /// insert new ride
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<bool> InsertRide(RideDto ride)
        {
            //validate ridedto
            //implement exception catching
            var toAdd = rideModel.MapToSoap(ride);
            return true;

        }

        public async Task<bool> InsertRequest(RequestDto req)
        {
            //validate locationdto
            //implement exception catching
            var toAdd = reqModel.MapToSoap(req);
            return true;

        }

    }
}
