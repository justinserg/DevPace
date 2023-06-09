USE [DevPace]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/17/2023 4:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Name] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](320) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Alan Poe', N'Microsoft', N'2342423414', N'alan.poe@microsoft.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Alan Walker', N'Singer Industry', N'123121231231', N'alan.walker@singer.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Armin Burner', N'Self Employed', N'123123131312', N'armin@burner.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Hermiona Greinjer', N'Potter Inc.', N'243242342423', N'hermiona@potter.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'John Doe', N'Microsoft', N'123156546', N'john.doe@homail.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'John Snow', N'Apple', N'45646544846', N'john.snow@icloud.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'John Stark', N'Stark Inc.', N'123123123', N'sdfsdfsf@stark.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Kolon Simmons', N'Google', N'3423423242', N'k.simmons@google.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Ron Wisley', N'Potter Inc.', N'2342342342', N'wisley@potter.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Sam O''Konel', N'BestCompany', N'1231241412', N'okoned@bestcompany.com')
INSERT [dbo].[Customer] ([Name], [CompanyName], [Phone], [Email]) VALUES (N'Van Der Miller', N'SDFDSF', N'213321321', N'adfsf@test.com')
GO
/****** Object:  StoredProcedure [dbo].[SelectUser]    Script Date: 5/17/2023 4:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectUser] 
	@Company nvarchar(50) = '',
	@Name nvarchar(50) = '',
	@Phone nvarchar(50) = '',
	@Email nvarchar(320) = '',
	@orderby nvarchar(4) = 'ASC'
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Customer
	WHERE 
		CompanyName like '%' + @Company + '%' AND
		[Name] like '%' + @Name + '%' AND
		Phone like '%' + @Phone + '%' AND
		Email like '%' + @Email + '%'
	ORDER BY CASE WHEN @orderby = 'ASC' THEN [Name] END,
			 CASE WHEN @orderby = 'DESC' THEN [Name] END DESC


END
GO
