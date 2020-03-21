namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetAndHostNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserNotifications", "Host_Id", c => c.Int());
            AddColumn("dbo.UserNotifications", "Pet_Id", c => c.Int());
            CreateIndex("dbo.UserNotifications", "Host_Id");
            CreateIndex("dbo.UserNotifications", "Pet_Id");
            AddForeignKey("dbo.UserNotifications", "Host_Id", "dbo.People", "Id");
            AddForeignKey("dbo.UserNotifications", "Pet_Id", "dbo.Pets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "Pet_Id", "dbo.Pets");
            DropForeignKey("dbo.UserNotifications", "Host_Id", "dbo.People");
            DropIndex("dbo.UserNotifications", new[] { "Pet_Id" });
            DropIndex("dbo.UserNotifications", new[] { "Host_Id" });
            DropColumn("dbo.UserNotifications", "Pet_Id");
            DropColumn("dbo.UserNotifications", "Host_Id");
        }
    }
}
