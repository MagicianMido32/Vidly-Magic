namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddingDelinquentToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Delinquent", c => c.Boolean(nullable: false));
            // Sql("UPDATE Customers SET Delinquent='FAlSE'");
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Delinquent");
        }
    }
}