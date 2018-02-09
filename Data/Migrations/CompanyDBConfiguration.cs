namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class CompanyDBConfiguration : DbMigrationsConfiguration<Data.CompanyDBContext>
    {
        public CompanyDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.CompanyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
