namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Host_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Customer_Id)
                .ForeignKey("dbo.People", t => t.Host_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Host_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Host_Id", "dbo.People");
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.People");
            DropIndex("dbo.Reservations", new[] { "Host_Id" });
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropTable("dbo.Reservations");
        }
    }
}
