namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHostNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostNotifications",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        Host_Id = c.Int(),
                        Pet_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.People", t => t.Host_Id)
                .ForeignKey("dbo.Pets", t => t.Pet_Id)
                .ForeignKey("dbo.People", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Host_Id)
                .Index(t => t.Pet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostNotifications", "UserId", "dbo.People");
            DropForeignKey("dbo.HostNotifications", "Pet_Id", "dbo.Pets");
            DropForeignKey("dbo.HostNotifications", "Host_Id", "dbo.People");
            DropIndex("dbo.HostNotifications", new[] { "Pet_Id" });
            DropIndex("dbo.HostNotifications", new[] { "Host_Id" });
            DropIndex("dbo.HostNotifications", new[] { "UserId" });
            DropTable("dbo.HostNotifications");
        }
    }
}
