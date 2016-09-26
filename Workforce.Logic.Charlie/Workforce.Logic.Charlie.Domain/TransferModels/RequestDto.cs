using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Charlie.Domain.TransferModels
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public string AssociateFirst { get; set; }
        public string AssociateLast { get; set; }
        public string AssociateEmail { get; set; }
        public DateTime DepartureTime { get; set; }
        public int DepartureLoc { get; set; }
        public int DestinationLoc { get; set; }

    }
}
