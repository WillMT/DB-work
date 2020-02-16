USE [ContosoUniversity1]
GO

/****** Object: Table [dbo].[CartItem] Script Date: 16/2/2020 16:51:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CartItem] (
    [iID]    INT             IDENTITY (1, 1) NOT NULL,
    [iName]  NVARCHAR (MAX)  NULL,
    [iprice] DECIMAL (18, 2) NOT NULL,
    [qty]    INT             NOT NULL
);


