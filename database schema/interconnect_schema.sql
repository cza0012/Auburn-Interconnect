CREATE DATABASE [interconnect]
GO

USE [interconnect]
GO

CREATE TABLE [Users](
	[uid] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[pwd] [binary](32) NOT NULL,
	[fname] [varchar](50) NOT NULL,
	[lname] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [bigint] NULL,
	[admin] [bit] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [PwdResetRequests](
	[email] [varchar](100) NULL,
	[resetcode] [varchar](10) NULL,
	[requestDate] [date] NOT NULL
)
GO

CREATE TABLE [Events](
	[eventId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[creatorId] [int] NOT NULL,
	[createTime] [datetime] NOT NULL,
	[approved] [bit] NOT NULL DEFAULT 0,
	[declined] [bit] NOT NULL DEFAULT 0,
	[guestLimit] [int] NULL,
	[hostOrg] [varchar](255) NULL,
	[hostName] [varchar](255) NOT NULL,
	[hostEmail] [varchar](255) NOT NULL,
	[hostPhone] [bigint] NOT NULL,
	[eventName] [varchar](255) NOT NULL,
	[descr] [text] NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NOT NULL,
	[regDeadline] [datetime] NOT NULL,
	[location] [varchar](255) NOT NULL,
	[meetLocation] [varchar](255) NOT NULL,
	[meetTime] [datetime] NOT NULL,
	[transportation] [text] NOT NULL,
	[requestDrivers] [bit] NOT NULL DEFAULT 0,
	[costs] [text] NULL,
	[equipment] [text] NULL,
	[food] [text] NULL,
	[other] [text] NULL
)
GO

CREATE TABLE [EventRegs](
	[eventId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[headCount] [int] NOT NULL DEFAULT 1,
	[canDrive] [bit] NOT NULL DEFAULT 0,
	[vehicleCap] [int] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_EventRegs] PRIMARY KEY CLUSTERED 
(
	[eventId] ASC,
	[userId] ASC
)
)
GO

/****** Object:  ForeignKey [FK_Events_Users]    Script Date: 12/30/2011 15:18:57 ******/
ALTER TABLE [Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([creatorId])
REFERENCES [Users] ([uid])
GO
ALTER TABLE [Events] CHECK CONSTRAINT [FK_Events_Users]
GO
/****** Object:  ForeignKey [FK_EventRegs_Events]    Script Date: 12/30/2011 15:18:57 ******/
ALTER TABLE [EventRegs]  WITH CHECK ADD  CONSTRAINT [FK_EventRegs_Events] FOREIGN KEY([eventId])
REFERENCES [Events] ([eventId])
GO
ALTER TABLE [EventRegs] CHECK CONSTRAINT [FK_EventRegs_Events]
GO
/****** Object:  ForeignKey [FK_EventRegs_Users]    Script Date: 12/30/2011 15:18:57 ******/
ALTER TABLE [EventRegs]  WITH CHECK ADD  CONSTRAINT [FK_EventRegs_Users] FOREIGN KEY([userId])
REFERENCES [Users] ([uid])
GO
ALTER TABLE [EventRegs] CHECK CONSTRAINT [FK_EventRegs_Users]
GO
