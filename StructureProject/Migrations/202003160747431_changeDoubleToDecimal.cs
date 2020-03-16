namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDoubleToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostInfoes", "Price", c => c.Double(nullable: false));
        }
    }
}
