using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using Workforce.Logic.Felice.Rest.Infrastructure;

namespace Workforce.Logic.Felice.Rest.Models
{

  /// <summary>
  /// This class will contain all the functions
  /// that are needed to shape the response object.
  /// 
  /// This will help us to not leak any sensitive
  /// information over to the client such as the password hash
  /// </summary>
  public class ModelFactory
  {
    private UrlHelper urlHelper;
    private ApplicationUserManager AppUserManager;

    public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
    {
      urlHelper = new UrlHelper(request);
      AppUserManager = appUserManager;
    }

    public UserReturnModel Create(ApplicationUser appUser)
    {
      //Will return the properties needed 
      //for the object graph from the
      //class below this method
      return new UserReturnModel
        {
          Url = urlHelper.Link("GetUserById", new { id = appUser.Id }),
          Id = appUser.Id,
          UserName = appUser.UserName,
          FirstName = appUser.FirstName,
          LastName = appUser.LastName,
          FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
          Email = appUser.Email,                
          EmailConfirmed = appUser.EmailConfirmed,
          Level = appUser.Level,
          JoinDate = appUser.JoinDate,
          Roles = AppUserManager.GetRolesAsync(appUser.Id).Result,
          Claims = AppUserManager.GetClaimsAsync(appUser.Id).Result
        };
    }

    /// <summary>
    /// properties that we can/will use
    /// to help create the users and displaye
    /// information. Password Hash is not
    /// shown because it is not needed
    /// and because we don't want to leak that
    /// information over to the client by mistake
    /// </summary>
    public class UserReturnModel
    {
      public string Url { get; set; }
      public string Id { get; set; }
      public string UserName { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string FullName { get; set; }
      public string Email { get; set; }
      public bool EmailConfirmed { get; set; }
      public int Level { get; set; }
      public DateTime JoinDate { get; set; }
      public IList<string> Roles { get; set; }
      public IList<System.Security.Claims.Claim> Claims { get; set; }
    }

    //Will return the properties needed 
    //for the object graph from the
    //class below this method    
    public RoleReturnModel Create(IdentityRole appRole) 
    {
      return new RoleReturnModel
      {
        Url = urlHelper.Link("GetRoleById", new { id = appRole.Id }),
        Id = appRole.Id,
        Name = appRole.Name
      };
    }
  }


  /// <summary>
  /// Properties that we will use to help create
  /// the roles and displayed information for them
  /// </summary>
  public class RoleReturnModel
  {
    public string Url { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
  }
}
