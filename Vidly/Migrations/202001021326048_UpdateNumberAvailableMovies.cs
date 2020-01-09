namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberAvailableMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Update movies set NumberAvailable=NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
