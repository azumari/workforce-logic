using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Charlie.Domain.TransferModels
{
    public class RideDto
    {
        public int RideId { get; set; }
        public string VolunteerFirst { get; set; }
        public string VolunteerLast { get; set; }
        public string VolunteerEmail { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DepartureLoc { get; set; }
        public string DestinationLoc { get; set; }
        public int SeatsAvailable { get; set; }

    }
}
