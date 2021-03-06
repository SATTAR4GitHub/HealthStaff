
/****** Object:  Database [hhsdb]    Script Date: 2020-12-06 10:02:37 PM ******/

-- Setting NOCOUNT ON suppresses completion messages
SET NOCOUNT ON

-- Make the master database the current database
USE master

-- If sshdb database exists, drop it
IF EXISTS (SELECT  * FROM sysdatabases WHERE name = 'hhsdb')
  DROP DATABASE hhsdb;
GO

-- Create the hhddb database
CREATE DATABASE hhsdb;
GO

-- Make the sshdb database the current database
USE hhsdb;

-- Create Patients table
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[HealthCardNumber] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Insert data into Patients table
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([PatientId], [FirstName], [LastName], [DateOfBirth], [Gender], [HealthCardNumber]) VALUES (8, N'Mike', N'Mullar', CAST(N'1988-12-12T00:00:00.0000000' AS DateTime2), N'M', N'255-455-521')
INSERT [dbo].[Patients] ([PatientId], [FirstName], [LastName], [DateOfBirth], [Gender], [HealthCardNumber]) VALUES (9, N'Nike', N'Moore', CAST(N'1978-12-12T00:00:00.0000000' AS DateTime2), N'M', N'355-455-520')
INSERT [dbo].[Patients] ([PatientId], [FirstName], [LastName], [DateOfBirth], [Gender], [HealthCardNumber]) VALUES (10, N'Jane', N'Jackson', CAST(N'1989-11-12T00:00:00.0000000' AS DateTime2), N'F', N'555-455-551')

SET IDENTITY_INSERT [dbo].[Patients] OFF
GO

