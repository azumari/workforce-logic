using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.Validation;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain.Models
{
    public class Location
    {

        CharlieServiceClient client = new CharlieServiceClient();

        private readonly MapperConfiguration mapperLocation = new MapperConfiguration(l => l.CreateMap<LocationDao, LocationDto>());
        private readonly MapperConfiguration mapperLocation2 = new MapperConfiguration(l => l.CreateMap<LocationDto, LocationDao>());

        public delegate bool Ruling(object o);

        /// <summary>
        /// Check that a valid location is described
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool Validate (ICollection<System.Reflection.MethodInfo> d, object o)
        {
            //foreach(var item in d)
            //{
            //    if (item.GetType() == typeof(Ruling))
            //    {
            //        var locRule = new LocationRules();
            //        var param = new object[1];
            //        param[0] = o;
            //        var result = Convert.ToBoolean(item.Invoke(locRule, param));
            //        if (!result)
            //        { 
            //            return false;
            //        }
            //    }
            //}
            return true;
        }

        /// <summary>
        /// map a location Dto to a Dao
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public LocationDao MapToSoap (LocationDto loc)
        {
            var mapper = mapperLocation2.CreateMapper();
            return mapper.Map<LocationDao>(loc);
        }

        /// <summary>
        /// map a location Dao to a Dto
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public LocationDto MapToRest(LocationDao loc)
        {
            var mapper = mapperLocation.CreateMapper();
            return mapper.Map<LocationDto>(loc);
        }



    }
}
