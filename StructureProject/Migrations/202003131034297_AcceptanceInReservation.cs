namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcceptanceInReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Accepted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Accepted");
        }
    }
}
