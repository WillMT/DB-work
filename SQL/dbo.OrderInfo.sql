USE [ContosoUniversity1]
GO

/****** Object: Table [dbo].[OrderInfo] Script Date: 16/2/2020 16:51:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderInfo] (
    [OrderID]     INT             IDENTITY (1, 1) NOT NULL,
    [CusName]     NVARCHAR (30)   NOT NULL,
    [CusPhone]    NVARCHAR (8)    NOT NULL,
    [TableNo]     INT             NOT NULL,
    [Total]       DECIMAL (18, 2) NOT NULL,
    [OrderStatus] NVARCHAR (MAX)  NULL
);


