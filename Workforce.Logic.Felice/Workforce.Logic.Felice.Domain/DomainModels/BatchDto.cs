using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   class BatchDto
   {
      public int BatchID { get; set; }
      public string Name { get; set; }
      public int InstructorID { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
      public bool Active { get; set; }
   }
}
