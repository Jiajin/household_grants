USE [govt_system]
GO
/****** Object:  Table [dbo].[Household]    Script Date: 15/2/2021 1:00:17 am ******/
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
