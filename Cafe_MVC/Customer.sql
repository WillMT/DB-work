CREATE TABLE [dbo].[Customer]
(
	[cusID] int NOT NULL PRIMARY KEY,
	[cName] NVARCHAR (50) not NULL,
	[cphone] int not null,
	primary key clustered ([cusID] ASC) 
)
