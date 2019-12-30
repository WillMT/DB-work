﻿CREATE TABLE [dbo].[OrderItem]
(
	[OrderID] INT NOT NULL,
	[itemID] INT NOT NULL,
	[itemQty] int NOT NULL,
	[lastUpdateDate] Date not null, 
	PRIMARY KEY CLUSTERED ([OrderID],[itemID] ASC),
    CONSTRAINT [FK_dbo.OrderItem_dbo.Order_OrderID] FOREIGN KEY ([OrderID])
		REFERENCES [dbo].[Order]([OrderID]) ON DELETE NO ACTION,
	CONSTRAINT [FK_dbo.OrderItem_dbo.item_itemID] FOREIGN KEY ([itemID])
		REFERENCES [dbo].[item]([itemID]) ON DELETE NO ACTION,
)

GO
