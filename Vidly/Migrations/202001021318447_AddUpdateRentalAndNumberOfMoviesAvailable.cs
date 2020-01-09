namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateRentalAndNumberOfMoviesAvailable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Rentals", "ReturningDate", c => c.DateTime());
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AlterColumn("dbo.Rentals", "Movie_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "ReturningDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
            CreateIndex("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
