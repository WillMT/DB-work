CREATE TABLE [dbo].[Item]
(
	[itemID] INT IDENTITY (1,1) NOT NULL,
	[itemType] NVARCHAR(10) NOT NULL,
	[itemName] NVARCHAR(50) NOT NULL,
	[iDesc] NVARCHAR (300) NOT NULL,
	[iStatus] char  null,
	[qty] int NOT NULL,
	[img] varbinary(MAX),
	PRIMARY KEY CLUSTERED ([itemID] ASC)
)
