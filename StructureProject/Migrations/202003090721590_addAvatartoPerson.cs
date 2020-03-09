namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvatartoPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Avatar");
        }
    }
}
