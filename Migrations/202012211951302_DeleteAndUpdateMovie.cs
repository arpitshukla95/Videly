namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAndUpdateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE Movies");
        }
        
        public override void Down()
        {
        }
    }
}
