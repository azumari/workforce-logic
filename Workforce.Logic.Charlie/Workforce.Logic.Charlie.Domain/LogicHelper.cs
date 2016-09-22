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

        /// <summary>
        /// Retreive all active meetup locations.
        /// </summary>
        /// <returns></returns>
        public async Task<List<LocationDto>> GetAllLocations()
        {
            var locs = new List<LocationDto>();
            var dummy = new LocationDto();
            dummy.Name = "Nowhere";
            dummy.Address = "123 Fictitious Dr, Herndon, VA";
            dummy.Latitude = 40.5;
            dummy.Longitude = 40.5;
            locs.Add(dummy);
            return locs;
        }

    }
}
