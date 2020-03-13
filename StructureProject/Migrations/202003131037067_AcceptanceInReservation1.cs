namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcceptanceInReservation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Accept", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Accepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Accepted", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Accept");
        }
    }
}
