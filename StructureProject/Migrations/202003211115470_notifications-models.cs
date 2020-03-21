namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificationsmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        PetName = c.String(),
                        Reservation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id, cascadeDelete: true)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.People");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "Reservation_Id" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}
