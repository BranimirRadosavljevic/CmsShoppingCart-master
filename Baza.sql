USE [CmsShoppingCartDatabase]

CREATE TABLE [dbo].[tblCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Slug] [varchar](50) NULL,
	[Sorting] [int] NULL,
)
CREATE TABLE [dbo].[tblPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Slug] [varchar](50) NULL,
	[Body] [varchar](max) NULL,
	[Sorting] [int] NULL,
	[HasSidebar] [bit] NULL,
)

CREATE TABLE [dbo].[tblProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Slug] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[Price] [numeric](18, 2) NULL,
	[CategoryName] [varchar](50) NULL,
	[CategoryId] [int] NULL,
	[ImageName ] [varchar](100) NULL,
)
CREATE TABLE [dbo].[tblSidebar](
	[Id] [int] NOT NULL,
	[Body] [varchar](max) NULL,
)

