namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeKindAndPet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "KindId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Pets", "KindId");
            AddForeignKey("dbo.Pets", "KindId", "dbo.Kinds", "Id", cascadeDelete: true);
            DropColumn("dbo.Pets", "Kind");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Kind", c => c.String());
            DropForeignKey("dbo.Pets", "KindId", "dbo.Kinds");
            DropIndex("dbo.Pets", new[] { "KindId" });
            DropColumn("dbo.Pets", "KindId");
        }
    }
}
