USE [govt_system]
GO
/****** Object:  Table [dbo].[FamilyMember]    Script Date: 15/2/2021 1:00:17 am ******/
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
ALTER TABLE [dbo].[FamilyMember]  WITH CHECK ADD FOREIGN KEY([HouseholdId])
REFERENCES [dbo].[Household] ([HouseholdId])
GO
