namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        TelNumber = c.String(),
                        Address = c.String(),
                        PostalCode = c.Int(),
                        State = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfoes", "Person_Id", "dbo.People");
            DropIndex("dbo.ContactInfoes", new[] { "Person_Id" });
            DropTable("dbo.ContactInfoes");
        }
    }
}
