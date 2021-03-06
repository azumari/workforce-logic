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
        AssociateAccess asac = new AssociateAccess();


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
                if (item.Active && (item.SeatsAvailable > 0))
                {
                    var newRide = await rideModel.MapToRest(item);
                    if (newRide.DepartureTime >= DateTime.Now)
                    {
                        rides.Add(newRide);
                    }
 
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
        public async Task<List<RideDto>> RidesByEndpoints(int loc)
        {
            var rides = new List<RideDto>();
            var source = await client.GetRideAsync();

            foreach (var item in source)
            {
                if (item.Active && item.SeatsAvailable > 0)
                {
                    var newRide = await rideModel.MapToRest(item);
                    if (newRide.DepartureLoc == loc || newRide.DestinationLoc == loc)
                    {
                        if (newRide.DepartureTime >= DateTime.Now)
                        {
                            rides.Add(newRide);
                        }
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
                    if (newReq.DepartureTime >= DateTime.Now)
                    {
                        reqs.Add(newReq);
                    }
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
        public async Task<List<RequestDto>> RequestsByEndpoints (int loc)
        {
            var reqs = new List<RequestDto>();
            var source = await client.GetRequestAsync();

            foreach (var item in source)
            {
                if (item.Active)
                {
                    var newReq = await reqModel.MapToRest(item);
                    if (newReq.DepartureLoc == loc || newReq.DestinationLoc == loc)
                    {
                        if (newReq.DepartureTime >= DateTime.Now)
                        {
                            reqs.Add(newReq);
                        }
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
            var toAdd = await rideModel.MapToSoap(ride);
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
            var toAdd = await reqModel.MapToSoap(req);
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
                var toNix = await reqModel.MapToSoap(req);
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
                var toNix = await rideModel.MapToSoap(ride);
                toNix.Schedule = 20;
                return await client.DeleteRideAsync(toNix);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region updates etc

        /// <summary>
        /// Match a new request to join an existing ride 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<bool> JoinRide(MatchDto match)
        {
            //validate 
            var toAdd = new RequestDao()
            {
                RequestID = 0,
                Associate = await AssocByEmail(match.ReqEmail),
            };
                try
                {
                    var allSched = await client.GetScheduleAsync();
                    var scId = allSched.Last(sc => sc.DepartureLoc == match.DeptLoc &&
                                                sc.DepartureTime == match.DeptTime &&
                                                sc.DestinationLoc == match.DestLoc).ScheduleID;
                    if (scId != 0)
                    {
                    toAdd.Active = false;
                    toAdd.Schedule = scId;
                    var added = await client.InsertRequestAsync(toAdd);
                        if (added)
                        {
                            var decremented = new RideDao()
                            {
                                RideID = match.RideId,
                                Associate = await AssocByEmail(match.RideEmail),
                                SeatsAvailable = match.Seats - 1,
                                Schedule = scId,
                                Active = true,
                            };
                            return await client.UpdateRideAsync(decremented);
                        }
                        else
                        {
                            return false;
                        }
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

        /// <summary>
        /// Create a new ride to answer an existing request
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<bool> InviteToRide(MatchDto match)
        {
            //validate ride, req
            var toAdd = new RideDao()
            {
                RideID = 0,
                Associate = await AssocByEmail(match.RideEmail),
                Active = true,
                SeatsAvailable = match.Seats - 1,
                Schedule = 0,
            };
                try
                {
                    var allSched = await client.GetScheduleAsync();
                    var scId = allSched.Last(sc => sc.DepartureLoc == match.DeptLoc &&
                                            sc.DepartureTime == match.DeptTime &&
                                            sc.DestinationLoc == match.DestLoc).ScheduleID;
                if (scId != 0)
                {
                    toAdd.Schedule = scId;
                    var added = await client.InsertRideAsync(toAdd);
                    if (added)
                    {
                        var met = new RequestDao()
                        {
                            RequestID = match.ReqId,
                            Associate = await AssocByEmail(match.RideEmail),
                            Schedule = scId,
                            Active = false,
                        };
                        return await client.UpdateRequestAsync(met);
                    }
                    else
                    {
                        return false;
                    }
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

        /// <summary>
        /// update location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public async Task<bool> UpdateLocation(LocationDto loc)
        {
            //validate locationdto
            try
            {
                var toUpdate = locModel.MapToSoap(loc);
                toUpdate.Active = true;
                return await client.UpdateLocationAsync(toUpdate);

            }
            catch
            {
                return false;
            }
        } 

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

        #endregion

    }
}
