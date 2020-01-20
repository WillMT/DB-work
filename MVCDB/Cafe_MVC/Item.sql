CREATE TABLE [dbo].[Item]
(
	[itemID] INT IDENTITY (1,1) NOT NULL,
	[itemType] NVARCHAR(20) NOT NULL,
	[itemName] NVARCHAR(100) NOT NULL,
	[iDesc] NVARCHAR (300) NOT NULL,
	[iStatus] char  null,
	[iPrice] int not null,
	[qty] int NOT NULL,
	[imgdata] varbinary(MAX),
	PRIMARY KEY CLUSTERED ([itemID] ASC)
)
