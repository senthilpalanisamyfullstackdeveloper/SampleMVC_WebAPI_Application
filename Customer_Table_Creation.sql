USE [PWCustomer]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 12/08/2024 15:22:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 12/08/2024 15:22:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[Address] [varchar](100) NULL,
	[VehicleType] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[CountryName] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](30) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](30) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


