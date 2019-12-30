CREATE TABLE [dbo].[Order]
(
	[orderID] INT IDENTITY (1,1) NOT NULL,
	[cusID] INT NOT NULL,
	[orderDate] date not null,
	PRIMARY KEY CLUSTERED ([orderID] ASC),
	CONSTRAINT [FK_dbo.Order_dbo.Customer_cusID] FOREIGN KEY ([cusID])
		REFERENCES [dbo].[Customer]([cusID]) ON DELETE NO ACTION,
)
