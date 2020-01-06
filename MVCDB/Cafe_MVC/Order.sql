CREATE TABLE [dbo].[Order]
(
	[orderID] INT IDENTITY (1,1) NOT NULL,
	[orderDate] date not null,
	[orderStatus] NVARCHAR (10) NULL,
	PRIMARY KEY CLUSTERED ([orderID] ASC),
)
