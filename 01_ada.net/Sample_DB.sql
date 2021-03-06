CREATE DATABASE sample

USE [sample]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 25.03.2021 10:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 25.03.2021 10:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[SellerId] [int] NULL,
	[SaleSum] [money] NOT NULL,
	[SaleDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sellers]    Script Date: 25.03.2021 10:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sellers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName]) VALUES (1, N'Иван', N'Василиевич')
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName]) VALUES (2, N'Николай', N'Кузнецов')
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName]) VALUES (3, N'Василий', N'Леонтьев')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 
GO
INSERT [dbo].[Sale] ([Id], [CustomerId], [SellerId], [SaleSum], [SaleDate]) VALUES (1, 1, 2, 2000.0000, CAST(N'2021-03-25' AS Date))
GO
INSERT [dbo].[Sale] ([Id], [CustomerId], [SellerId], [SaleSum], [SaleDate]) VALUES (2, 2, 1, 50.0000, CAST(N'2020-09-12' AS Date))
GO
INSERT [dbo].[Sale] ([Id], [CustomerId], [SellerId], [SaleSum], [SaleDate]) VALUES (7, 3, 2, 1479.0000, CAST(N'2021-03-08' AS Date))
GO
INSERT [dbo].[Sale] ([Id], [CustomerId], [SellerId], [SaleSum], [SaleDate]) VALUES (8, 2, 3, 233.0000, CAST(N'2020-05-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO
SET IDENTITY_INSERT [dbo].[Sellers] ON 
GO
INSERT [dbo].[Sellers] ([Id], [FirstName], [LastName]) VALUES (1, N'Иван', N'Данко')
GO
INSERT [dbo].[Sellers] ([Id], [FirstName], [LastName]) VALUES (2, N'Борис', N'Бритва')
GO
INSERT [dbo].[Sellers] ([Id], [FirstName], [LastName]) VALUES (3, N'Кирил', N'Иванов')
GO
SET IDENTITY_INSERT [dbo].[Sellers] OFF
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([SellerId])
REFERENCES [dbo].[Sellers] ([Id])
GO

