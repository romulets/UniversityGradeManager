
/****** Object:  Table [dbo].[Graduation]    Script Date: 06/11/2016 19:10:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Graduation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Graduation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Period]    Script Date: 06/11/2016 19:10:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Period](
	[Graduation_Id] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Period] PRIMARY KEY CLUSTERED 
(
	[Graduation_Id] ASC,
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Period]  WITH CHECK ADD  CONSTRAINT [FK_Period_Graduation] FOREIGN KEY([Graduation_Id])
REFERENCES [dbo].[Graduation] ([Id])
GO

ALTER TABLE [dbo].[Period] CHECK CONSTRAINT [FK_Period_Graduation]
GO

/****** Object:  Table [dbo].[Discipline]    Script Date: 06/11/2016 19:10:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Discipline](
	[Code] [varchar](50) NOT NULL,
	[Period_Graduation_Id] [int] NOT NULL,
	[Period_Number] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[TheorycClassesCount] [int] NOT NULL,
	[PractiseClassesCount] [int] NOT NULL,
	[NumberOfCredits] [int] NOT NULL,
	[Workload] [int] NOT NULL,
	[ClockHours] [int] NOT NULL,
 CONSTRAINT [PK_Discipline] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[Period_Graduation_Id] ASC,
	[Period_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Discipline]  WITH CHECK ADD  CONSTRAINT [FK_Discipline_Period] FOREIGN KEY([Period_Graduation_Id], [Period_Number])
REFERENCES [dbo].[Period] ([Graduation_Id], [Number])
GO

ALTER TABLE [dbo].[Discipline] CHECK CONSTRAINT [FK_Discipline_Period]
GO

