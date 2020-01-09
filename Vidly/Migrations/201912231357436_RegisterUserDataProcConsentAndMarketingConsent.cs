namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterUserDataProcConsentAndMarketingConsent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PersonalDataProcessingConsent", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "MarketingConsent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MarketingConsent");
            DropColumn("dbo.AspNetUsers", "PersonalDataProcessingConsent");
        }
    }
}
