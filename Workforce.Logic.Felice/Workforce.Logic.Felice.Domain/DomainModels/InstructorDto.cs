using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   class InstructorDto
   {
      public int InstructorID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int BatchID { get; set; }
      public bool Active { get; set; }
   }
}
