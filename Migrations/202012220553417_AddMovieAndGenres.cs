namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieAndGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Byte(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    NumberInStock = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
              "dbo.Genres",
              c => new
              {
                  Id = c.Byte(nullable: false, identity: true),
                  Name = c.String(),
              })
              .PrimaryKey(t => t.Id);

            AddColumn("dbo.Movies", "GenreId", c => c.Byte());
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");

        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
