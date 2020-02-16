USE [Cafe_MVC]
GO

/****** Object: Table [dbo].[admin] Script Date: 16/2/2020 15:26:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[admin] (
    [adminID] INT           IDENTITY (1, 1) NOT NULL,
    [aName]   NVARCHAR (50) NOT NULL,
    [aPwd]    NVARCHAR (20) NOT NULL
);


