CREATE TABLE [dbo].[OrderItem]
(
	[OrderID] INT NOT NULL PRIMARY KEY,
	[itemID] INT NOT NULL PRIMARY KEY,
	[itemQty] int NOT NULL,
	[lastUpdateDate] Date not null, 
    CONSTRAINT [FK_dbo.OrderItem_dbo.Order_OrderID] FOREIGN KEY ([OrderID])
		REFERENCES [dbo].[Order]([OrderID]) ON DELETE CASCADE,
)

GO
