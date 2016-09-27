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
      public string Address1 { get; set; }
      public string Address2 { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public string Country { get; set; }
      public string Zipcode { get; set; }
      public bool Primary { get; set; }
   }
}
