CREATE TABLE [dbo].[Item]
(
	[itemID] INT NOT NULL PRIMARY KEY,
	[itemType] CHAR NOT NULL,
	[itemName] NVARCHAR(50) NOT NULL,
	[qty] int NOT NULL,
	PRIMARY KEY CLUSTERED ([itemID] ASC)
)
