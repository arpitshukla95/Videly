namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES(Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES(Name) VALUES ('Action')");
            Sql("INSERT INTO GENRES(Name) VALUES ('Family')");
            Sql("INSERT INTO GENRES(Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
