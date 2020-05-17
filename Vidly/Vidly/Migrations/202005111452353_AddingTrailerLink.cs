namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTrailerLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "TrailerLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "TrailerLink");
        }
    }
}
