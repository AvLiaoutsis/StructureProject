namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatarPet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "Avatar");
        }
    }
}
