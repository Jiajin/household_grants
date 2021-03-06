USE [govt_system]
GO
/****** Object:  Table [dbo].[Household]    Script Date: 15/2/2021 1:01:16 am ******/
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
SET IDENTITY_INSERT [dbo].[Household] ON 

INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (1, N'Condominium')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (2, N'Landed')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (3, N'HDB')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (4, N'Landed')
INSERT [dbo].[Household] ([HouseholdId], [HousingType]) VALUES (5, N'HDB')
SET IDENTITY_INSERT [dbo].[Household] OFF
GO
