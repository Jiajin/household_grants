USE [master]
GO
/****** Object:  Database [govt_system]    Script Date: 15/2/2021 12:56:14 am ******/
CREATE DATABASE [govt_system]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'govt_system', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\govt_system.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'govt_system_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\govt_system_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [govt_system] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [govt_system].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [govt_system] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [govt_system] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [govt_system] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [govt_system] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [govt_system] SET ARITHABORT OFF 
GO
ALTER DATABASE [govt_system] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [govt_system] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [govt_system] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [govt_system] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [govt_system] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [govt_system] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [govt_system] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [govt_system] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [govt_system] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [govt_system] SET  DISABLE_BROKER 
GO
ALTER DATABASE [govt_system] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [govt_system] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [govt_system] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [govt_system] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [govt_system] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [govt_system] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [govt_system] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [govt_system] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [govt_system] SET  MULTI_USER 
GO
ALTER DATABASE [govt_system] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [govt_system] SET DB_CHAINING OFF 
GO
ALTER DATABASE [govt_system] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [govt_system] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [govt_system] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [govt_system] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [govt_system] SET QUERY_STORE = OFF
GO
USE [govt_system]
GO
/****** Object:  Table [dbo].[FamilyMember]    Script Date: 15/2/2021 12:56:14 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyMember](
	[FamilyMemberId] [int] IDENTITY(1,1) NOT NULL,
	[HouseholdId] [int] NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[MaritalStatus] [nvarchar](50) NOT NULL,
	[SpouseName] [nvarchar](250) NULL,
	[OccupationType] [nvarchar](50) NOT NULL,
	[AnnualIncome] [decimal](11, 2) NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_FamilyMember] PRIMARY KEY CLUSTERED 
(
	[FamilyMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Household]    Script Date: 15/2/2021 12:56:14 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Household](
	[HouseholdId] [int] IDENTITY(1,1) NOT NULL,
	[HousingType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Household] PRIMARY KEY CLUSTERED 
(
	[HouseholdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FamilyMember] ON 

INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (1, 1, N'SEB1', N'M', N'Married', N'SEB2', N'Employed', CAST(130000.00 AS Decimal(11, 2)), CAST(N'1991-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (2, 1, N'SEB Kid', N'M', N'Single', NULL, N'Student', CAST(0.00 AS Decimal(11, 2)), CAST(N'2006-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (3, 2, N'FTS1', N'F', N'Married', N'FTS2', N'Employed', CAST(100000.00 AS Decimal(11, 2)), CAST(N'1990-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (5, 2, N'FTS2', N'M', N'Married', N'FTS1', N'Employed', CAST(20000.00 AS Decimal(11, 2)), CAST(N'1990-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (6, 3, N'EB', N'F', N'Single', NULL, N'Employed', CAST(10000.00 AS Decimal(11, 2)), CAST(N'1955-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (7, 4, N'BSG', N'F', N'Single', NULL, N'Student', NULL, CAST(N'2018-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (8, 4, N'BSG  and SEB', N'M', N'Married', N'SEB2', N'Employed', CAST(80000.00 AS Decimal(11, 2)), CAST(N'1991-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (9, 4, N'BSG n SEB', N'M', N'Single', NULL, N'Student', CAST(0.00 AS Decimal(11, 2)), CAST(N'2006-03-19T16:00:00.000' AS DateTime))
INSERT [dbo].[FamilyMember] ([FamilyMemberId], [HouseholdId], [Name], [Gender], [MaritalStatus], [SpouseName], [OccupationType], [AnnualIncome], [DateOfBirth]) VALUES (11, 2, N'FTS kid', N'M', N'Single', NULL, N'Student', NULL, CAST(N'2010-03-19T16:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FamilyMember] OFF
GO
SET IDENTITY_INSERT [dbo].[Household] ON 

INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (1, N'Condominium')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (2, N'Landed')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (3, N'HDB')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (4, N'Landed')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (5, N'HDB')
SET IDENTITY_INSERT [dbo].[Household] OFF
GO
ALTER TABLE [dbo].[FamilyMember]  WITH CHECK ADD FOREIGN KEY([HouseholdId])
REFERENCES [dbo].[Household] ([HouseholdId])
GO
USE [master]
GO
ALTER DATABASE [govt_system] SET  READ_WRITE 
GO
