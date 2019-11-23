USE [master]
GO
/****** Object:  Database [TicketManagement]    Script Date: 5/30/2018 1:49:21 PM ******/
CREATE DATABASE [TicketManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TicketManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TicketManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TicketManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TicketManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TicketManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TicketManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TicketManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TicketManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TicketManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TicketManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TicketManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [TicketManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TicketManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TicketManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TicketManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TicketManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TicketManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TicketManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TicketManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TicketManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TicketManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TicketManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TicketManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TicketManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TicketManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TicketManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TicketManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TicketManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TicketManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [TicketManagement] SET  MULTI_USER 
GO
ALTER DATABASE [TicketManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TicketManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TicketManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TicketManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TicketManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TicketManagement', N'ON'
GO
ALTER DATABASE [TicketManagement] SET QUERY_STORE = OFF
GO
USE [TicketManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TicketManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/30/2018 1:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Email] [nchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/30/2018 1:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Date] [date] NOT NULL,
	[Seat] [int] NOT NULL,
	[BookingNumber] [varchar](8) NOT NULL,
	[StatusTicket] [nvarchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 5/30/2018 1:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 5/30/2018 1:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 5/30/2018 1:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[TimeStart] [smallint] NOT NULL,
	[TimeEnd] [smallint] NOT NULL,
	[OriginID] [int] NOT NULL,
	[DestinationID] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[EmptySeat] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 5/30/2018 1:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CityID] [int] NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password], [Firstname], [Lastname], [Email], [Status]) VALUES (1, N'1', N'1', N'mien', N'nguyen', N'hongmienft98@gmail.com                            ', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([ID], [Name], [CountryID]) VALUES (1, N'Danang', 1)
INSERT [dbo].[City] ([ID], [Name], [CountryID]) VALUES (2, N'Hanoi', 1)
INSERT [dbo].[City] ([ID], [Name], [CountryID]) VALUES (3, N'HCM City', 1)
INSERT [dbo].[City] ([ID], [Name], [CountryID]) VALUES (4, N'Tokyo', 2)
INSERT [dbo].[City] ([ID], [Name], [CountryID]) VALUES (5, N'Seoul', 3)
INSERT [dbo].[City] ([ID], [Name], [CountryID]) VALUES (6, N'Vinh', 1)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([ID], [Name]) VALUES (1, N'Vietnam')
INSERT [dbo].[Country] ([ID], [Name]) VALUES (2, N'Japan')
INSERT [dbo].[Country] ([ID], [Name]) VALUES (3, N'Korea')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([ID], [CityID], [Symbol], [Status]) VALUES (2, 1, N'DAN', 1)
INSERT [dbo].[Location] ([ID], [CityID], [Symbol], [Status]) VALUES (3, 2, N'HAN', 1)
INSERT [dbo].[Location] ([ID], [CityID], [Symbol], [Status]) VALUES (4, 3, N'HCM', 1)
INSERT [dbo].[Location] ([ID], [CityID], [Symbol], [Status]) VALUES (6, 4, N'TOK', 1)
INSERT [dbo].[Location] ([ID], [CityID], [Symbol], [Status]) VALUES (7, 5, N'SEO', 1)
SET IDENTITY_INSERT [dbo].[Location] OFF
/****** Object:  Index [IX_Account]    Script Date: 5/30/2018 1:49:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Account] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Account]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_City]
GO
USE [master]
GO
ALTER DATABASE [TicketManagement] SET  READ_WRITE 
GO
