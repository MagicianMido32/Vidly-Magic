namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingDatabaseUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'a4426d37-47bd-4bd2-99cf-417782cc0a71', N'admin@vidly.com', 0, N'AEL4XibxlZRlpUH+YDs3GdwlTYCR7BvuDnJnAPU6wlLxntmw8fk5dzenlr8YbYvXxw==', N'a7847b2d-9c3c-4c3e-8f10-0704a0554aa3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'222', N'232')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'a59816b2-40ce-416c-bc55-217c16b25667', N'guest@vidly.com', 0, N'ABL0bdwEpr9jn3/67ewEXRMXwztOCzKZ8yHjx0iCdLtijdt735ectbuibJ3oW+JZww==', N'4c644b2f-ea32-40ac-bf20-156a0b87b2ce', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com', N'323', N'2332')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3c92c8e0-ad81-49e5-9c31-09d6e16c600d', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dbf9825e-0b73-412c-a3af-ad034a188548', N'CanManageUsers')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4426d37-47bd-4bd2-99cf-417782cc0a71', N'3c92c8e0-ad81-49e5-9c31-09d6e16c600d')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a59816b2-40ce-416c-bc55-217c16b25667', N'3c92c8e0-ad81-49e5-9c31-09d6e16c600d')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4426d37-47bd-4bd2-99cf-417782cc0a71', N'dbf9825e-0b73-412c-a3af-ad034a188548')
            ");
        }

        public override void Down()
        {
            //delete the multi relation (user = role) before deleting the table or you will get a FK violation
            Sql(@"
DELETE  FROM AspNetUserRoles
DELETE  FROM AspNetUsers
DELETE  FROM AspNetRoles

");
        }
    }
}