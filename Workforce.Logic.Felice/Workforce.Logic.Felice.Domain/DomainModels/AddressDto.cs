using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   public class AddressDto
   {
      public int? AddressID { get; set; }
      [RegularExpression("/^[A-Za-Z0-9]+$/")]
      public string Address1 { get; set; }
      [RegularExpression("/^[A-Za-Z0-9]+$/")]
      public string Address2 { get; set; }
      [RegularExpression("/^[A-Za-Z]+$/")]
      public string City { get; set; }
      [RegularExpression("/^[A-Za-Z]+$/")]
      public string State { get; set; }
      [RegularExpression("/^[A-Za-Z]+$/")]
      public string Country { get; set; }
      [RegularExpression("/^[0-9]+$/")]
      public string Zipcode { get; set; }
      public bool Primary { get; set; }
   }
}
