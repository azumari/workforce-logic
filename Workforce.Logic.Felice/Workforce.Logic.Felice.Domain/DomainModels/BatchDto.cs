using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   public class BatchDto
   {
      public int BatchID { get; set; }
      [StringLength(50), Required]
      public string Name { get; set; }
      public int InstructorID { get; set; }
      [Required]
      public DateTime StartDate { get; set; }
      [Required]
      public DateTime EndDate { get; set; }
   }
}