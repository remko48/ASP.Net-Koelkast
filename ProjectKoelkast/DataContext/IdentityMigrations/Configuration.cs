using System.Collections.Generic;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectKoelkast.Models;

namespace ProjectKoelkast.DataContext.IdentityMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"DataContext\IdentityMigrations";
        }

        protected override void Seed(IdentityDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roles = new List<IdentityRole>
            {
                new IdentityRole {Id = "1", Name = "Admin"},
                new IdentityRole {Id = "2", Name = "User"},
                new IdentityRole {Id = "3", Name = "Guest"}
            };
            roles.ForEach(r => context.Roles.AddOrUpdate(p => p.Id, r));
            context.SaveChanges();
            
            // Check if Admin exists and create default Admin
            if (!context.Users.Any(u => u.UserName == "Administrator"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var admin = new ApplicationUser
                {
                    UserName = "Administrator",
                    Email = "admin@admin.dev",
                    PhoneNumber = "1234567890",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = userManager.PasswordHasher.HashPassword("AdminTest1234!")
                };
                userManager.Create(admin);
                userManager.AddToRole(admin.Id, "Admin");
                context.SaveChanges();
            }
           
        }
    }
}
