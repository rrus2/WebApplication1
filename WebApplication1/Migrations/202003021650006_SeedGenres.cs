namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Weapon')");
            Sql("INSERT INTO Genres (Name) VALUES ('Car')");
            Sql("INSERT INTO Genres (Name) VALUES ('Book')");
            Sql("INSERT INTO Genres (Name) VALUES ('Other')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres");
        }
    }
}
