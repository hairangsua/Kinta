USE [Kinta]
GO

/****** Object:  Table [dbo].[category]    Script Date: 11/7/2018 10:42:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[category](
	[id] [VARCHAR](50) NOT NULL,
	[code] [NVARCHAR](50) NOT NULL,
	[name] [NVARCHAR](150) NOT NULL,
	[description] [NVARCHAR](1028) NULL,
	[parent_code] [NVARCHAR](50) NULL,
	[child_code] [NVARCHAR](50) NULL,
	[path] [NVARCHAR](150) NULL,
	[tag] [NVARCHAR](150) NULL,
	[created_time] [DATETIME] NOT NULL,
	[updated_time] [DATETIME] NOT NULL
) ON [PRIMARY]

GO


