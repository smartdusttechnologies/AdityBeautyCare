CREATE TABLE [dbo].[BeautyCareServices]
(
	[ServiceId] BIGINT IDENTITY (1, 1) NOT NULL,
	[ServiceName] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[ServiceDuration] [varchar](250) NOT NULL,
	[ServicePrice] [varchar](250) NOT NULL,
	[ImageUrl] [varchar](250) NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_BeautyCareServices_IsDeleted] DEFAULT ((0)) NOT NULL,

	CONSTRAINT [PK_New] PRIMARY KEY CLUSTERED ([ServiceId] ASC)
);