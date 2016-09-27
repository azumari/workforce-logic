using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   public class InstructorDto
   {
      public int? InstructorID { get; set; }
      [StringLength(50), Required]
      public string FirstName { get; set; }
      [StringLength(50), Required]
      public string LastName { get; set; }
      public int? BatchID { get; set; }
   }
}
