using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workforce.Logic.Felice.Rest.Infrastructure
{
  /// <summary>
  /// This will have the properties
  /// that are required for a user
  /// </summary>
  public class ApplicationUser : IdentityUser
  {
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    public byte Level { get; set; }

    [Required]
    public DateTime JoinDate { get; set; }
  }
}