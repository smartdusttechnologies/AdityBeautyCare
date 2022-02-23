CREATE TABLE [dbo].[BeautyCareServiceBooking]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserEmail] [varchar](250),
	[Date] [datetime] NOT NULL,
	[From] [varchar](50) NOT NULL,
	[To] [varchar](50) NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_BeautyCareServiceBooking_IsDeleted] DEFAULT ((0)) NOT NULL,
	[UserMobileNumber] [varchar](250) NOT NULL,
	[ServiceId] BIGINT NOT NULL,
	[Description][varchar](1000) NOT NULL,
	CONSTRAINT [PK_BeautyCareServiceBooking] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_BeautyCareServiceBooking_BeautyCareServices] FOREIGN KEY (ServiceId) REFERENCES [dbo].[BeautyCareServices] ([Id])
);