namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContextAccountController : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.People", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.People", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.People", "ApplicationUser_Id");
            AddForeignKey("dbo.People", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
