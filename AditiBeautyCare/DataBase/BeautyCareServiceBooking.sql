CREATE TABLE [dbo].[BeautyCareServiceBooking]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserEmail] [varchar](250) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[From] [varchar](50) NOT NULL,
	[To] [varchar](50) NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_BeautyCareServices_IsDeleted] DEFAULT ((0)) NOT NULL,
	[UserMobileNumber] [varchar](250) NOT NULL,
	[ServiceID] BIGINT NOT NULL,
	CONSTRAINT [PK_BeautyCareServiceBooking] PRIMARY KEY CLUSTERED ([Id] ASC)
);