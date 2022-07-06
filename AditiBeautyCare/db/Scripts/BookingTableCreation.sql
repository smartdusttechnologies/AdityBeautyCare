

CREATE TABLE [dbo].[BeautyCareServiceBooking](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserEmail] [varchar](250) NULL,
	[Date] [datetime] NOT NULL,
	[From] [varchar](50) NOT NULL,
	[To] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UserMobileNumber] [varchar](250) NOT NULL,
	[ServiceId] [bigint] NOT NULL,
	[Description] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_BeautyCareServiceBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BeautyCareServiceBooking] ADD  CONSTRAINT [D_BeautyCareServiceBooking_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


