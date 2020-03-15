namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToHost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostInfoes", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HostInfoes", "Price");
        }
    }
}
