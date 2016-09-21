﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   public class AssociateDto //troubleshooting 'fail'
   {
      public int TraineeID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }  //set to string to hold Gender.Name
      public int BatchID { get; set; }
      public string PhoneNumber { get; set; }
      public string Email { get; set; }
      public DateTime? DateOfBirth { get; set; }
      public bool Car { get; set; }
      public bool HasKeys { get; set; }
      public bool? IsComing { get; set; }
      public bool Active { get; set; }
   }
}
