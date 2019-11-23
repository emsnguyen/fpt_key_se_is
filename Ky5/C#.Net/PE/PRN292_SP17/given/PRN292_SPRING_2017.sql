USE master
GO
IF EXISTS(select * from sys.databases where name='PRN292_SPRING_2017')
DROP DATABASE PRN292_SPRING_2017
GO
CREATE DATABASE PRN292_SPRING_2017
GO
USE [PRN292_SPRING_2017]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 03/05/2017 20:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] NOT NULL,
	[DepartmentName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (1, N'Dept 1')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (2, N'Dept 2')
/****** Object:  Table [dbo].[Certificate]    Script Date: 03/05/2017 20:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Certificate](
	[CertificateID] [int] NOT NULL,
	[CertificateName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Certificate] PRIMARY KEY CLUSTERED 
(
	[CertificateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Certificate] ([CertificateID], [CertificateName]) VALUES (1, N'SCJP')
INSERT [dbo].[Certificate] ([CertificateID], [CertificateName]) VALUES (2, N'OCJP')
INSERT [dbo].[Certificate] ([CertificateID], [CertificateName]) VALUES (3, N'CCNA')
INSERT [dbo].[Certificate] ([CertificateID], [CertificateName]) VALUES (4, N'MTA')
INSERT [dbo].[Certificate] ([CertificateID], [CertificateName]) VALUES (5, N'MCSA')
/****** Object:  Table [dbo].[Skill]    Script Date: 03/05/2017 20:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Skill](
	[SkillID] [int] NOT NULL,
	[SkillName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[SkillID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Skill] ([SkillID], [SkillName]) VALUES (1, N'Java Programming')
INSERT [dbo].[Skill] ([SkillID], [SkillName]) VALUES (2, N'.NET Programming')
INSERT [dbo].[Skill] ([SkillID], [SkillName]) VALUES (3, N'Web Front-End')
INSERT [dbo].[Skill] ([SkillID], [SkillName]) VALUES (4, N'Database System')
/****** Object:  Table [dbo].[Employee]    Script Date: 03/05/2017 20:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [varchar](10) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Gender], [DOB], [DepartmentID]) VALUES (N'Dep1001', N'Mr A', 1, CAST(0x37030B00 AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Gender], [DOB], [DepartmentID]) VALUES (N'Dep1002', N'Mr B', 1, CAST(0xC60B0B00 AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Gender], [DOB], [DepartmentID]) VALUES (N'Dep2001', N'Ms C', 0, CAST(0x330D0B00 AS Date), 2)
/****** Object:  Table [dbo].[EmployeeSkill]    Script Date: 03/05/2017 20:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeSkill](
	[SkillID] [int] NOT NULL,
	[EmployeeID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_EmployeeSkill] PRIMARY KEY CLUSTERED 
(
	[SkillID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (1, N'Dep1001')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (1, N'Dep1002')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (1, N'Dep2001')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (2, N'Dep1001')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (2, N'Dep1002')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (2, N'Dep2001')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (3, N'Dep1002')
INSERT [dbo].[EmployeeSkill] ([SkillID], [EmployeeID]) VALUES (4, N'Dep1002')
/****** Object:  Table [dbo].[EmployeeCertificate]    Script Date: 03/05/2017 20:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeCertificate](
	[CertificateID] [int] NOT NULL,
	[EmployeeID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_EmployeeCertificate] PRIMARY KEY CLUSTERED 
(
	[CertificateID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EmployeeCertificate] ([CertificateID], [EmployeeID]) VALUES (1, N'Dep1001')
INSERT [dbo].[EmployeeCertificate] ([CertificateID], [EmployeeID]) VALUES (2, N'Dep1001')
INSERT [dbo].[EmployeeCertificate] ([CertificateID], [EmployeeID]) VALUES (4, N'Dep2001')
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 03/05/2017 20:22:48 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_EmployeeCertificate_Certificate]    Script Date: 03/05/2017 20:22:48 ******/
ALTER TABLE [dbo].[EmployeeCertificate]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeCertificate_Certificate] FOREIGN KEY([CertificateID])
REFERENCES [dbo].[Certificate] ([CertificateID])
GO
ALTER TABLE [dbo].[EmployeeCertificate] CHECK CONSTRAINT [FK_EmployeeCertificate_Certificate]
GO
/****** Object:  ForeignKey [FK_EmployeeCertificate_Employee]    Script Date: 03/05/2017 20:22:48 ******/
ALTER TABLE [dbo].[EmployeeCertificate]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeCertificate_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeCertificate] CHECK CONSTRAINT [FK_EmployeeCertificate_Employee]
GO
/****** Object:  ForeignKey [FK_EmployeeSkill_Employee]    Script Date: 03/05/2017 20:22:48 ******/
ALTER TABLE [dbo].[EmployeeSkill]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSkill_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeSkill] CHECK CONSTRAINT [FK_EmployeeSkill_Employee]
GO
/****** Object:  ForeignKey [FK_EmployeeSkill_Skill]    Script Date: 03/05/2017 20:22:48 ******/
ALTER TABLE [dbo].[EmployeeSkill]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSkill_Skill] FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skill] ([SkillID])
GO
ALTER TABLE [dbo].[EmployeeSkill] CHECK CONSTRAINT [FK_EmployeeSkill_Skill]
GO
