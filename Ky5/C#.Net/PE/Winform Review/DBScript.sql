
create database Y17S3B1
go

USE [Y17S3B1];
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroups](
	[GroupID] [int] NOT NULL,
	[GroupName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UserGroups] ([GroupID], [GroupName]) VALUES (1, N'super admin')
INSERT [dbo].[UserGroups] ([GroupID], [GroupName]) VALUES (2, N'admin')
INSERT [dbo].[UserGroups] ([GroupID], [GroupName]) VALUES (3, N'member')
INSERT [dbo].[UserGroups] ([GroupID], [GroupName]) VALUES (4, N'public')
/****** Object:  Table [dbo].[Features]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Features](
	[FeatureID] [int] NOT NULL,
	[FeatureName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName]) VALUES (1, N'View')
INSERT [dbo].[Features] ([FeatureID], [FeatureName]) VALUES (2, N'Search')
INSERT [dbo].[Features] ([FeatureID], [FeatureName]) VALUES (3, N'Add')
INSERT [dbo].[Features] ([FeatureID], [FeatureName]) VALUES (4, N'Update')
INSERT [dbo].[Features] ([FeatureID], [FeatureName]) VALUES (5, N'Delete')
/****** Object:  Table [dbo].[Employees]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] NOT NULL,
	[EmployeeName] [nvarchar](150) NOT NULL,
	[EmployeeDOB] [date] NOT NULL,
	[EmployeeGender] [bit] NOT NULL,
	[EmployeeAddress] [varchar](150) NOT NULL,
	[SupervisorID] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [EmployeeDOB], [EmployeeGender], [EmployeeAddress], [SupervisorID]) VALUES (1, N'Andrew Ng', CAST(0x39F70A00 AS Date), 1, N'University of Cambigde', NULL)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [EmployeeDOB], [EmployeeGender], [EmployeeAddress], [SupervisorID]) VALUES (2, N'Ngô Hoàng Anh', CAST(0x8F1F0B00 AS Date), 1, N'Cambridge Admissions Office. Fitzwilliam House. 32 Trumpington', 1)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [EmployeeDOB], [EmployeeGender], [EmployeeAddress], [SupervisorID]) VALUES (3, N'Lionel Tucker', CAST(0x04FB0A00 AS Date), 1, N'Trinity Lane, Cambridge CB2 1TN', 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [EmployeeDOB], [EmployeeGender], [EmployeeAddress], [SupervisorID]) VALUES (4, N'Crital Lee', CAST(0x59080B00 AS Date), 0, N'The office of Chancellor of the university', 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [EmployeeDOB], [EmployeeGender], [EmployeeAddress], [SupervisorID]) VALUES (5, N'Hwang Tee Chun', CAST(0x02140B00 AS Date), 1, N'The office of Chancellor of the university', 1)
/****** Object:  Table [dbo].[Requests]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Requests](
	[RequestID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Reason] [varchar](1000) NOT NULL,
	[ProcessedBy] [int] NULL,
	[Status] [varchar](10) NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group_Feature]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group_Feature](
	[GroupID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
 CONSTRAINT [PK_Group_Feature] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (1, 1)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (1, 2)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (1, 3)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (1, 4)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (1, 5)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (2, 1)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (2, 2)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (2, 3)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (2, 4)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (3, 1)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (3, 2)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (3, 3)
INSERT [dbo].[Group_Feature] ([GroupID], [FeatureID]) VALUES (4, 1)
/****** Object:  Table [dbo].[Account]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[UserID] [varchar](50) NOT NULL,
	[DisplayName] [nvarchar](150) NOT NULL,
	[JoinedDate] [date] NOT NULL,
	[Active] [bit] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Account] ([UserID], [DisplayName], [JoinedDate], [Active], [EmployeeID]) VALUES (N'andng', N'Andrew Ng', CAST(0xDD220B00 AS Date), 0, 1)
INSERT [dbo].[Account] ([UserID], [DisplayName], [JoinedDate], [Active], [EmployeeID]) VALUES (N'andrew', N'Andrew Ng', CAST(0xB6250B00 AS Date), 1, 1)
INSERT [dbo].[Account] ([UserID], [DisplayName], [JoinedDate], [Active], [EmployeeID]) VALUES (N'anhnh', N'Hai Anh', CAST(0x75340B00 AS Date), 1, 2)
INSERT [dbo].[Account] ([UserID], [DisplayName], [JoinedDate], [Active], [EmployeeID]) VALUES (N'hwang', N'Hwang', CAST(0xE1350B00 AS Date), 1, 5)
INSERT [dbo].[Account] ([UserID], [DisplayName], [JoinedDate], [Active], [EmployeeID]) VALUES (N'lee', N'Crital Lee', CAST(0x5F360B00 AS Date), 1, 4)
INSERT [dbo].[Account] ([UserID], [DisplayName], [JoinedDate], [Active], [EmployeeID]) VALUES (N'tucker', N'L. Tucker', CAST(0x21360B00 AS Date), 1, 3)
/****** Object:  Table [dbo].[User_Group]    Script Date: 10/20/2017 07:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Group](
	[GroupID] [int] NOT NULL,
	[UserID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (1, N'andrew')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (1, N'anhnh')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (2, N'andrew')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (2, N'anhnh')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (2, N'lee')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (2, N'tucker')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (3, N'andrew')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (3, N'anhnh')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (3, N'lee')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (4, N'andrew')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (4, N'anhnh')
INSERT [dbo].[User_Group] ([GroupID], [UserID]) VALUES (4, N'Hwang')
/****** Object:  ForeignKey [FK_Account_Employees]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Employees]
GO
/****** Object:  ForeignKey [FK_Employees_Employees]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([SupervisorID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
/****** Object:  ForeignKey [FK_Group_Feature_Features]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[Group_Feature]  WITH CHECK ADD  CONSTRAINT [FK_Group_Feature_Features] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([FeatureID])
GO
ALTER TABLE [dbo].[Group_Feature] CHECK CONSTRAINT [FK_Group_Feature_Features]
GO
/****** Object:  ForeignKey [FK_Group_Feature_UserGroups]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[Group_Feature]  WITH CHECK ADD  CONSTRAINT [FK_Group_Feature_UserGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[UserGroups] ([GroupID])
GO
ALTER TABLE [dbo].[Group_Feature] CHECK CONSTRAINT [FK_Group_Feature_UserGroups]
GO
/****** Object:  ForeignKey [FK_Requests_Employees]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Employees] FOREIGN KEY([ProcessedBy])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Employees]
GO
/****** Object:  ForeignKey [FK_Requests_Employees1]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Employees1] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Employees1]
GO
/****** Object:  ForeignKey [FK_User_Group_Account]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account] ([UserID])
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_Account]
GO
/****** Object:  ForeignKey [FK_User_Group_UserGroups]    Script Date: 10/20/2017 07:57:37 ******/
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_UserGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[UserGroups] ([GroupID])
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_UserGroups]
GO
