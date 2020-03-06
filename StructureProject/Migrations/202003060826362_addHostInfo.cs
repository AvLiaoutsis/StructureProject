namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHostInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostInfoes", "Person_Id", "dbo.People");
            DropIndex("dbo.HostInfoes", new[] { "Person_Id" });
            DropTable("dbo.HostInfoes");
        }
    }
}
