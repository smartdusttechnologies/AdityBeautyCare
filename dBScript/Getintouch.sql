

CREATE TABLE [dbo].[GetInTouch]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Subject] [varchar](250) NOT NULL,
	[Message] [varchar](500) NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_DailySale_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_New] PRIMARY KEY CLUSTERED ([Id] ASC)
);