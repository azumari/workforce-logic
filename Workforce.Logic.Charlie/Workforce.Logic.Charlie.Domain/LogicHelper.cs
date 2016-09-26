using System;
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


        #region get

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
                if (item.Active && locModel.ValidateDao(item))
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
        public async Task<List<RideDto>> RidesByEndpoints(int dept, int dest)
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
                if (item.Active)
                {
                    var newReq = await reqModel.MapToRest(item);
                    reqs.Add(newReq);
                }
            }
            return reqs;
        }

        /// <summary>
        /// Return all requests with the given departure and destination locations
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public async Task<List<RequestDto>> RequestsByEndpoints (int dept, int dest)
        {
            var reqs = new List<RequestDto>();
            var source = await client.GetRequestAsync();

            foreach (var item in source)
            {
                if (item.Active)
                {
                    var newReq = await reqModel.MapToRest(item);
                    if (newReq.DepartureLoc == dept && newReq.DestinationLoc == dest)
                    {
                        reqs.Add(newReq);
                    }
                }
            }
            return reqs;
        }

        #endregion

        #region insert

        /// <summary>
        /// insert new location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<bool> InsertLocation(LocationDto loc)
        {
            //validate locationdto
            try
            {
                var toAdd = locModel.MapToSoap(loc);
                toAdd.Active = true;
                return await client.InsertLocationAsync(toAdd);

            }
            catch
            {
                return false;
            }
         }

        /// <summary>
        /// insert new ride
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<bool> InsertRide(RideDto ride)
        {
            //validate ridedto
            var toAdd = rideModel.MapToSoap(ride);
            var sched = new ScheduleDao();
            sched.DepartureLoc = ride.DepartureLoc;
            sched.DepartureTime = ride.DepartureTime;
            sched.DestinationLoc = ride.DestinationLoc;
            sched.Active = true;
            if (sched.DepartureLoc == 0 || sched.DestinationLoc == 0)
            {
                return false;
            }
            else
            {
                try
                {
                    if (await client.InsertScheduleAsync(sched))
                    {
                        var allSched = await client.GetScheduleAsync();
                        var scId = allSched.Last(sc => sc.DepartureLoc == sched.DepartureLoc &&
                                                sc.DepartureTime == sched.DepartureTime &&
                                                sc.DestinationLoc == sched.DestinationLoc).ScheduleID;
                        toAdd.Schedule = scId;
                        toAdd.Active = true;
                        return await client.InsertRideAsync(toAdd);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                
            }
        }

        /// <summary>
        /// Insert a new Request
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<bool> InsertRequest(RequestDto req)
        {
            //validate requestdto
            var toAdd = reqModel.MapToSoap(req);
            var sched = new ScheduleDao();
            sched.DepartureLoc = req.DepartureLoc;
            sched.DepartureTime = req.DepartureTime;
            sched.DestinationLoc = req.DestinationLoc;
            sched.Active = true;
            if (sched.DepartureLoc == 0 || sched.DestinationLoc == 0)
            {
                return false;
            }
            else
            {
                try
                {
                    if (await client.InsertScheduleAsync(sched))
                    {
                        var allSched = await client.GetScheduleAsync();
                        var scId = allSched.Last(sc => sc.DepartureLoc == sched.DepartureLoc &&
                                                sc.DepartureTime == sched.DepartureTime &&
                                                sc.DestinationLoc == sched.DestinationLoc).ScheduleID;
                        toAdd.Schedule = scId;
                        toAdd.Active = true;
                        return await client.InsertRequestAsync(toAdd);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion

        #region delete

        /// <summary>
        /// Delete the given location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLocation(LocationDto loc)
        {
            try
            {
                var toNix = locModel.MapToSoap(loc);
                return await client.DeleteLocationAsync(toNix);
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Delete the given request
        /// assignment of Schedule compensates for difference between dao, dto forms
        /// only the id will be checked in the db
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRequest(RequestDto req)
        {
            try
            {
                var toNix = reqModel.MapToSoap(req);
                toNix.Schedule = 20; 
                return await client.DeleteRequestAsync(toNix);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete the given ride
        /// assignment of Schedule compensates for difference between dao, dto forms
        /// only the id will be checked in the db
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRide(RideDto ride)
        {
            try
            {
                var toNix = rideModel.MapToSoap(ride);
                toNix.Schedule = 20;
                return await client.DeleteRideAsync(toNix);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region updates and friends 

        //match ride to request

        //match request to ride

        //update location 

        //get riders? 

        /// <summary>
        /// Returns the location id corresponding to given stop name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> LocIdByName(string name)
        {
            var locs = await client.GetLocationsAsync();
            var result = Array.Find(locs, lc => lc.StopName == name);
            if(result != null && result.Active)
            {
                return result.LocationId;
            }
            else
            {
                return 0;
            }
        }

        #endregion

    }
}
