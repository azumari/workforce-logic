using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.Models;
using Workforce.Logic.Charlie.Domain.Validation;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain
{
    public class LogicHelper
    {
        CharlieServiceClient client = new CharlieServiceClient();
        Location locModel = new Location();

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

    }
}
