USE [Kinta]
GO

/****** Object:  Table [dbo].[post_item]    Script Date: 11/7/2018 10:45:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[post_item](
	[id] [VARCHAR](50) NOT NULL,
	[title] [NVARCHAR](MAX) NOT NULL,
	[post_content] [NVARCHAR](MAX) NULL,
	[ref_links] [NVARCHAR](MAX) NULL,
	[images] [NVARCHAR](MAX) NULL,
	[category] [NVARCHAR](50) NULL,
	[url] [NVARCHAR](150) NULL,
	[tag] [NVARCHAR](150) NULL,
	[created_time] [DATETIME] NOT NULL,
	[updated_time] [DATETIME] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


