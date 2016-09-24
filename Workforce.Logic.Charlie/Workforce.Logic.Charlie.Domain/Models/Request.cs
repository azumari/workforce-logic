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
        /// map a ride Dto to a Dao
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public RequestDao MapToSoap(RequestDto req)
        {
            var mapper = mapperReq2.CreateMapper();
            return mapper.Map<RequestDao>(req);
        }

        /// <summary>
        /// map a ride Dao to a Dto
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public RequestDto MapToRest(RequestDao req)
        {
            var mapper = mapperReq.CreateMapper();
            return mapper.Map<RequestDto>(req);
        }


    }
}
