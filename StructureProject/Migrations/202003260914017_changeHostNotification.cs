namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeHostNotification : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.HostNotifications", "NotificationId");
            AddForeignKey("dbo.HostNotifications", "NotificationId", "dbo.Notifications", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostNotifications", "NotificationId", "dbo.Notifications");
            DropIndex("dbo.HostNotifications", new[] { "NotificationId" });
        }
    }
}
