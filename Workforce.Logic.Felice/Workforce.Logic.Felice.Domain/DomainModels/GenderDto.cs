using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   public class GenderDto
   {
      public int GenderID { get; set; }
      [Required, RegularExpression("/^[A-Za-Z]+$/")]
      public string Name { get; set; }
   }
}
