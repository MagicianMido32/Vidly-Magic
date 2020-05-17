namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (23, N'Dolores Haze', 1, 2, N'1999-04-04 00:00:00', 0, 3)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (24, N'Trevor Philips ', 0, 1, N'1987-09-09 00:00:00', 0, 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (25, N'Michael Townly', 1, 4, N'1995-04-04 00:00:00', 0, 30)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (26, N'Michael De Santa', 0, 3, N'1879-02-02 00:00:00', 0, 4)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (27, N'Johnny Cash', 0, 1, N'2002-04-04 00:00:00', 0, 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (28, N'Luis dawkens', 0, 3, N'2000-04-04 00:00:00', 0, 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (29, N'Franklin Clinton', 0, 1, N'2007-04-04 00:00:00', 0, 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (30, N'Johnny Klipitz', 0, 2, N'1990-04-04 00:00:00', 0, 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (31, N'Tommy Vercitte', 1, 4, N'1855-04-04 00:00:00', 0, 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [Delinquent], [DiscountRate]) VALUES (32, N'Tony Montana', 0, 1, N'1864-07-05 00:00:00', 0, 0)
SET IDENTITY_INSERT [dbo].[Customers] OFF

SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1063, N'Mr Robot', N'2016-03-03 00:00:00', N'2020-05-15 19:22:04', 7, 1, 6, N'https://www.youtube.com/embed/xIBiJ_SzJTA')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1064, N'Ad Vitam', N'1995-04-04 00:00:00', N'2020-05-15 19:25:45', 6, 4, 6, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1065, N'Breaking Bad', N'2014-05-05 00:00:00', N'2020-05-15 19:26:30', 1, 1, 0, N'https://www.youtube.com/embed/HhesaQXLuRY')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1066, N'Attack on Titan', N'2009-04-04 00:00:00', N'2020-05-15 19:27:03', 5, 3, 5, N'https://www.youtube.com/embed/MGRm4IzK1SQ')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1067, N'Beauty and the beast', N'2006-06-06 00:00:00', N'2020-05-15 19:27:33', 4, 3, 2, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1068, N'Band of Brothers', N'2019-03-23 00:00:00', N'2020-05-15 19:28:25', 6, 1, 6, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1069, N'Black mirror', N'2009-04-09 00:00:00', N'2020-05-15 19:28:53', 17, 1, 17, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1070, N'BeyMan', N'1995-04-04 00:00:00', N'2020-05-15 19:33:28', 7, 2, 7, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1072, N'Game Of Thrones', N'2019-03-23 00:00:00', N'2020-05-15 19:49:24', 4, 1, 4, N'https://www.youtube.com/embed/gcTkNV5Vg1E')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1073, N'CHERNOBYL', N'2019-04-04 00:00:00', N'2020-05-15 19:50:05', 1, 2, 1, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1074, N'City Hill', N'2015-10-04 00:00:00', N'2020-05-15 19:50:51', 2, 5, 1, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1075, N'Devil in Dark', N'2019-03-23 00:00:00', N'2020-05-15 19:51:22', 2, 1, 2, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1076, N'Elite', N'2019-03-23 00:00:00', N'2020-05-15 19:51:59', 3, 2, 2, N'https://www.youtube.com/embed/QNwhAdrdwp0')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1077, N'For all Mankind', N'2009-04-04 00:00:00', N'2020-05-15 19:55:55', 4, 3, 3, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1078, N'Friends', N'1999-02-02 00:00:00', N'2020-05-15 19:56:28', 4, 5, 4, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1079, N'Lacasa De Papel', N'2019-11-23 00:00:00', N'2020-05-15 19:56:56', 4, 1, 3, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1080, N'NARCOS', N'2003-03-03 00:00:00', N'2020-05-15 19:58:04', 5, 1, 3, N'https://www.youtube.com/embed/AGv_F9hpQ-w')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1081, N'Originals', N'2015-03-23 00:00:00', N'2020-05-15 19:58:46', 5, 2, 5, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1082, N'Peaky Blinders', N'2015-03-23 00:00:00', N'2020-05-15 19:59:47', 4, 1, 4, N'https://www.youtube.com/embed/oVzVdvGIC7U')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1083, N'Prison Break', N'2009-04-04 00:00:00', N'2020-05-15 20:00:11', 3, 1, 1, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1084, N'See', N'2013-06-04 00:00:00', N'2020-05-15 20:01:00', 5, 1, 4, N'https://www.youtube.com/embed/7Rg0y7NT1gU')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1085, N'Sherlok', N'2003-03-03 00:00:00', N'2020-05-15 20:01:28', 5, 2, 5, NULL)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1086, N'Space Between Us', N'2018-07-02 00:00:00', N'2020-05-15 20:04:14', 9, 3, 9, N'https://www.youtube.com/embed/x73-573aWfs')
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable], [TrailerLink]) VALUES (1087, N'The end of the f**ing world', N'2019-03-23 00:00:00', N'2020-05-15 20:09:47', 9, 4, 9, N'https://www.youtube.com/embed/FruHLslczag')
SET IDENTITY_INSERT [dbo].[Movies] OFF

SET IDENTITY_INSERT [dbo].[Rentals] ON
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1032, N'2020-05-15 20:08:40', NULL, 31, 1067)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1033, N'2020-05-15 20:08:40', N'2020-05-15 20:10:55', 31, 1082)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1034, N'2020-05-15 20:08:41', NULL, 31, 1084)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1035, N'2020-05-15 20:09:59', N'2020-05-15 20:10:44', 23, 1087)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1036, N'2020-05-15 20:10:17', NULL, 28, 1063)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1037, N'2020-05-15 20:11:24', NULL, 24, 1065)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1038, N'2020-05-15 20:11:24', NULL, 24, 1067)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1039, N'2020-05-15 20:11:24', NULL, 24, 1083)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1040, N'2020-05-15 20:11:55', NULL, 25, 1074)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1041, N'2020-05-15 20:11:55', NULL, 25, 1076)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1042, N'2020-05-15 20:11:55', NULL, 25, 1077)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1043, N'2020-05-15 20:11:55', NULL, 25, 1080)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1044, N'2020-05-15 20:12:18', NULL, 30, 1079)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1045, N'2020-05-15 20:12:18', NULL, 30, 1080)
INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Movie_Id]) VALUES (1046, N'2020-05-15 20:12:18', NULL, 30, 1083)
SET IDENTITY_INSERT [dbo].[Rentals] OFF

");
        }

        public override void Down()
        {
            Sql(@"
DELETE  FROM Rentals
DELETE  FROM Customers
DELETE  FROM Movies

");
        }
    }
}