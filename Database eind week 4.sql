USE [BP3LampLichtknop]
GO
/****** Object:  Table [dbo].[Lamp]    Script Date: 18-3-2024 09:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lamp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AanUit] [bit] NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[Percentage] [int] NOT NULL,
	[LichtknopId] [int] NULL,
 CONSTRAINT [PK_Lamp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichtKnop]    Script Date: 18-3-2024 09:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichtKnop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AanUit] [bit] NOT NULL,
	[Beschrijving] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LichtKnop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Lamp] ON 

INSERT [dbo].[Lamp] ([Id], [AanUit], [Description], [Percentage], [LichtknopId]) VALUES (1, 0, N'Lamp 1', 100, 1)
INSERT [dbo].[Lamp] ([Id], [AanUit], [Description], [Percentage], [LichtknopId]) VALUES (2, 1, N'Lamp 2', 50, 1)
INSERT [dbo].[Lamp] ([Id], [AanUit], [Description], [Percentage], [LichtknopId]) VALUES (4, 1, N'sdfsdfsd', 100, 1)
SET IDENTITY_INSERT [dbo].[Lamp] OFF
GO
SET IDENTITY_INSERT [dbo].[LichtKnop] ON 

INSERT [dbo].[LichtKnop] ([Id], [AanUit], [Beschrijving]) VALUES (1, 0, N'Schakelaar bij deur')
INSERT [dbo].[LichtKnop] ([Id], [AanUit], [Beschrijving]) VALUES (3, 1, N'Schakelaar op toilet')
SET IDENTITY_INSERT [dbo].[LichtKnop] OFF
GO
ALTER TABLE [dbo].[Lamp]  WITH CHECK ADD  CONSTRAINT [FK_Lamp_LichtKnop] FOREIGN KEY([LichtknopId])
REFERENCES [dbo].[LichtKnop] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lamp] CHECK CONSTRAINT [FK_Lamp_LichtKnop]
GO
