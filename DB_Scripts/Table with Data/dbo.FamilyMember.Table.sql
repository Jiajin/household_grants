USE [govt_system]
GO
/****** Object:  Table [dbo].[FamilyMember]    Script Date: 15/2/2021 1:01:16 am ******/
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
ALTER TABLE [dbo].[FamilyMember]  WITH CHECK ADD FOREIGN KEY([HouseholdId])
REFERENCES [dbo].[Household] ([HouseholdId])
GO
