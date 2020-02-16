USE [ContosoUniversity1]
GO

/****** Object: Table [dbo].[OIL] Script Date: 16/2/2020 15:24:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OIL] (
    [OILid]             INT             IDENTITY (1, 1) NOT NULL,
    [OID]               INT             NOT NULL,
    [iID]               INT             NOT NULL,
    [iName]             NVARCHAR (MAX)  NULL,
    [iprice]            DECIMAL (18, 2) NOT NULL,
    [qty]               INT             NOT NULL,
    [Item_itemID]       INT             NULL,
    [OrderInfo_OrderID] INT             NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Item_itemID]
    ON [dbo].[OIL]([Item_itemID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderInfo_OrderID]
    ON [dbo].[OIL]([OrderInfo_OrderID] ASC);


GO
ALTER TABLE [dbo].[OIL]
    ADD CONSTRAINT [PK_dbo.OIL] PRIMARY KEY CLUSTERED ([OILid] ASC);


GO
ALTER TABLE [dbo].[OIL]
    ADD CONSTRAINT [FK_dbo.OIL_dbo.Item_Item_itemID] FOREIGN KEY ([Item_itemID]) REFERENCES [dbo].[Item] ([itemID]);


GO
ALTER TABLE [dbo].[OIL]
    ADD CONSTRAINT [FK_dbo.OIL_dbo.OrderInfo_OrderInfo_OrderID] FOREIGN KEY ([OrderInfo_OrderID]) REFERENCES [dbo].[OrderInfo] ([OrderID]);


