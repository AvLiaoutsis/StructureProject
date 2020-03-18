namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceKind : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceKinds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        KindId = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kinds", t => t.KindId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.KindId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceKinds", "PersonId", "dbo.People");
            DropForeignKey("dbo.PriceKinds", "KindId", "dbo.Kinds");
            DropIndex("dbo.PriceKinds", new[] { "KindId" });
            DropIndex("dbo.PriceKinds", new[] { "PersonId" });
            DropTable("dbo.PriceKinds");
        }
    }
}
