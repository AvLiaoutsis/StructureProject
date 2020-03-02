namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepropAgePet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "Age", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Age", c => c.Int(nullable: false));
        }
    }
}
