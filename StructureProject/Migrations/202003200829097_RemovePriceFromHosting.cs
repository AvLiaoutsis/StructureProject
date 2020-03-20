namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePriceFromHosting : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HostInfoes", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HostInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
