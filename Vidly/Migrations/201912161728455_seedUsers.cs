namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8b74a4bb-3baf-443f-a5c4-4273af17b7dc', N'admin@vidly.com', 0, N'AI0WgI0kuTyYs6WwwrWtZVxq07paxxJshDNrPMIXU3i+C53nt8useBRc757mDLSM+w==', N'0de40b04-0325-47d7-9862-dd51b7b0471a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd6d8c9e3-317e-429b-ae7a-469feae16216', N'Guest@vidly.com', 0, N'AKLg8+R3WejbgRay0IOmgJPRMQH/XWLuLALOitVlrmdfQnBf7T4SQOPEjRrJKM4E0g==', N'f27b866d-813a-4765-9917-9b3286639c87', NULL, 0, 0, NULL, 1, 0, N'Guest@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a49b4049-ae0a-4aa5-af18-5622fbe05a6e', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b74a4bb-3baf-443f-a5c4-4273af17b7dc', N'a49b4049-ae0a-4aa5-af18-5622fbe05a6e')
           ");
        }

        
        
        public override void Down()
        {
        }
    }
}
