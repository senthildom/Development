USE [Sample]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Login]    Script Date: 24-03-2023 18:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_Login]
@Admin_id NVARCHAR(100),
@Password NVARCHAR(100),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid = (SELECT COUNT(1) FROM UserReg WHERE UserID = @Admin_id AND Password=@Password)
end




--CREATE TABLE [dbo].[tbl_login](
--       [Admin_id] [nvarchar](100) NULL,
--       [Ad_Password] [nvarchar](100) NULL
--)

--insert into tbl_login(Admin_id,Ad_Password) values('admin','admin123');
--insert into tbl_login(Admin_id,Ad_Password) values('Senthil','Senthil123');
GO
/****** Object:  Table [dbo].[tbl_Product]    Script Date: 24-03-2023 18:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](150) NULL,
	[ProductQuantity] [int] NULL,
	[ProductPrice] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserReg]    Script Date: 24-03-2023 18:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserReg](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](15) NULL,
	[Password] [nvarchar](100) NULL,
	[ConfirmPassword] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_Product] ON 

INSERT [dbo].[tbl_Product] ([ProductID], [ProductName], [ProductQuantity], [ProductPrice]) VALUES (11, N'product2', 80, CAST(400.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_Product] ([ProductID], [ProductName], [ProductQuantity], [ProductPrice]) VALUES (16, N'product5', 5, CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_Product] ([ProductID], [ProductName], [ProductQuantity], [ProductPrice]) VALUES (15, N'product6', 89, CAST(1000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[tbl_Product] OFF
SET IDENTITY_INSERT [dbo].[UserReg] ON 

INSERT [dbo].[UserReg] ([UserID], [FirstName], [LastName], [Email], [MobileNo], [Password], [ConfirmPassword]) VALUES (1, N'senthil', N's', N'senthil@gmail.com', N'9940917692', N'Senthil@1', N'Senthil@1')
INSERT [dbo].[UserReg] ([UserID], [FirstName], [LastName], [Email], [MobileNo], [Password], [ConfirmPassword]) VALUES (2, N'Admin', N'Admin', N'Admin@gmail.com', N'9940917692', N'Adminpass@2', N'Adminpass@2')
SET IDENTITY_INSERT [dbo].[UserReg] OFF
