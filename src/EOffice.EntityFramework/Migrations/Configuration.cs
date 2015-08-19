using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EOffice.EntityFramework;
using EOffice.Migrations.Data;

namespace EOffice.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EOffice.EntityFramework.EOfficeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EOffice";
        }

        protected override void Seed(EOffice.EntityFramework.EOfficeDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            new InitialDataBuilder().Build(context);
        }
    }
}
