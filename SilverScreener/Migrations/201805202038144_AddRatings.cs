namespace SilverScreener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatings : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ratings (RatingName, RatingDescription) VALUES ('G', 'General Audiences')");
            Sql("INSERT INTO Ratings (RatingName, RatingDescription) VALUES ('PG', 'Parental Guidance Suggested')");
            Sql("INSERT INTO Ratings (RatingName, RatingDescription) VALUES ('PG-13', 'Parents Strongly Cautioned')");
            Sql("INSERT INTO Ratings (RatingName, RatingDescription) VALUES ('R', 'Restricted')");
            Sql("INSERT INTO Ratings (RatingName, RatingDescription) VALUES ('NC-17', 'Adults Only')");
            Sql("INSERT INTO Ratings (RatingName, RatingDescription) VALUES ('NR', 'Not Rated')");
        }
        
        public override void Down()
        {
        }
    }
}
