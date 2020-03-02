namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDescriptionPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Description");
        }
    }
}
