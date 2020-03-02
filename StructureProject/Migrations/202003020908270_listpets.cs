namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listpets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Pet_Id", "dbo.Pets");
            DropIndex("dbo.People", new[] { "Pet_Id" });
            AddColumn("dbo.Pets", "Person_Id", c => c.Int());
            CreateIndex("dbo.Pets", "Person_Id");
            AddForeignKey("dbo.Pets", "Person_Id", "dbo.People", "Id");
            DropColumn("dbo.People", "Pet_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Pet_Id", c => c.Int());
            DropForeignKey("dbo.Pets", "Person_Id", "dbo.People");
            DropIndex("dbo.Pets", new[] { "Person_Id" });
            DropColumn("dbo.Pets", "Person_Id");
            CreateIndex("dbo.People", "Pet_Id");
            AddForeignKey("dbo.People", "Pet_Id", "dbo.Pets", "Id");
        }
    }
}
