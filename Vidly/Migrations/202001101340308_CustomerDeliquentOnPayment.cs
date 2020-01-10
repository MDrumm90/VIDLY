namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDeliquentOnPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DeliquentOnPayment", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DeliquentOnPayment");
        }
    }
}
