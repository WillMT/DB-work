CREATE TABLE [dbo].[Order]
(
	[orderID] INT IDENTITY (1,1) PRIMARY KEY,
	[cusID] INT NOT NULL,
	[orderDate] date not null,
	PRIMARY KEY CLUSTERED ([OrderID] ASC),
	CONSTRAINT [FK_dbo.Order_dbo.Customer_cusID] FOREIGN KEY ([cusID])
		REFERENCES [dbo].[Customer]([cusID]) ON DELETE NO ACTION,
)
