using HentovWebsite.Models.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HentovWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HentovWebsite.Data.HentovWebsiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HentovWebsite.Data.HentovWebsiteContext";
        }

        protected override void Seed(HentovWebsite.Data.HentovWebsiteContext context)
        {
            CreateRole(context, UserRoles.Admin);
            CreateRole(context, UserRoles.Moderator);
            CreateRole(context, UserRoles.WebsiteUser);
        }

        private static void CreateRole(HentovWebsiteContext context, UserRoles role)
        {
            if (!context.Roles.Any(r => r.Name == role.ToString()))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                manager.Create(new IdentityRole(role.ToString()));
            }
        }
    }
}
