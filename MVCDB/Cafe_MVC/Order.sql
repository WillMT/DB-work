CREATE TABLE [dbo].[Order]
(
	[orderID] INT IDENTITY (1,1) NOT NULL,
	[CusName] NVARCHAR(50) not null,
	[orderStatus] NVARCHAR (10) NULL,
	[OrderTotal] DECIMAL NULL, 
    [OrderTimeStamp] TIMESTAMP NULL, 
    PRIMARY KEY CLUSTERED ([orderID] ASC),
)
