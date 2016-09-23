using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain.Models
{
    public class Location
    {

        /// <summary>
        /// Check that a Dao describes a valid location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool ValidateDao (LocationDao loc)
        {
            return true;
        }

        /// <summary>
        /// Check that a Dto describes a valid location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool ValidateDto (LocationDto loc)
        {
            return true;
        }

        /// <summary>
        /// map a location Dto to a Dao
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public LocationDao MapToSoap (LocationDto loc)
        {
            var result = new LocationDao();
            return result;
        }

        /// <summary>
        /// map a location Dao to a Dto
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public LocationDto MapToRest(LocationDao loc)
        {
            var result = new LocationDto();
            return result;
        }



    }
}
