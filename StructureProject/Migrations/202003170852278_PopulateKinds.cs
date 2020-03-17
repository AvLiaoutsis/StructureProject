namespace StructureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateKinds : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO KINDS (Id,Name) VALUES(1, 'Dog')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(2, 'Cat')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(3, 'Fish')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(4, 'Bird')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(5, 'Hamster')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(6, 'Snake')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(7, 'Spider')");
            Sql("INSERT INTO KINDS (Id,Name) VALUES(8, 'Wild Animal')");

        }

        public override void Down()
        {
            Sql("DELETE FROM KINDS WHERE Id IN (1,2,3,4,5,6,7,8)");

        }
    }
}
