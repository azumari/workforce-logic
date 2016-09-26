namespace Workforce.Logic.Felice.Rest.Migrations
{
  using Microsoft.AspNet.Identity;
  using Microsoft.AspNet.Identity.EntityFramework;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;
  using Workforce.Logic.Felice.Rest.Infrastructure;

    internal sealed class Configuration : DbMigrationsConfiguration<Workforce.Logic.Felice.Rest.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Workforce.Logic.Felice.Rest.Infrastructure.ApplicationDbContext context)
        {
          //This method will be called after migrating to the latest version.
          var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
          var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

          var user = new ApplicationUser()
          {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            EmailConfirmed = true,
            FirstName = "Admin",
            LastName = "Admin",
            Level = 1,
            JoinDate = DateTime.Now.AddYears(-1)
          };

          manager.Create(user, "password");

          if(roleManager.Roles.Count() == 0)
          {
            roleManager.Create(new IdentityRole { Name = "Admin" });
            roleManager.Create(new IdentityRole { Name = "OnBoardingManager" });
            roleManager.Create(new IdentityRole { Name = "HousingManager" });
            roleManager.Create(new IdentityRole { Name = "Associate" });
          }

          var adminUser = manager.FindByName("admin@admin.com");
          manager.AddToRoles(adminUser.Id, new string[] { "Admin", "OnBoardingManager", "HousingManager" });
        }
    }
}
