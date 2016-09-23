using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce.Logic.Felice.Rest.Infrastructure
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    /// <summary>
    /// Will point to our connection
    /// string in our WebConfig
    /// </summary>
    public ApplicationDbContext()
      : base("DefaultConnection", throwIfV1Schema : false)
    {
      Configuration.ProxyCreationEnabled = false;
      Configuration.LazyLoadingEnabled = false;
    }

    /// <summary>
    /// This will be called from
    /// our Owin Startup Class
    /// </summary>
    /// <returns></returns>
    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}