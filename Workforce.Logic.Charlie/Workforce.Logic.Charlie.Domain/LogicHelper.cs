using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;

namespace Workforce.Logic.Charlie.Domain
{
    public class LogicHelper
    {
        WorkforceService.CharlieServiceClient client = new WorkforceService.CharlieServiceClient();

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
                var newLoc = new LocationDto();
                newLoc.LocationId = item.LocationId;
                newLoc.Address = item.Address;
                newLoc.Name = item.Name;
                newLoc.Latitude = item.Latitude;
                newLoc.Longitude = item.Longitude;
                locs.Add(newLoc);
            }
            return locs;
        }

    }
}
