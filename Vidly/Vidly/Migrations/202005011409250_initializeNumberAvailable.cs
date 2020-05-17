namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initializeNumberAvailable : DbMigration
    {
        public override void Up()
        {
            //Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }

        public override void Down()
        {
            Sql("UPDATE Movies SET NumberAvailable = 0");
        }
    }
}