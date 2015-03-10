using Mangtas.WebApi.Models;

namespace Mangtas.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mangtas.WebApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mangtas.WebApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //context.Roles.AddOrUpdate(
            //    new ApplicationRole()
            //    {
            //        Name = "Admin"
            //    }
            // );
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
            //context.SaveChangesAsync();
        }
    }
}
