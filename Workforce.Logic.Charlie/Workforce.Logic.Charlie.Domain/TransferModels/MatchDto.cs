using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Charlie.Domain.TransferModels
{
    public class MatchDto
    {
        public int RideId { get; set; }
        public int ReqId { get; set; }
        public int DeptLoc { get; set; }
        public int DestLoc { get; set; }
        public DateTime DeptTime { get; set; }
        public int Seats { get; set; }
        public string RideEmail { get; set; }
        public string ReqEmail { get; set; }
    }
}
