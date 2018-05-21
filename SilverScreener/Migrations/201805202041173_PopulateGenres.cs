namespace SilverScreener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreName) VALUES ('Action')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Drama')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Kids')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Horror')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Romance')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Sci-Fi')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Animated')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Documentary')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Suspense')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Indie')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Special Event')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Spy')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Music/Performing Arts')");
        }
        
        public override void Down()
        {
        }
    }
}
