namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalDbSetCorrection : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NewRentals", newName: "Rentals");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Rentals", newName: "NewRentals");
        }
    }
}
