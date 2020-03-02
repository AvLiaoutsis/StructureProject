namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpropertyPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IdentityUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "IdentityUserId");
        }
    }
}
