using System.Data.Entity.Migrations;

namespace EOffice.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EOffice.EntityFramework.EOfficeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EOffice";
        }

        protected override void Seed(EOffice.EntityFramework.EOfficeDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
