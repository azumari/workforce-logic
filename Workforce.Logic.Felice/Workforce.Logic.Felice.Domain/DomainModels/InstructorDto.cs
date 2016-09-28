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
      [StringLength(50), Required, RegularExpression("/^[A-Za-Z]+$/")]
      public string FirstName { get; set; }
      [StringLength(50), Required, RegularExpression("/^[A-Za-Z]+$/")]
      public string LastName { get; set; }
   }
}
