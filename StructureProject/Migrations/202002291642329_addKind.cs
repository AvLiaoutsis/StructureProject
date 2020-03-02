namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKind : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Kind", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "Kind");
        }
    }
}
