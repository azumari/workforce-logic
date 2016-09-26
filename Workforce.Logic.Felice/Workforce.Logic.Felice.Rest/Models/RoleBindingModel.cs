using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workforce.Logic.Felice.Rest.Models
{
  /// <summary>
  /// The model for creating the roles
  /// </summary>
  public class CreateRoleBindingModel
  {
    [Required]
    [StringLength(256, ErrorMessage= "The {0} must be at least {2} characters long", MinimumLength = 2)]
    [Display(Name="Role Name")]
    public string Name { get; set; }

  }

  /// <summary>
  /// The model for seeing
  /// the users in a given role
  /// and the users who have been
  /// removed from those roles
  /// </summary>
  public class UsersInRoleModel
  {
    public string Id { get; set; }
    public List<string> ActiveUsers { get; set; }
    public List<string> RemovedUsers { get; set; }
  }
}