USE [vladDB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 30.05.2022 4:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[VillageId] [int] NULL,
	[UserId] [int] NOT NULL,
	[Street] [nvarchar](100) NOT NULL,
	[House] [nvarchar](10) NOT NULL,
	[Entrance] [nvarchar](50) NULL,
	[Apartment] [nvarchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 30.05.2022 4:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30.05.2022 4:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Number] [nchar](12) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Village]    Script Date: 30.05.2022 4:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Village](
	[VillageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_Village] PRIMARY KEY CLUSTERED 
(
	[VillageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (1, 2, 1, 2, N'ул. Орджоникидзе', N'4д', NULL, NULL)
INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (2, 2, NULL, 1, N'ул. Овражная', N'23', N'2', N'6')
INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (4, 4, 10, 4, N'Какая-то', N'123', N'', N'')
INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (5, 4, 9, 5, N'Ленина', N'147', N'1', N'49')
INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (7, 3, 5, 7, N'нргрг', N'34', N'', N'')
INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (8, 2, 2, 8, N'какая-то', N'34', N'', N'')
INSERT [dbo].[Address] ([AddressId], [DistrictId], [VillageId], [UserId], [Street], [House], [Entrance], [Apartment]) VALUES (9, 3, 3, 9, N'sdag', N'12', N'', N'')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([DistrictId], [Name]) VALUES (1, N'Кострома')
INSERT [dbo].[District] ([DistrictId], [Name]) VALUES (2, N'Нея')
INSERT [dbo].[District] ([DistrictId], [Name]) VALUES (3, N'Судиславль')
INSERT [dbo].[District] ([DistrictId], [Name]) VALUES (4, N'Кадый')
INSERT [dbo].[District] ([DistrictId], [Name]) VALUES (5, N'Макарьев')
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (1, N'Тёщин', N'Владислав', NULL, N'88005546460 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (2, N'Лебедев', N'Дмитрий', NULL, N'89006667878 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (3, N'Стренишевский', N'Кирилл', N'Юрьевич', N'89107873685 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (4, N'Шевцов', N'Валерий', N'', N'88005554763 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (5, N'Тещин', N'Влад', N'', N'89006667575 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (6, N'алаплал', N'алалалал', N'', N'рполаал     ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (7, N'Тещин', N'Вад', N'', N'89006667575 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (8, N'Чеееел', N'просто', N'', N'78006667575 ')
INSERT [dbo].[User] ([UserId], [Surname], [Name], [Patronymic], [Number]) VALUES (9, N'Xtttk', N'sdfgs', N'', N'8800767676  ')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Village] ON 

INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (1, N'Номжа', 2)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (2, N'Еленский', 2)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (3, N'Ванеево', 2)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (4, N'Глебово', 3)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (5, N'Фадеево', 3)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (6, N'Яснево', 3)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (7, N'Грудки', 3)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (8, N'Селище', 4)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (9, N'Дубки', 4)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (10, N'Паньково', 4)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (11, N'Ильинское', 5)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (12, N'Заречье', 5)
INSERT [dbo].[Village] ([VillageId], [Name], [DistrictId]) VALUES (13, N'Юркино', 5)
SET IDENTITY_INSERT [dbo].[Village] OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_District]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_User]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Village] FOREIGN KEY([VillageId])
REFERENCES [dbo].[Village] ([VillageId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Village]
GO
ALTER TABLE [dbo].[Village]  WITH CHECK ADD  CONSTRAINT [FK_Village_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
ALTER TABLE [dbo].[Village] CHECK CONSTRAINT [FK_Village_District]
GO
