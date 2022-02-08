CREATE TABLE [dbo].[BeautyCareServices]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[SDuration] [varchar](250) NOT NULL,
	[Price] [varchar](250) NOT NULL,
	[ImageUrl] [varchar](250) NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_BeautyCareServices_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_New] PRIMARY KEY CLUSTERED ([Id] ASC)
);