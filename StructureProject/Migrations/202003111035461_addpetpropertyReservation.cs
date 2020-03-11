namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpetpropertyReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Pet_Id", c => c.Int());
            CreateIndex("dbo.Reservations", "Pet_Id");
            AddForeignKey("dbo.Reservations", "Pet_Id", "dbo.Pets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Pet_Id", "dbo.Pets");
            DropIndex("dbo.Reservations", new[] { "Pet_Id" });
            DropColumn("dbo.Reservations", "Pet_Id");
        }
    }
}
