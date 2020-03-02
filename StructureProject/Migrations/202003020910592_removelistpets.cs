namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removelistpets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "Person_Id", "dbo.People");
            DropIndex("dbo.Pets", new[] { "Person_Id" });
            AddColumn("dbo.People", "Pet_Id", c => c.Int());
            CreateIndex("dbo.People", "Pet_Id");
            AddForeignKey("dbo.People", "Pet_Id", "dbo.Pets", "Id");
            DropColumn("dbo.Pets", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Person_Id", c => c.Int());
            DropForeignKey("dbo.People", "Pet_Id", "dbo.Pets");
            DropIndex("dbo.People", new[] { "Pet_Id" });
            DropColumn("dbo.People", "Pet_Id");
            CreateIndex("dbo.Pets", "Person_Id");
            AddForeignKey("dbo.Pets", "Person_Id", "dbo.People", "Id");
        }
    }
}
