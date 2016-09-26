using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce.Logic.Felice.Rest.Infrastructure
{
  public class ApplicationRoleManager : RoleManager<IdentityRole>
  {
    public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
      : base(roleStore)
    {

    }


    /// <summary>
    /// Will use Owin to create instances for each request
    /// where Identity data is accessed. This will ultimately help
    /// us hide the details of how role data is stored throught our application
    /// </summary>
    /// <param name="options"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
    {
      var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
      return appRoleManager;
    }
  }
}