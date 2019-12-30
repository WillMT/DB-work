CREATE TABLE [dbo].[Item]
(
	[itemID] INT IDENTITY (1,1) NOT NULL,
	[itemType] CHAR NOT NULL,
	[itemName] NVARCHAR(50) NOT NULL,
	[qty] int NOT NULL,
	[img] varbinary(MAX),
	PRIMARY KEY CLUSTERED ([itemID] ASC)
)
