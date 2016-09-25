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

        LocationRules lr = new LocationRules();

        /// <summary>
        /// Retreive all active meetup locations.
        /// </summary>
        /// <returns></returns>
        public async Task<List<LocationDto>> GetAllLocations()
        {
            var locs = new List<LocationDto>();
            var source = await client.GetLocationsAsync();
            var tests = lr.GetType().GetMethods();

            foreach (var item in source)
            {
                if (locModel.Validate(tests, item))
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
        /// Retreive all active requests.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RequestDto>> GetAllRequests()
        {
            var reqs = new List<RequestDto>();
            var source = await client.GetRequestAsync();

            foreach (var item in source)
            {
                    var newReq = reqModel.MapToRest(item);
                    reqs.Add(newReq);
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
