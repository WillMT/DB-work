USE [Cafe_MVC]
GO

/****** Object: Table [dbo].[Item] Script Date: 16/2/2020 15:27:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item] (
    [itemID]   INT             IDENTITY (1, 1) NOT NULL,
    [itemType] NVARCHAR (20)   NOT NULL,
    [itemName] NVARCHAR (100)  NOT NULL,
    [iDesc]    NVARCHAR (300)  NOT NULL,
    [iStatus]  CHAR (1)        NULL,
    [iPrice]   INT             NOT NULL,
    [qty]      INT             NOT NULL,
    [imgdata]  VARBINARY (MAX) NULL
);


