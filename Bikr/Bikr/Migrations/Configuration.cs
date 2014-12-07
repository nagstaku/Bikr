namespace Bikr.Migrations
{
    using Bikr.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bikr.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Bikr.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string username = "admin";
            string password = "1234";
            string role = "administrator";

            // Create Role Test and User Test
            RoleManager.Create(new IdentityRole(role));
            UserManager.Create(new ApplicationUser() { UserName = username });

            // Create Admin Role if it does not exist
            if (!RoleManager.RoleExists(role))
            {
                var roleresult = RoleManager.Create(new IdentityRole(role));
            }

            // Create User
            var applicationUser = new ApplicationUser();
            applicationUser.UserName = username;
            var adminresult = UserManager.Create(applicationUser, password);

            // Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(applicationUser.Id, role);
            }
            base.Seed(context);

 
            Ping ping = new Ping();
            ping.BikeFindrID = "78:4b:87:ab:92:ed";
            ping.PingDateTime = DateTime.Now;
            ping.PingY = Convert.ToDecimal(45.65);
            ping.PingX = Convert.ToDecimal(-122.45);
            ping.PingID = "124c110e-8e65-49c3-b764-1ca97984c836";
            context.Pings.AddOrUpdate(
            p => p.PingID, ping);       
        }
    }
}
